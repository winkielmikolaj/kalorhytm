using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Entities.FavouriteRecipes;
using Kalorhytm.Domain.Entities.MyFridge;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<FoodEntity> FoodEntities { get; set; }
        public DbSet<MealEntryEntity> MealEntries { get; set; }
        public DbSet<WaterIntakeEntity> WaterIntakes { get; set; }
        public DbSet<WorkoutEntity> Workouts { get; set; }
        
        public DbSet<BodyMeasurementEntity> BodyMeasurements { get; set; }
        public DbSet<BodyMeasurementGoalEntity> BodyMeasurementGoals { get; set; }
        
        
        public DbSet<MyFridgeEntity> MyFridges { get; set; }
        
        
        public DbSet<FavouriteRecipesEntity>  FavouriteRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
} 