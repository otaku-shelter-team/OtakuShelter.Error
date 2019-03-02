using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Errors
{
	public static class ErrorsMigrationsExtensions
	{
		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<ErrorsContext>()
					.Database
					.Migrate();
			}
		}
	}
}