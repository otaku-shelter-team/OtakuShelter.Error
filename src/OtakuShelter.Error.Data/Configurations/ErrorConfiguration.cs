using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Error.Configurations
{
	public class ErrorConfiguration : IEntityTypeConfiguration<Error>
	{
		public void Configure(EntityTypeBuilder<Error> builder)
		{
			builder.ToTable("errors");

			builder.Property(e => e.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();

			builder.Property(e => e.TraceId)
				.HasColumnName("trace_id")
				.IsRequired();

			builder.HasIndex(e => e.TraceId)
				.IsUnique()
				.HasName("UI_trace_id");
			
			builder.Property(e => e.Project)
				.HasColumnName("project")
				.HasMaxLength(25)
				.IsRequired();

			builder.Property(e => e.Type)
				.HasColumnName("type")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(e => e.Message)
				.HasColumnName("message")
				.IsRequired();

			builder.Property(e => e.StackTrace)
				.HasColumnName("stack_trace")
				.IsRequired();

			builder.Property(e => e.Created)
				.HasColumnName("created")
				.IsRequired();
		}
	}
}