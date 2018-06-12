namespace WhatsNewInCSharp72.BaseClasses
{
	public abstract class ClassWithPrivateProtectedMethod
		: ValueRetriever
	{
		// " A private protected member is accessible by types 
		// derived from the containing class, 
		// but only within its containing assembly."
		// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private-protected
		private protected virtual int GetValue() => 22;
	}
}
