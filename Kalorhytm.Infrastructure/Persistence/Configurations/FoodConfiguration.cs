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
            builder.Property(e => e.FoodId).ValueGeneratedOnAdd();
        }
    }
}