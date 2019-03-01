using System;
using System.Reflection;

namespace OtakuShelter.Error
{
	public class TraceId
	{
		public string Id { get; set; }
		public DateTime Created { get; set; }
		public int ErrorId { get; set; }
		public Error Error { get; set; }
	}
}