using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kalorhytm.Infrastructure
{
    public class InMemoryDbContextFactory : IDesignTimeDbContextFactory<InMemoryDbContext>
    {
        public InMemoryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InMemoryDbContext>();
            
            // Use SQL Server for migrations (even though we use InMemory at runtime)
            // This connection string is only used for design-time migrations
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KalorhytmDb_Migrations;Trusted_Connection=true;TrustServerCertificate=true");
            
            return new InMemoryDbContext(optionsBuilder.Options);
        }
    }
}

