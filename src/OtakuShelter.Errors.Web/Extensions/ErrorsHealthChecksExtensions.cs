using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Errors
{
	public static class ErrorsHealthChecksExtensions
	{
		public static IServiceCollection AddErrorsHealthChecks(
			this IServiceCollection services,
			ErrorsDatabaseConfiguration database,
			ErrorsRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);
			
			return services;
		}
		
		public static IApplicationBuilder UseErrorsHealthchecks(this IApplicationBuilder app)
		{
			return app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		}
	}
}