using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Error
{
	public class Startup
	{
		private readonly ErrorWebConfiguration configuration;

		public Startup(IOptions<ErrorWebConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddDataServices(configuration.Database)
				.AddMvcServices(configuration.Roles)
				.AddAuthenticationServices(configuration)
				.AddSwaggerServices()
				.AddHealthServices(configuration.Database)
				.AddRabbitMqServices(configuration.RabbitMq)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();

			app.UseHealthChecks("/health");
			
			app.UseAuthentication();
			
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Error API v1");
				options.DocumentTitle = "OtakuShelter Error API";
				options.DocExpansion(DocExpansion.List);
			});
			
			app.UseMvc();
		}
	}
}