using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using Phema.Configuration;

namespace OtakuShelter.Error
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var app = new WebHostBuilder()
				.UseKestrel()
				.UseWebRoot(Directory.GetCurrentDirectory())
				.ConfigureAppConfiguration((context, builder) =>
					AccountContextFactory.ConfigureBuilder(builder, context.HostingEnvironment.WebRootPath))
				.ConfigureLogging((context, builder) =>
					builder.AddConsole()
						.SetMinimumLevel(LogLevel.Warning))
				.UseStartup<Startup>()
				.UsePhemaConfiguration<ErrorWebConfiguration>()
				.Build();

			await app.RunAsync();
		}
	}
}