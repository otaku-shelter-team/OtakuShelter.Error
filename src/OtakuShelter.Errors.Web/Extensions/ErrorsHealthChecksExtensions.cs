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
	}
}