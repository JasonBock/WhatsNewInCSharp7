using System;

namespace WhatsNewInCSharp73
{
	[Serializable]
	public sealed class SerializableData
	{
		public Guid Id { get; set; }
		[field: NonSerialized]
		public string SSN { get; set; }
	}
}
