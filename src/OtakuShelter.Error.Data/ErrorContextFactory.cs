using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace OtakuShelter.Error
{
	public class AccountContextFactory : IDesignTimeDbContextFactory<ErrorContext>
	{
		public ErrorContext CreateDbContext(string[] args)
		{
			var configurationBuilder = new ConfigurationBuilder();
			ConfigureBuilder(configurationBuilder, Directory.GetCurrentDirectory());
			var configuration = configurationBuilder.Build();
			
			var database = configuration.GetSection("database").Get<ErrorContextConfiguration>();

			var options = new DbContextOptionsBuilder<ErrorContext>();
			ConfigureContext(options, database);
			
			return new ErrorContext(options.Options);
		}

		public static void ConfigureBuilder(IConfigurationBuilder builder, string path)
		{
			builder.SetBasePath(path)
				.AddYamlFile("appsettings.yml")
				.AddEnvironmentVariables("OTAKUSHELTER:");
		}

		public static void ConfigureContext(DbContextOptionsBuilder options, ErrorContextConfiguration accountContext)
		{
			options.UseNpgsql(accountContext.ConnectionString, 
					builder => builder.MigrationsHistoryTable(accountContext.MigrationsTable))
				.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning));
		}
	}
}