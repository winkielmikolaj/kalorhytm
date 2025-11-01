using Kalorhytm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class WaterIntakeConfiguration : IEntityTypeConfiguration<WaterIntakeEntity>
    {
        public void Configure(EntityTypeBuilder<WaterIntakeEntity> builder)
        {
            builder.ToTable("WaterIntake");
            builder.HasKey(e => e.WaterIntakeId);
            builder.Property(e => e.WaterIntakeId).ValueGeneratedOnAdd();
            
            builder.Property(e => e.Date)
                .IsRequired();
            
            builder.Property(e => e.GlassNumber)
                .IsRequired();
            
            builder.Property(e => e.Amount)
                .IsRequired()
                .HasDefaultValue(250.0);
        }
    }
}

