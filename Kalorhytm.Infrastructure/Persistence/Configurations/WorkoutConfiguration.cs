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
        }
    }
}

