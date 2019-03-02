using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Errors
{
	public class Startup
	{
		private readonly ErrorsConfiguration configuration;

		public Startup(IOptions<ErrorsConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddErrorsSwagger()
				.AddErrorsExceptionHandling()
				.AddErrorsMvc(configuration.Roles)
				.AddErrorsDatabase(configuration.Database)
				.AddErrorsRabbitMq(configuration.RabbitMq)
				.AddErrorsAuthentication(configuration.Jwt)
				.AddErrorsHealthChecks(configuration.Database, configuration.RabbitMq)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();
			
			app.UseErrorsHealthchecks();
			app.UseAuthentication();
			app.UseErrorsSwagger();
			app.UseMvc();
		}
	}
}