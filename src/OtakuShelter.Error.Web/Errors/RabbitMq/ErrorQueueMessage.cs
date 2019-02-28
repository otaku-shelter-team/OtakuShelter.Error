using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Error
{
	[DataContract]
	public class ErrorQueueMessage
	{
		[DataMember(Name = "project")]
		public string Project { get; set; }
		
		[DataMember(Name = "type")]
		public string Type { get; set; }
		
		[DataMember(Name = "message")]
		public string Message { get; set; }
		
		[DataMember(Name = "stackTrace")]
		public string StackTrace { get; set; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; set; }
	}
}