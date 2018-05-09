using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace WhatsNewInCSharp73
{
	class Program
	{
		//Program.UseEnumConstraints(BindingFlags.CreateInstance);
		//Program.CompareTuples();
		//Program.SerializeWithBackingFieldNonSerialized();
		static void Main(string[] args) =>
			Program.UseEnumConstraints(BindingFlags.CreateInstance);

		private static void UseEnumConstraints<T>(T value)
			where T : Enum
		{
			Console.Out.WriteLine($"{nameof(Program.UseEnumConstraints)}");
			Console.Out.WriteLine();

			Console.Out.WriteLine($"{typeof(T).Name}, {value}");
		}

		public static void CompareTuples()
		{
			Console.Out.WriteLine($"{nameof(Program.CompareTuples)}");
			Console.Out.WriteLine();

			var value1 = (3, 4);
			var value2 = (4, 5);
			var value3 = (3, 4);

			Console.Out.WriteLine($"{nameof(value1)}:{value1} == {nameof(value2)}:{value2} is {value1 == value2}");
			Console.Out.WriteLine($"{nameof(value1)}:{value1} == {nameof(value3)}:{value3} is {value1 == value3}");
			Console.Out.WriteLine($"{nameof(value2)}:{value2} == {nameof(value3)}:{value3} is {value2 == value3}");
		}

		public static void SerializeWithBackingFieldNonSerialized()
		{
			Console.Out.WriteLine($"{nameof(Program.SerializeWithBackingFieldNonSerialized)}");
			Console.Out.WriteLine();

			var data = new SerializableData { Id = Guid.NewGuid(), SSN = "123-45-6789" };
			Console.Out.WriteLine($"{nameof(data)}, {nameof(data.Id)} is {data.Id}, {nameof(data.SSN)} is {data.SSN}");

			var formatter = new BinaryFormatter();

			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, data);
				stream.Position = 0;
				var newData = formatter.Deserialize(stream) as SerializableData;
				Console.Out.WriteLine($"{nameof(newData)}, {nameof(newData.Id)} is {newData.Id}, {nameof(newData.SSN)} is {newData.SSN}");
			}
		}
	}
}
