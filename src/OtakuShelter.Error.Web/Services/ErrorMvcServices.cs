using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Error
{
	public static class ErrorMvcServices
	{
		public static IServiceCollection AddMvcServices(
			this IServiceCollection services,
			ErrorRoleConfiguration roles)
		{
			services
				.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing =>
					routing.AddErrorsController(roles))
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}