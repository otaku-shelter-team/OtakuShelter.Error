using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Errors
{
	[DataContract]
	public class AdminDeleteErrorByIdRequest
	{
		[DataMember(Name = "errorId")]
		public int ErrorId { get; set; }

		public async Task Delete(ErrorsContext context)
		{
			var error = await context.Errors.FirstAsync(e => e.Id == ErrorId);

			context.Remove(error);
		}
	}
}