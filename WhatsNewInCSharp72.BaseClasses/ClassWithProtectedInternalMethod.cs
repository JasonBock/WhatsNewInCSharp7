namespace WhatsNewInCSharp72.BaseClasses
{
	public abstract class ClassWithProtectedInternalMethod
		: ValueRetriever
	{
		protected internal virtual int GetValue() => 22;
	}
}
