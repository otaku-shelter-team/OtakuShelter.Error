using Microsoft.Extensions.DependencyInjection;

using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Errors
{
	public static class ErrorsRabbitMqExtensions
	{
		public static IServiceCollection AddErrorsRabbitMq(
			this IServiceCollection services,
			ErrorsRabbitMqConfiguration configuration)
		{
			services.AddPhemaJsonSerializer();
			
			var builder = services.AddPhemaRabbitMq(configuration.InstanceName,
				options =>
				{
					options.UserName = configuration.Username;
					options.Password = configuration.Password;
					options.Port = configuration.Port;
					options.HostName = configuration.Hostname;
					options.VirtualHost = configuration.VirtualHost;
				});
			
			builder.AddQueues(options => 
				options.AddQueue("errors")
					.Durable());
			
			builder.AddProducers(options =>
				options.AddProducer<ErrorsExceptionPayload>("amq.direct", "errors")
					.Mandatory());
			
			builder.AddConsumers(options =>
				options.AddConsumer<ErrorsExceptionPayload, ErrorsExceptionPayloadConsumer>("errors")
					.WithTag("errors_consumer")
					.WithPrefetch(10)
					.WithConsumers(2));
			
			return services;
		}
	}
}