using Kalorhytm.Domain;
using Kalorhytm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<FoodEntity>
    {
        public void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
            builder.ToTable("Food");
            builder.HasKey(e => e.FoodId);
            // FoodId comes from external API (Spoonacular), so it should not be auto-generated
            builder.Property(e => e.FoodId).ValueGeneratedNever();
        }
    }
}