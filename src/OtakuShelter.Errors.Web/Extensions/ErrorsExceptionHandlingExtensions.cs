using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Errors
{
	public static class ErrorsExceptionHandlingExtensions
	{
		public static IServiceCollection AddErrorsExceptionHandling(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
					options.AddExceptionHandler<Exception, ErrorsExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}