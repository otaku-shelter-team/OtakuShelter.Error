using System.Runtime.Serialization;

namespace OtakuShelter.Errors
{
	[DataContract]
	public class ReadVersionResponse
	{
		[DataMember(Name = "version")]
		public string Version { get; set; }

		public void Read(ErrorsConfiguration configuration)
		{
			Version = configuration.Version;
		}
	}
}