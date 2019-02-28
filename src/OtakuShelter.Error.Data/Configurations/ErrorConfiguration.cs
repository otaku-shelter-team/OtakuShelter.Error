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

			builder.HasIndex(e => new {e.Project, e.Type, e.Message})
				.IsUnique()
				.HasName("UI_project_type_message");

			builder.Property(e => e.StackTrace)
				.HasColumnName("stack_trace")
				.IsRequired();

			builder.Property(e => e.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(e => e.Updated)
				.HasColumnName("updated");
		}
	}
}