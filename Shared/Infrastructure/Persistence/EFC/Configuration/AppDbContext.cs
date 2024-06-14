
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pc2_202401.insurance.domain.model.aggregates;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration
        builder.Entity<Policy>().HasKey(c=>c.Id);
        builder.Entity<Policy>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<Policy>().Property(c=>c.Customer).IsRequired();
        builder.Entity<Policy>().Property(c=>c.Productid).IsRequired();
        builder.Entity<Policy>().Property(c=>c.Address).IsRequired();
        builder.Entity<Policy>().Property(c=>c.Dni).IsRequired();
        builder.Entity<Policy>().Property(c=>c.Age).IsRequired();
        
        
       
        
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}