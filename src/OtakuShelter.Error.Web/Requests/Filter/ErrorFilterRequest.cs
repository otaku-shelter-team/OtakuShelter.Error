using System;

namespace OtakuShelter.Error
{
	public class ErrorFilterRequest
	{
		public string Project { get; set; }
		public string Type { get; set; }
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; } = 10;
	}
}