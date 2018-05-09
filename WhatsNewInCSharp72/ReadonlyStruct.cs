namespace WhatsNewInCSharp72
{
	public readonly struct ReadonlyStruct
	{
		public ReadonlyStruct(int data) => this.Data = data;

		// This property definition doesn't work
		//public int Data { get; set; }
		public int Data { get; }
	}
}
