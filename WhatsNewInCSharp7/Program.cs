using System;

namespace WhatsNewInCSharp7
{
	class Program
	{
		const int FirstValue = 00_11_00_11;
		const int SecondValue = 0b00_11_00_11;
		const int ThirdValue = 0x3_3;

		static void Main(string[] args)
		{
			//Program.PrintConstants();
			//Program.UseLocalFunction();
			//Program.MakingParsingEasy("fjdklaf");
			//Program.MakingParsingEasy("3");
			Program.HandlingRefs();
			//Program.UseCalculator();
			//Program.UseHandler();
		}

		private static void PrintConstants()
		{
			Console.Out.WriteLine(FirstValue);
			Console.Out.WriteLine(SecondValue);
			Console.Out.WriteLine(ThirdValue);
		}

		private static void UseLocalFunction()
		{
			double Calculate(double x)
			{
				return (3 * x + 4) / 2;
			}

			Console.Out.WriteLine(Calculate(2.22));
			Console.Out.WriteLine(Calculate(4.44));
		}

		private static void MakingParsingEasy(string value)
		{
			// First way
			try
			{
				var firstWay= int.Parse(value);
				Console.Out.WriteLine($"First way: {firstWay}");
			}
			catch (ArgumentNullException) { }
			catch (OverflowException) { }
			catch (FormatException) { }

			// Second way
			var secondWay = 0;

			if(int.TryParse(value, out secondWay))
			{
				Console.Out.WriteLine($"Second way: {secondWay}");
			}

			// Thrid way
			if (int.TryParse(value, out var thridWay))
			{
				Console.Out.WriteLine($"Third way: {thridWay}");
			}
		}

		private static HugeData[] Values = { new HugeData(30000), new HugeData(20), new HugeData(300) };

		private static ref HugeData GetData()
		{
			return ref Program.Values[new Random(DateTime.Now.Millisecond).Next(0, 3)];
		}

		private static void HandlingRefs()
		{
			ref var result = ref Program.GetData();
			Console.Out.WriteLine(result.GetSize());
		}

		private static void UseCalculator()
		{
			var result = Calculator.CalculateWithDeconstructedType(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithDeconstructedType)} value: {result.Result}");
			(var x, var _) = result;
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithDeconstructedType)} value from x: {result.Result}");

			var tupleResult = Calculator.Calculate(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.Calculate)} value: {tupleResult.Item1}");

			var namedTupleResult = Calculator.CalculateWithNamedValues(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithNamedValues)} value: {namedTupleResult.value}");
			(var namedValue, var __) = Calculator.CalculateWithNamedValues(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithNamedValues)} value from name: {namedValue}");
		}

		private static void UseHandler()
		{
			var handler = new Handler();
			handler.Handle();
			handler.Handle(("a", 1, Guid.NewGuid()));
			handler.Handle(("a", "b"));
		}
	}
}
