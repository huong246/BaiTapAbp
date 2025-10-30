using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BaiTapAbp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BaiTapAbpDbContextFactory : IDesignTimeDbContextFactory<BaiTapAbpDbContext>
{
    public BaiTapAbpDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        BaiTapAbpEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<BaiTapAbpDbContext>()
            .UseMySQL(configuration.GetConnectionString("Default"));
        
        return new BaiTapAbpDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BaiTapAbp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
