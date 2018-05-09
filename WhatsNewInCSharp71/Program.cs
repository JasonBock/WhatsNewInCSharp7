using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsNewInCSharp71
{
	public static class Program
	{
		//await Program.DoValueTaskAsync();
		//Program.ShowDefaultLiterals();
		//Program.ShowInferredTupleNames();
		//Program.ShowPatternMatchingWithGenerics();
		public static async Task Main(string[] args) =>
			await Program.DoValueTaskAsync();

		private static async Task DoValueTaskAsync()
		{
			ValueTask<int> ReturnValueAsync() =>
				new ValueTask<int>(22);

			Console.Out.WriteLine(await ReturnValueAsync());
			Console.Out.WriteLine(SynchronizationContext.Current == null);
		}

		private static void ShowDefaultLiterals()
		{
			int DoSomething(int x, string y) =>
				x == default && y == default ? default : 22;

			Console.Out.WriteLine(DoSomething(default, "data"));
			Console.Out.WriteLine(DoSomething(22, default));
			Console.Out.WriteLine(DoSomething(default, default));
			Console.Out.WriteLine(DoSomething(0, null));
		}

		private static void ShowInferredTupleNames()
		{
			var x = (id: 3, name: "name");
			var y = (x.id, x.name);
			Console.Out.WriteLine($"{y.id}, {y.name}");
		}

		private static void ShowPatternMatchingWithGenerics()
		{
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
