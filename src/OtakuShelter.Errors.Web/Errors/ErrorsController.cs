using System.Threading.Tasks;

using Npgsql;

namespace OtakuShelter.Errors
{
	public class ErrorsController
	{
		private readonly ErrorsContext context;

		public ErrorsController(ErrorsContext context)
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