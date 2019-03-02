using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Errors
{
	public class ErrorsContext : DbContext
	{
		public ErrorsContext(DbContextOptions<ErrorsContext> options) : base(options)
		{
		}

		public DbSet<Error> Errors { get; set; }
		public DbSet<TraceId> TraceIds { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ErrorConfiguration());
			modelBuilder.ApplyConfiguration(new TraceIdConfiguration());
		}
	}
}