using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Errors
{
	public class ErrorsExceptionHandler : IExceptionHandler<Exception>
	{
		private readonly IHttpContextAccessor accessor;
		private readonly IRabbitMqProducer<ErrorsExceptionPayload> producer;
		private readonly ErrorsConfiguration configuration;

		public ErrorsExceptionHandler(
			IRabbitMqProducer<ErrorsExceptionPayload> producer,
			IOptions<ErrorsConfiguration> configuration,
			IHttpContextAccessor accessor)
		{
			this.producer = producer;
			this.configuration = configuration.Value;
			this.accessor = accessor;
		}
		
		public async ValueTask<IActionResult> Handle(Exception exception)
		{
			var message = new ErrorsExceptionPayload
			{
				TraceId = accessor.HttpContext.TraceIdentifier,
				Type = exception.GetType().ToString(),
				Project = configuration.Name,
				Message = exception.Message,
				StackTrace = exception.StackTrace,
				Created = DateTime.UtcNow
			};

			await producer.Produce(message);
			
			return new BadRequestObjectResult(new {traceId = message.TraceId});
		}
	}
}