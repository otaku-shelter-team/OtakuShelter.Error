using Microsoft.EntityFrameworkCore;

using OtakuShelter.Error.Configurations;

using Phema.Routing;

namespace OtakuShelter.Error
{
	public static class ErrorsControllerRoutes
	{
		public static IRoutingBuilder AddErrorsController(this IRoutingBuilder builder, ErrorRoleConfiguration roles)
		{
			builder.AddController<ErrorsController>(controller =>
			{
				controller.AddRoute("admin/errors", c => c.AdminRead(From.Query<ErrorFilterRequest>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/errors/{errorId}", c => c.DeleteById(From.Route<AdminDeleteErrorByIdRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}