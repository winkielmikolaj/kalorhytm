using Kalorhytm.Domain.Entities.BodyMeasurements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class BodyMeasurementConfiguration : IEntityTypeConfiguration<BodyMeasurementEntity>
    {
        public void Configure(EntityTypeBuilder<BodyMeasurementEntity> builder)
        {
            builder.ToTable("BodyMeasurements");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.Type)
                .IsRequired();

            builder.Property(b => b.Value)
                .IsRequired();

            builder.Property(b => b.MeasurementDate)
                .IsRequired();

            builder.HasIndex(b => new { b.UserId, b.Type, b.MeasurementDate });
        }
    }
}