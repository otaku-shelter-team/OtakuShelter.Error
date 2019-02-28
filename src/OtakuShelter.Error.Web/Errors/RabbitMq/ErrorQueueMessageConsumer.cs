using System.Threading.Tasks;
using Phema.RabbitMq;

namespace OtakuShelter.Error
{
	public class ErrorQueueMessageConsumer : IRabbitMqConsumer<ErrorQueueMessage>
	{
		private readonly ErrorContext context;

		public ErrorQueueMessageConsumer(ErrorContext context)
		{
			this.context = context;
		}
		
		public async ValueTask Consume(ErrorQueueMessage payload)
		{
			var error = new Error
			{
				TraceId = payload.TraceId,
				Project = payload.Project,
				Type = payload.Type,
				Message = payload.Message,
				StackTrace = payload.StackTrace,
				Created = payload.Created
			};

			await context.Errors.AddAsync(error);

			await context.SaveChangesAsync();
		}
	}
}