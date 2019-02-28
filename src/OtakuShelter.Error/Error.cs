using System;

namespace OtakuShelter.Error
{
	public class Error
	{
		public int Id { get; set; }
		public string Project { get; set; }
		public string Type { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public DateTime Created { get; set; }
	}
}