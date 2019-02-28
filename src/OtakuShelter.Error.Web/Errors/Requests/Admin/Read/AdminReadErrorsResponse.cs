using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Error
{
	[DataContract]
	public class AdminReadErrorsResponse
	{
		[DataMember(Name = "errors")]
		public ICollection<ReadErrorsRequestItem> Errors { get; set; }

		public async ValueTask Read(ErrorContext context, ErrorFilterRequest filter)
		{
			var errors = context.Errors.AsNoTracking();

			if (filter.TraceId != null)
			{
				var traceId = await context.TraceIds.FirstAsync(t => t.Id == filter.TraceId);
				
				errors = errors.Where(e => e.Id == traceId.ErrorId);
			}
			
			if (filter.Project != null)
			{
				errors = errors.Where(e => e.Project == filter.Project);
			}

			if (filter.Type != null)
			{
				errors = errors.Where(e => e.Type == filter.Type);
			}

			if (filter.From != null)
			{
				errors = errors.Where(e => e.Created >= filter.From);
			}

			if (filter.To != null)
			{
				errors = errors.Where(e => e.Created <= filter.To);
			}

			Errors = await errors
				.OrderByDescending(e => e.Created)
				.Skip(filter.Offset)
				.Take(filter.Limit)
				.Select(error => new { Error = error, Count = error.TraceIds.Count})
				.Select(result => new ReadErrorsRequestItem(result.Error, result.Count))
				.ToListAsync();
		}
	}
}