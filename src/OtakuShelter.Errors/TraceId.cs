using System;
using System.Reflection;

namespace OtakuShelter.Errors
{
	public class TraceId
	{
		public string Id { get; set; }
		public DateTime Created { get; set; }
		public int ErrorId { get; set; }
		public Error Error { get; set; }
	}
}