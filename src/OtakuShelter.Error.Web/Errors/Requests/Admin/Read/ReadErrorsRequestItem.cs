using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Error
{
	[DataContract]
	public class ReadErrorsRequestItem
	{
		public ReadErrorsRequestItem(Error error)
		{
			Id = error.Id;
			Project = error.Project;
			Type = error.Type;
			Message = error.Message;
			StackTrace = error.StackTrace;
			Created = error.Created;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
		
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