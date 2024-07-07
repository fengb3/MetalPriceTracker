using Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Hosting;

public static class Extensions
{
    public static void AddMetalDb(this IHostApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        Console.WriteLine(connectionString ?? "Connection string is not defined");
        
        builder.Services.AddDbContext<GoldDbContext>(options =>
        {
            // options.UseInMemoryDatabase(databaseName: "testDb");
            options.UseNpgsql(builder.Configuration.GetConnectionString(connectionString), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("DbMigrationService");
                // Workaround for https://github.com/dotnet/aspire/issues/1023
                sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
            });
        });
        
        builder.EnrichNpgsqlDbContext<GoldDbContext>(settings =>
        {
            // Disable Aspire default retries as we're using a custom execution strategy
            settings.DisableRetry = true;
        });
    }
}