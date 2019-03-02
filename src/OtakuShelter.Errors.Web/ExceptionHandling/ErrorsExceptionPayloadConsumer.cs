using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Npgsql;

using Phema.RabbitMq;

namespace OtakuShelter.Errors
{
	public class ErrorsExceptionPayloadConsumer : IRabbitMqConsumer<ErrorsExceptionPayload>
	{
		private readonly ErrorsContext context;

		public ErrorsExceptionPayloadConsumer(ErrorsContext context)
		{
			this.context = context;
		}
		
		public async ValueTask Consume(ErrorsExceptionPayload payload)
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