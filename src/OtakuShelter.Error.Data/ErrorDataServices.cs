using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Error
{
	public static class ErrorDataServices
	{
		public static IServiceCollection AddDataServices(
			this IServiceCollection services,
			ErrorContextConfiguration accountContext)
		{
			services.AddDbContextPool<ErrorContext>(builder =>
				AccountContextFactory.ConfigureContext(builder, accountContext));
			
			return services;
		}
	}
}