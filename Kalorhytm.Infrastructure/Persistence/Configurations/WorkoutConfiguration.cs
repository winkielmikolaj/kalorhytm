using Kalorhytm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<WorkoutEntity>
    {
        public void Configure(EntityTypeBuilder<WorkoutEntity> builder)
        {
            builder.ToTable("Workout");
            builder.HasKey(e => e.WorkoutId);
            builder.Property(e => e.WorkoutId).ValueGeneratedOnAdd();
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(e => e.DurationMinutes)
                .IsRequired();
            
            builder.Property(e => e.CaloriesBurned)
                .IsRequired();
            
            builder.Property(e => e.Date)
                .IsRequired();
            
            builder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);
        }
    }
}

