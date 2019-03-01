using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Error
{
	public class TraceIdConfiguration : IEntityTypeConfiguration<TraceId>
	{
		public void Configure(EntityTypeBuilder<TraceId> builder)
		{
			builder.ToTable("trace_ids");

			builder.Property(t => t.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(t => t.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(t => t.ErrorId)
				.HasColumnName("error_id")
				.IsRequired();

			builder.HasOne(t => t.Error)
				.WithMany(e => e.TraceIds)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("FK_error_trace_ids");
		}
	}
}