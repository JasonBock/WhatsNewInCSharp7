using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsNewInCSharp71
{
	public static class Program
	{
		//public static async Task Main() =>
		//	await Program.DoValueTaskAsync();

		//Program.ShowDefaultLiterals();
		//Program.ShowInferredTupleNames();
		//Program.ShowPatternMatchingWithGenerics();
		public static void Main() =>
			Program.ShowInferredTupleNames();

		private static async Task DoValueTaskAsync()
		{
			Console.Out.WriteLine($"{nameof(Program.DoValueTaskAsync)}");
			Console.Out.WriteLine();

			ValueTask<int> ReturnValueAsync() => new ValueTask<int>(22);

			Console.Out.WriteLine(await ReturnValueAsync());
			Console.Out.WriteLine(SynchronizationContext.Current == null);
		}

		private static void ShowDefaultLiterals()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowDefaultLiterals)}");
			Console.Out.WriteLine();

			int DoSomething(int x, string y) =>
				x == default && y == default ? default : 22;

			Console.Out.WriteLine(DoSomething(default, "data"));
			Console.Out.WriteLine(DoSomething(22, default));
			Console.Out.WriteLine(DoSomething(default, default));
			Console.Out.WriteLine(DoSomething(0, null));
		}

		private static void ShowInferredTupleNames()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowInferredTupleNames)}");
			Console.Out.WriteLine();

			var x = (id: 3, name: "name");
			var y = (x.id, x.name);
			Console.Out.WriteLine($"{y.id}, {y.name}");
		}

		private static void ShowPatternMatchingWithGenerics()
		{
			Console.Out.WriteLine($"{nameof(Program.ShowPatternMatchingWithGenerics)}");
			Console.Out.WriteLine();

			void HandleThing<T>(T thing) where T : Thing
			{
				if (thing is SomeThing someThing)
				{
					Console.Out.WriteLine($"It's {someThing.GetType().Name}");
				}
				else if (thing is AnotherThing anotherThing)
				{
					Console.Out.WriteLine($"It's {anotherThing.GetType().Name}");
				}
				else
				{
					Console.Out.WriteLine($"Unknown {nameof(Thing)}");
				}
			}

			HandleThing(new SomeThing());
			HandleThing(new AnotherThing());
			HandleThing(new SneakyThing());
		}
	}
}
