using Kalorhytm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class MealEntryConfiguration : IEntityTypeConfiguration<MealEntryEntity>
    {
        public void Configure(EntityTypeBuilder<MealEntryEntity> builder)
        {
            builder.ToTable("MealEntry");
            builder.HasKey(e => e.MealEntryId);
            builder.Property(e => e.MealEntryId).ValueGeneratedOnAdd();
            builder.HasOne(e => e.Food)
                .WithMany()
                .HasForeignKey(e => e.FoodId);
        }
    }
}