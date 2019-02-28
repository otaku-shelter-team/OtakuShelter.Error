using System.Reflection;

namespace OtakuShelter.Error
{
	public class TraceId
	{
		public string Id { get; set; }
		public int ErrorId { get; set; }
		public Error Error { get; set; }
	}
}