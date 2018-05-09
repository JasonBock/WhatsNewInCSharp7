namespace WhatsNewInCSharp72.BaseClasses
{
	public sealed class ClassDerivingFromClassWithPrivateProtectedMethod
		: ClassWithPrivateProtectedMethod
	{
		private protected override int GetValue() => 20;

		public override int Data => this.GetValue();
	}
}
