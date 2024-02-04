using AirlineCompanyAPI.Data.Relational.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirlineCompanyAPI.Data.Relational.Contexts
{
    public class AirlineCompanyDbContext(IConfiguration configuration) : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string? connectionEnv = configuration.GetSection("DatabaseConnections").GetSection("RelationalEnv").Value;
            string? connectionString = configuration.GetConnectionString(connectionEnv ?? "");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new EnvironmentVariableNotFoundException("Relational database connection string not found");
            }

            if (!dbContextOptionsBuilder.IsConfigured)
            {
                // connect to postgres with connection string from app settings
                dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString(connectionString));
            }
        }
    }
}
