using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Error
{
	[DataContract]
	public class AdminDeleteErrorByIdRequest
	{
		[DataMember(Name = "errorId")]
		public int ErrorId { get; set; }

		public async Task Delete(ErrorContext context)
		{
			var error = await context.Errors.FirstAsync(e => e.Id == ErrorId);

			context.Remove(error);
		}
	}
}