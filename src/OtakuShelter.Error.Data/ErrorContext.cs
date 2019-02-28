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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ErrorConfiguration());
		}
	}
}