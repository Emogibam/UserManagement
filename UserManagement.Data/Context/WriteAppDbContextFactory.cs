using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO; // Ensure this namespace is included

namespace UserManagement.Infrastructure.Context
{
    public class WriteAppDbContextFactory : IDesignTimeDbContextFactory<WriteAppDbContext>
    {
        public WriteAppDbContext CreateDbContext(string[] args)
        {
            // Build configuration explicitly for design-time context
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set to the directory containing appsettings.json
                .AddJsonFile("appsettings.json") // Load appsettings.json
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("WriteConnection");

            // Configure DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<WriteAppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new WriteAppDbContext(optionsBuilder.Options);
        }
    }
}
