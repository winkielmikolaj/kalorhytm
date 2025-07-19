using Kalorhytm.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorhytm.Infrastructure
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
            
        }

        public DbSet<FoodEntity> FoodEntities { get; set; }
        public DbSet<MealEntryEntity> MealEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodEntity>(entity =>
            {
                entity.HasKey(e => e.FoodId);
                entity.Property(e => e.FoodId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MealEntryEntity>(entity =>
            {
                entity.HasKey(e => e.MealEntryId);
                entity.Property(e => e.MealEntryId).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Food)
                      .WithMany()
                      .HasForeignKey(e => e.FoodId);
            });
        }
    }
}
