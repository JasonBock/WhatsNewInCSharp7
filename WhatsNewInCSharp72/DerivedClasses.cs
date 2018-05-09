using WhatsNewInCSharp72.BaseClasses;

namespace WhatsNewInCSharp72
{
	public sealed class MyClassDerivingFromClassWithProtectedInternalMethod
		: ClassWithProtectedInternalMethod
	{
		protected override int GetValue() => 30;

		public override int Data => this.GetValue();
	}

	public sealed class MyClassDerivingFromClassWithPrivateProtectedMethod
		: ClassWithPrivateProtectedMethod
	{
		// Can't override GetValue() here.

		public override int Data => int.MinValue;
	}
}
