using Phema.Routing;

namespace OtakuShelter.Error
{
	public static class ErrorsControllerRoutes
	{
		public static IRoutingBuilder AddErrorsController(this IRoutingBuilder builder, ErrorRoleConfiguration roles)
		{
			builder.AddController<ErrorsController>(controller =>
			{
				controller.AddRoute("works", c => c.Works())
					.HttpGet();
			});
			
			return builder;
		}
	}
}