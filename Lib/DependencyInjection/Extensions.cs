using Lib;
using Lib.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Hosting;

public static class Extensions
{
    public static void AddMetalDb(this IHostApplicationBuilder builder)
    {
        var connStringSection = Environment.GetEnvironmentVariable("CONNECTION_STRING_SECTION");

        Console.WriteLine(connStringSection ?? "Connection string Section is not defined");
        
        Ensure.NotNullOrEmpty(connStringSection, nameof(connStringSection));
        
        builder.Services.AddDbContext<MetalDbContext>(options =>
        {
            // options.UseInMemoryDatabase(databaseName: "testDb");

            Console.WriteLine(builder.Configuration.GetConnectionString(connStringSection));

            options.UseNpgsql(builder.Configuration.GetConnectionString(connStringSection), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("DbMigrationService");
                // Workaround for https://github.com/dotnet/aspire/issues/1023
                sqlOptions.ExecutionStrategy(c => new RetryingExecutionStrategies(c));
            });
        });
        
        builder.EnrichNpgsqlDbContext<MetalDbContext>(settings =>
        {
            // Disable Aspire default retries as we're using a custom execution strategy
            settings.DisableRetry = true;
        });
    }
}