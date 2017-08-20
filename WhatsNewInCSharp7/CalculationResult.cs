using System;

namespace WhatsNewInCSharp7
{
	public sealed class CalculationResult
	{
		public CalculationResult(int result, Guid id)
		{
			this.Result = result;
			this.Id = id;
		}

		public void Deconstruct(out int result, out Guid id)
		{
			result = this.Result;
			id = this.Id;
		}

		public Guid Id { get; }
		public int Result { get; }
	}
}
