using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Npgsql;

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
			var error = await context.Errors.FirstOrDefaultAsync(e =>
				e.Project == payload.Project
				&& e.Type == payload.Type
				&& e.Message == payload.Message
				&& e.StackTrace == payload.StackTrace);
			
			if (error == null)
			{
				error = new Error
				{
					Project = payload.Project,
					Type = payload.Type,
					Message = payload.Message,
					StackTrace = payload.StackTrace,
					Created = payload.Created
				};

				await context.Errors.AddAsync(error);
			}
			
			var traceId = new TraceId
			{
				Id = payload.TraceId,
				Created = payload.Created,
				Error = error
			};

			await context.TraceIds.AddAsync(traceId);
			
			await context.SaveChangesAsync();
		}
	}
}