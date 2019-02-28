using Phema.Configuration;

namespace OtakuShelter.Error
{
	[Configuration]
	public class ErrorRoleConfiguration
	{
		public string Admin { get; set; }
		public string User { get; set; }

		public bool IsAny(string role) => role == Admin || role == User;
	}
}