using Microsoft.Extensions.Options;

namespace OtakuShelter.Errors
{
	public class VersionController
	{
		private readonly ErrorsConfiguration configuration;

		public VersionController(IOptions<ErrorsConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public ReadVersionResponse Version()
		{
			var response = new ReadVersionResponse();

			response.Read(configuration);

			return response;
		}
	}
}