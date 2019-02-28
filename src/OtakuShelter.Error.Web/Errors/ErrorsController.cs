using System.Threading.Tasks;

using Npgsql;

namespace OtakuShelter.Error
{
	public class ErrorsController
	{
		private readonly ErrorContext context;

		public ErrorsController(ErrorContext context)
		{
			this.context = context;
		}

		public async ValueTask<AdminReadErrorsResponse> AdminRead(ErrorFilterRequest filter)
		{
			var response = new AdminReadErrorsResponse();

			await response.Read(context, filter);

			return response;
		}

		public async ValueTask DeleteById(AdminDeleteErrorByIdRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}