using AuthServer.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AuthServer.Data.Context;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthServer.Data.Context
{
    /// <summary>
    /// DbContext yerine IdentityDbContext den kalıtım alındı
    /// </summary>
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
    }
}

public class MyDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("SqlServer");
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);

    }
}