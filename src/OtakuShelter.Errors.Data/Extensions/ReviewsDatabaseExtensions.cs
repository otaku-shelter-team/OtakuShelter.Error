using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Errors
{
	public static class ErrorsDatabaseExtensions
	{
		public static IServiceCollection AddErrorsDatabase(
			this IServiceCollection services,
			ErrorsDatabaseConfiguration configuration)
		{
			services.AddDbContextPool<ErrorsContext>(options =>
				options.UseNpgsql(configuration.ConnectionString, builder =>
						builder.MigrationsHistoryTable(configuration.MigrationsTable))
					.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning)));

			return services;
		}
	}
}