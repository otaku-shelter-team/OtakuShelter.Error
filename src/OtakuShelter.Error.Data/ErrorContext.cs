using Microsoft.EntityFrameworkCore;

using OtakuShelter.Error.Configurations;

namespace OtakuShelter.Error
{
	public class ErrorContext : DbContext
	{
		public ErrorContext(DbContextOptions<ErrorContext> options) : base(options)
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