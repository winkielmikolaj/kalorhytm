using Kalorhytm.Domain;
using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Entities.FavouriteRecipes;
using Kalorhytm.Domain.Entities.MyFridge;
using Kalorhytm.Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace Kalorhytm.Infrastructure
{
    public class InMemoryDbContext : IdentityDbContext<ApplicationUser>
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {

        }

        public DbSet<FoodEntity> FoodEntities { get; set; }
        public DbSet<MealEntryEntity> MealEntries { get; set; }
        public DbSet<WaterIntakeEntity> WaterIntakes { get; set; }
        
        public DbSet<BodyMeasurementEntity> BodyMeasurements { get; set; }
        public DbSet<BodyMeasurementGoalEntity> BodyMeasurementGoals { get; set; }
        
        
        public DbSet<MyFridgeEntity> MyFridges { get; set; }
        
        
        public DbSet<FavouriteRecipesEntity>  FavouriteRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InMemoryDbContext).Assembly);
        }
    }
}
