using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Errors
{
	public class ErrorsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ErrorsContext>
	{
		public ErrorsContext CreateDbContext(string[] args)
		{
			return new ServiceCollection()
				.AddErrorsDatabase(new ErrorsDatabaseConfiguration())
				.BuildServiceProvider()
				.GetRequiredService<ErrorsContext>();
		}
	}
}