namespace WhatsNewInCSharp7
{
	public struct HugeData
	{
		private int[] values;

		public HugeData(int size)
		{
			this.values = new int[size];
		}

		public int GetSize() => this.values.Length;
	}
}
