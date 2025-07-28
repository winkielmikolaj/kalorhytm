using Kalorhytm.Domain.Entities.BodyMeasurements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class BodyMeasurementGoalConfiguration : IEntityTypeConfiguration<BodyMeasurementGoalEntity>
    {
        public void Configure(EntityTypeBuilder<BodyMeasurementGoalEntity> builder)
        {
            builder.ToTable("BodyMeasurementGoals");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.UserId)
                .IsRequired();

            builder.Property(g => g.Type)
                .IsRequired();

            builder.Property(g => g.TargetValue)
                .IsRequired();

            builder.Property(g => g.EffectiveFrom)
                .IsRequired();

            builder.HasIndex(g => new { g.UserId, g.Type, g.EffectiveFrom });
        }
    }
}