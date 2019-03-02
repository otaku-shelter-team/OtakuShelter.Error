using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Phema.Configuration;

namespace OtakuShelter.Errors
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			await CreateWebHostBuilder()
				.Build()
				.RunAsync();
		}

		public static IWebHostBuilder CreateWebHostBuilder()
		{
			return new WebHostBuilder()
				.UseKestrel()
				.UseStartup<Startup>()
				.UseConfiguration(CreateConfiguration())
				.UsePhemaConfiguration<ErrorsConfiguration>()
				.ConfigureLogging((context, builder) =>
					builder.AddConsole()
						.SetMinimumLevel(LogLevel.Warning));
		}

		public static IConfiguration CreateConfiguration()
		{
			return new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddYamlFile("appsettings.yml")
				.AddEnvironmentVariables("OTAKUSHELTER:")
				.Build();
		}
	}
}