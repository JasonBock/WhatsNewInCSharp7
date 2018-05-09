namespace WhatsNewInCSharp72.BaseClasses
{
	public abstract class ClassWithPrivateProtectedMethod
		: ValueRetriever
	{
		private protected virtual int GetValue() => 22;
	}
}
