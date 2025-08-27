using Kalorhytm.Domain.Entities.MyFridge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalorhytm.Infrastructure.Persistence.Configurations
{
    public class IngredientsConfiguration : IEntityTypeConfiguration<MyFridgeEntity>
    {
        public void Configure(EntityTypeBuilder<MyFridgeEntity> builder)
        {
            builder.ToTable("MyFridge");
            
            builder.HasKey(e => e.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}