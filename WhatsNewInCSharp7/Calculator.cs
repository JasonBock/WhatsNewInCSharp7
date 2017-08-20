using System;

namespace WhatsNewInCSharp7
{
	public static class Calculator
	{
		public static CalculationResult CalculateWithDeconstructedType(int x, int y) =>
			new CalculationResult(x + y, Guid.NewGuid());

		public static (int, Guid) Calculate(int x, int y) => 
			(x + y, Guid.NewGuid());

		public static (int value, Guid id) CalculateWithNamedValues(int x, int y) => 
			(x + y, Guid.NewGuid());
	}
}
