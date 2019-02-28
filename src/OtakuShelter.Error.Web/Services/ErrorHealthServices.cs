using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Error
{
	public static class ErrorHealthServices
	{
		public static IServiceCollection AddHealthServices(
			this IServiceCollection services,
			ErrorContextConfiguration database)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString);
				//.AddRabbitMQ();
			
			return services;
		}
	}
}