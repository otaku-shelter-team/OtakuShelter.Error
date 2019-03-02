using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Errors
{
	public static class ErrorsSwaggerExtensions
	{
		public static IServiceCollection AddErrorsSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info {Title = "OtakuShelter Errors API", Version = "v1"});

				options.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "JWT Authorization header",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});

				options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
				{
					["Bearer"] = Enumerable.Empty<string>()
				});
			});

			return services;
		}

		public static IApplicationBuilder UseErrorsSwagger(this IApplicationBuilder app)
		{
			return app.UseSwagger()
				.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Errors API v1");
					options.DocumentTitle = "OtakuShelter Errors API";
					options.DocExpansion(DocExpansion.List);
				});
		}
	}
}