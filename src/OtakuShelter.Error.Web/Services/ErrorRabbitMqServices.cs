using Microsoft.Extensions.DependencyInjection;
using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Error
{
	public static class ErrorRabbitMqServices
	{
		private const string ErrorsQueueName = "errors";
		
		public static IServiceCollection AddRabbitMqServices(
			this IServiceCollection services,
			ErrorRabbitMqConfiguration configuration)
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
				options.AddQueue(ErrorsQueueName)
					.Durable());
			
			builder.AddConsumers(options =>
					options.AddConsumer<ErrorQueueMessage, ErrorQueueMessageConsumer>(ErrorsQueueName)
						.WithTag($"{ErrorsQueueName}_consumer")
						.WithPrefetch(10)
						.WithConsumers(2));
			
			return services;
		}
	}
}