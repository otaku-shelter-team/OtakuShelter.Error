using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Error
{
	public class ErrorWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public int MaxTokensCount { get; set; }

		public ErrorRoleConfiguration Roles { get; set; }
		public ErrorContextConfiguration Database { get; set; }
		public ErrorRabbitMqConfiguration RabbitMq { get; set; }

		public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
	}
}