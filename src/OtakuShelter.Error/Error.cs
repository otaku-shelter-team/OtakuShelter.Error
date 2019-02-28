using System;
using System.Collections.Generic;

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
		public DateTime? Updated { get; set; }

		public ICollection<TraceId> TraceIds { get; set; }
	}
}