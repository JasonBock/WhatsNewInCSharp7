namespace WhatsNewInCSharp72.BaseClasses
{
	public sealed class ClassDerivingFromClassWithProtectedInternalMethod
		: ClassWithProtectedInternalMethod
	{
		protected internal override int GetValue() => 10;

		public override int Data => this.GetValue();
	}
}
