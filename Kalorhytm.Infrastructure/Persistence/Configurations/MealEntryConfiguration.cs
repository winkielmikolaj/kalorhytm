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
            
            builder.Property(e => e.FoodId)
                .IsRequired();
            
            builder.Property(e => e.Quantity)
                .IsRequired();
            
            builder.Property(e => e.Date)
                .IsRequired();
            
            builder.Property(e => e.MealType)
                .IsRequired();
            
            builder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);
            
            builder.HasOne(e => e.Food)
                .WithMany()
                .HasForeignKey(e => e.FoodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}