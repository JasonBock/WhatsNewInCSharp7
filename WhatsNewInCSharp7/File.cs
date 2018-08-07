namespace WhatsNewInCSharp7
{
	public abstract class File
	{
		protected File(uint size)
			: base() => this.Size = size;

		public uint Size { get; }
	}
}
