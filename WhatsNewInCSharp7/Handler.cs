using System;

namespace WhatsNewInCSharp7
{
	public class Handler
		: IHandle, IHandleWithValues<(string x, string y)>,
		IHandleWithValues<(string, int, Guid)>
	{
		public void Handle()
		{
			Console.Out.WriteLine($"{nameof(this.Handle)}");
		}

		public void Handle((string, int, Guid) values)
		{
			Console.Out.WriteLine($"{nameof(this.Handle)} : {values.Item2}");
		}

		public void Handle((string x, string y) values)
		{
			Console.Out.WriteLine($"{nameof(this.Handle)} : {values.y}");
		}
	}
}
