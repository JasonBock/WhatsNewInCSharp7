using BenchmarkDotNet.Attributes;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WhatsNewInCSharp72
{
	[MemoryDiagnoser]
	public class SerializationWithArrays
	{
		private byte[] converterData;
		private byte[] spanData;
		private byte[] streamData;

		[GlobalSetup]
		public void Setup()
		{
			this.converterData = BufferGenerators.GenerateWithConverters(
				22, new Coordinate { X = 10, Y = 20, Z = 30 },
				"This is a lot of string data. This is a lot of string data. This is a lot of string data.");
			this.streamData = BufferGenerators.GenerateWithStream(
				22, new Coordinate { X = 10, Y = 20, Z = 30 },
				"This is a lot of string data. This is a lot of string data. This is a lot of string data.");
			this.spanData = BufferGenerators.GenerateWithSpan(
				22, new Coordinate { X = 10, Y = 20, Z = 30 },
				"This is a lot of string data. This is a lot of string data. This is a lot of string data.");
		}

		[Benchmark]
		public int GetConverterValue()
		{
			var pointSize = Marshal.SizeOf<Coordinate>();

			var value = BitConverter.ToInt32(this.converterData, 0);
			var pointPtr = Marshal.AllocHGlobal(pointSize);
			Marshal.Copy(this.converterData, 4, pointPtr, pointSize);
			var coordinate = (Coordinate)Marshal.PtrToStructure(pointPtr, typeof(Coordinate));
			Marshal.FreeHGlobal(pointPtr);

			var data = Encoding.Unicode.GetString(this.converterData,
				4 + pointSize, this.converterData.Length - (4 + pointSize));

			return value + coordinate.Y + data.Length;
		}

		[Benchmark]
		public int GetStreamValue()
		{
			using (var reader = new BinaryReader(new MemoryStream(this.streamData), Encoding.Unicode))
			{
				var value = reader.ReadInt32();
				var coordinate = new Coordinate
				{
					X = reader.ReadInt32(),
					Y = reader.ReadInt32(),
					Z = reader.ReadInt32()
				};
				var data = reader.ReadString();

				return value + coordinate.Y + data.Length;
			}
		}

		[Benchmark]
		public int GetSpanValue()
		{
			var pointSize = Marshal.SizeOf<Coordinate>();
			ReadOnlySpan<byte> span = this.converterData.AsSpan();

			var value = MemoryMarshal.Read<int>(span.Slice(0, 4));
			var coordinate = MemoryMarshal.Read<Coordinate>(span.Slice(4, pointSize));
			var data = new string(MemoryMarshal.Cast<byte, char>(span.Slice(4 + pointSize)));

			return value + coordinate.Y + data.Length;
		}
	}
}
