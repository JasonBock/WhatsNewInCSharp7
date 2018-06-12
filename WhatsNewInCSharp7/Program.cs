using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WhatsNewInCSharp7
{
	public static class Program
	{
		const int FirstValue = 00_11_00_11;
		const int SecondValue = 0b00_11_00_11;
		const int ThirdValue = 0x3_3;

		//Program.ShowBinaryDigitsAndDigitSeparators();
		//Program.ShowLocalFunctions();
		//Program.ShowOutVar();
		//Program.ShowRefReturnsAndLocals();
		//Program.ShowPatternMatching();
		//Program.ShowTuples();
		//Program.ShowTuplesWithGenerics();
		//Program.ShowTuplesWithPropertyAssignmentInConstructor();
		//Program.ShowValueTask();
		//Program.ShowExpressionBodiedMembersAndThrowExpressions();
		public static void Main() => 
			Program.ShowValueTask();

		private static void ShowBinaryDigitsAndDigitSeparators()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowBinaryDigitsAndDigitSeparators)}");
			Console.Out.WriteLine();

			Console.Out.WriteLine(Program.FirstValue);
			Console.Out.WriteLine(Program.SecondValue);
			Console.Out.WriteLine(Program.ThirdValue);
		}

		private static void ShowLocalFunctions()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowLocalFunctions)}");
			Console.Out.WriteLine();

			uint[] CollatzSequence(uint start)
			{
				uint Collatz(uint value) =>
					value % 2 == 1 ? (3 * value + 1) / 2 : value / 2;

				var sequence = new List<uint> { start };

				var next = start;

				while (next > 1)
				{
					next = Collatz(next);
					sequence.Add(next);
				}

				return sequence.ToArray();
			}

			Console.Out.WriteLine(string.Join(", ", CollatzSequence(5)));
			Console.Out.WriteLine(string.Join(", ", CollatzSequence(11)));
		}

		private static void ShowOutVar()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowOutVar)}");
			Console.Out.WriteLine();

			Program.MakingParsingEasy("fjdklaf");
			Program.MakingParsingEasy("3");
		}

		private static void MakingParsingEasy(string value)
		{
			// First way
			try
			{
				var firstWay = int.Parse(value);
				Console.Out.WriteLine($"First way: {firstWay}");
			}
			catch (ArgumentNullException) { }
			catch (OverflowException) { }
			catch (FormatException) { }

			// Second way
#pragma warning disable IDE0018 // Inline variable declaration
			var secondWay = 0;
#pragma warning restore IDE0018 // Inline variable declaration

			if (int.TryParse(value, out secondWay))
			{
				Console.Out.WriteLine($"Second way: {secondWay}");
			}

			// Third way
			if (int.TryParse(value, out var thirdWay))
			{
				Console.Out.WriteLine($"Third way: {thirdWay}");
			}
		}

		private static void ShowRefReturnsAndLocals()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowRefReturnsAndLocals)}");
			Console.Out.WriteLine();

			var slowClassList = new SlowList<GiantClass>(100);
			slowClassList[50] = new GiantClass();
			var slowClass1 = slowClassList[50];
			var slowClass2 = slowClassList[50];
			slowClass1.Value1 = 22;
			Console.Out.WriteLine(
				$"{nameof(slowClass2)}.{nameof(slowClass2.Value1)} is {slowClass2.Value1}");

			var slowList = new SlowList<GiantStruct>(100);
			var slowStruct1 = slowList[50];
			var slowStruct2 = slowList[50];
			slowStruct1.Value1 = 22;
			Console.Out.WriteLine(
				$"{nameof(slowStruct2)}.{nameof(slowStruct2.Value1)} is {slowStruct2.Value1}");

			var fastList = new FastList<GiantStruct>(100);

			// Note, you can type this, but it won't be "ref"
			//var fastStruct1 = fastList[50];
			//var fastStruct2 = fastList[50];

			ref var fastStruct1 = ref fastList[50];
			ref var fastStruct2 = ref fastList[50];
			fastStruct1.Value1 = 22;
			Console.Out.WriteLine(
				$"{nameof(fastStruct2)}.{nameof(fastStruct2.Value1)} is {fastStruct2.Value1}");
		}

		private static void ShowPatternMatching()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowPatternMatching)}");
			Console.Out.WriteLine();

			void CheckThings(Thing thing)
			{
				switch (thing)
				{
					case SomeThing someThing22 when someThing22.Value == 22:
						Console.Out.WriteLine($"{nameof(SomeThing)} with {nameof(Thing.Value)} == 22");
						break;
					case SomeThing someThingLessThan10 when someThingLessThan10.Value < 10:
						Console.Out.WriteLine($"{nameof(SomeThing)} with {nameof(Thing.Value)} < 10");
						break;
					case AnotherThing anotherThing:
						Console.Out.WriteLine($"{nameof(AnotherThing)}");
						break;
					default:
						Console.Out.WriteLine("Unknown case");
						break;
					case null:
						throw new ArgumentNullException(nameof(thing));
				}
			}

			CheckThings(new SomeThing { Value = 22 });
			CheckThings(new SomeThing { Value = 2 });
			CheckThings(new AnotherThing { Value = 2 });
			CheckThings(new SneakyThing());
			CheckThings(new SomeThing { Value = 222 });
			CheckThings(null);
		}

		private static void ShowTuples()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowTuples)}");
			Console.Out.WriteLine();

			var tupleResult = Calculator.Calculate(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.Calculate)} value: {tupleResult.Item1}");

			var namedTupleResult = Calculator.CalculateWithNamedValues(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithNamedValues)} value: {namedTupleResult.value}");
			(var namedValue, var _) = Calculator.CalculateWithNamedValues(
				Program.FirstValue, Program.ThirdValue);

			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithNamedValues)} value from name: {namedValue}");

			var result = Calculator.CalculateWithDeconstructedType(
				Program.FirstValue, Program.ThirdValue);
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithDeconstructedType)} value: {result.Result}");
			(var x, var y) = result;
			Console.Out.WriteLine($"{nameof(Calculator.CalculateWithDeconstructedType)} value from x: {x}");
		}

		private static void ShowTuplesWithGenerics()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowTuplesWithGenerics)}");
			Console.Out.WriteLine();

			var handler = new Handler();
			handler.Handle();
			handler.Handle(("a", 1, Guid.NewGuid()));
			handler.Handle(("a", "b"));
		}

		private static void ShowTuplesWithPropertyAssignmentInConstructor()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowTuplesWithPropertyAssignmentInConstructor)}");
			Console.Out.WriteLine();

			var properties = new LotsOfProperties(Guid.NewGuid(), "Jason", 22);
			Console.Out.WriteLine($"{nameof(properties.Id)} = {properties.Id}, {nameof(properties.Name)} = {properties.Name}, {nameof(properties.Age)} = {properties.Age}");
		}

		private static void ShowValueTask()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowValueTask)}");
			Console.Out.WriteLine();

			ValueTask<int> ReturnValueAsync() => new ValueTask<int>(22);

			Console.Out.WriteLine(ReturnValueAsync().GetAwaiter().GetResult());
		}

		private static void ShowExpressionBodiedMembersAndThrowExpressions()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowExpressionBodiedMembersAndThrowExpressions)}");
			Console.Out.WriteLine();

			void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				Console.Out.WriteLine($"{e.PropertyName} changed.");
			}

			var person = new ExpressedPerson(22, "John");
			person.PropertyChanged += PersonPropertyChanged;
			person.Id = 44;
			person.Name = "Jeff";

			Console.Out.WriteLine($"{person.Id}, {person.Name}");
			Console.Out.WriteLine();

			try
			{
				new ExpressedPerson(22, null);
			}
			catch(ArgumentNullException e)
			{
				Console.Out.WriteLine($"{nameof(ArgumentNullException)} - {e.ParamName}");
			}
		}
	}
}
