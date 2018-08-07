using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace WhatsNewInCSharp7
{
	[MemoryDiagnoser]
	public class LocalFunctionPerformance
	{
		[Params(5, 50, 500, 5000, 50000, 500000)]
		public uint Value { get; set; }

		[Benchmark]
		public int RunWithLocalFunctions()
		{
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

			return CollatzSequence(this.Value).Length;
		}

		[Benchmark(Baseline = true)]
		public int RunWithInlinedCode()
		{
			var sequence = new List<uint> { this.Value };

			var next = this.Value;

			while (next > 1)
			{
				next = next % 2 == 1 ? (3 * next + 1) / 2 : next / 2;
				sequence.Add(next);
			}

			return sequence.Count;
		}

		[Benchmark]
		public int RunWithPrivateFunctions() =>
			LocalFunctionPerformance.PrivateCollatzSequence(this.Value).Length;

		private static uint[] PrivateCollatzSequence(uint start)
		{
			var sequence = new List<uint> { start };

			var next = start;

			while (next > 1)
			{
				next = LocalFunctionPerformance.PrivateCollatz(next);
				sequence.Add(next);
			}

			return sequence.ToArray();
		}

		private static uint PrivateCollatz(uint value) =>
			value % 2 == 1 ? (3 * value + 1) / 2 : value / 2;
	}
}
