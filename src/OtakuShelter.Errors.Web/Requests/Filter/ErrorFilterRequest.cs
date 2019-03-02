using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Errors
{
	[DataContract]
	public class ErrorFilterRequest
	{
		[DataMember(Name = "traceId")]
		public string TraceId { get; set; }
		
		[DataMember(Name = "project")]
		public string Project { get; set; }
		
		[DataMember(Name = "type")]
		public string Type { get; set; }
		
		[DataMember(Name = "from")]
		public DateTime? From { get; set; }
		
		[DataMember(Name = "to")]
		public DateTime? To { get; set; }
		
		[DataMember(Name = "offset")]
		public int Offset { get; set; }
		
		[DataMember(Name = "limit")]
		public int Limit { get; set; } = 10;
	}
}