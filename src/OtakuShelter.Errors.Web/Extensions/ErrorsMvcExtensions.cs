using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Errors
{
	public static class ErrorsMvcExtensions
	{
		public static IServiceCollection AddErrorsMvc(
			this IServiceCollection services,
			ErrorsRoleConfiguration roles)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing => routing.AddErrorsController(roles)
					.AddVersionController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}