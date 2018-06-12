using System;
using WhatsNewInCSharp72.BaseClasses;

namespace WhatsNewInCSharp72
{
	class Program
	{
		private static MutuableStruct staticData = new MutuableStruct { Data = 20 };

		//Program.PassMutuableStruct(new MutuableStruct { Data = 10 });
		//Program.UseMutuableStruct();
		//Program.UseReadonlyStruct();
		//Program.WorkWithSpans();
		//Program.MixNamedAndOptionalArguments(guidValue: Guid.NewGuid(), stringValue: "My value", intValue: 22);
		//Program.UseLeadingUnderscores();
		//Program.UsePrivateProtected();
		static void Main() =>
			Program.UsePrivateProtected();

		private static void PassMutuableStruct(in MutuableStruct data)
		{
			Console.Out.WriteLine(nameof(Program.PassMutuableStruct));
			Console.Out.WriteLine();

			var value = data.Data;

			// This won't work:
			//data.Data = 22;

			Console.Out.WriteLine(value);
		}

		private static void UseMutuableStruct()
		{
			Console.Out.WriteLine(nameof(Program.UseMutuableStruct));
			Console.Out.WriteLine();

			ref readonly var value = ref Program.HandleReturnedValue();
			var valueData = value.Data;

			// This won't work:
			//value.Data = 44;
			Console.Out.WriteLine(valueData);
		}

		private static void UseReadonlyStruct()
		{
			Console.Out.WriteLine(nameof(Program.UseReadonlyStruct));
			Console.Out.WriteLine();

			var data = new ReadonlyStruct(33);
			Console.Out.WriteLine(data.Data);
		}

		private static void WorkWithSpans()
		{
			Console.Out.WriteLine(nameof(Program.WorkWithSpans));
			Console.Out.WriteLine();

			Span<byte> stackBytes = stackalloc byte[2];
			stackBytes[0] = 42;
			stackBytes[1] = 43;
			Console.Out.WriteLine($"{stackBytes[0]}, {stackBytes[1]}");

			var input = "22,33";
			var commaPosition = input.IndexOf(',');

			// Allocations
			var first = int.Parse(input.Substring(0, commaPosition));
			var second = int.Parse(input.Substring(commaPosition + 1));
			Console.Out.WriteLine(
				$"{nameof(first)}, {first} - {nameof(second)}, {second}");

			// No allocations
			var inputSpan = input.AsSpan();
			var firstSpan = int.Parse(inputSpan.Slice(0, commaPosition));
			var secondSpan = int.Parse(inputSpan.Slice(commaPosition + 1));
			Console.Out.WriteLine(
				$"{nameof(firstSpan)}, {firstSpan} - {nameof(secondSpan)}, {secondSpan}");
		}

		private static void MixNamedAndOptionalArguments(int intValue, Guid guidValue, string stringValue = default)
		{
			Console.Out.WriteLine(nameof(Program.MixNamedAndOptionalArguments));
			Console.Out.WriteLine();

			Console.Out.WriteLine($"{nameof(intValue)} = {intValue}, {nameof(guidValue)} = {guidValue}, {nameof(stringValue)} = {stringValue}");
		}

		private static void UseLeadingUnderscores()
		{
			Console.Out.WriteLine(nameof(Program.UseLeadingUnderscores));
			Console.Out.WriteLine();

			var data = 0b_100_100_1;
			Console.Out.WriteLine((char)data);
		}

		private static void UsePrivateProtected()
		{
			Console.Out.WriteLine(nameof(Program.UsePrivateProtected));
			Console.Out.WriteLine();

			Console.Out.WriteLine(
				$"{nameof(ClassDerivingFromClassWithProtectedInternalMethod)} = {new ClassDerivingFromClassWithProtectedInternalMethod().Data}");
			Console.Out.WriteLine(
				$"{nameof(ClassDerivingFromClassWithPrivateProtectedMethod)} = {new ClassDerivingFromClassWithPrivateProtectedMethod().Data}");
			Console.Out.WriteLine(
				$"{nameof(MyClassDerivingFromClassWithProtectedInternalMethod)} = {new MyClassDerivingFromClassWithProtectedInternalMethod().Data}");
			Console.Out.WriteLine(
				$"{nameof(MyClassDerivingFromClassWithPrivateProtectedMethod)} = {new MyClassDerivingFromClassWithPrivateProtectedMethod().Data}");
		}

		private static ref readonly MutuableStruct HandleReturnedValue() => ref Program.staticData;
	}
}
