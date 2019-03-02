using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Errors
{
	public static class ErrorsAuthenticationExtensions
	{
		public static IServiceCollection AddErrorsAuthentication(
			this IServiceCollection services,
			ErrorsJwtConfiguration configuration)
		{
			services.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = configuration.SymmetricSecurityKey,
						ValidateIssuer = true,
						ValidIssuer = configuration.Issuer,
						ValidateAudience = true,
						ValidAudience = configuration.Audience
					};
				});

			return services;
		}
	}
}