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
        var connStringSection = Environment.GetEnvironmentVariable("ConnectionStringSection");

        Console.WriteLine(connStringSection ?? "Connection string is not defined");
        
        builder.Services.AddDbContext<GoldDbContext>(options =>
        {
            // options.UseInMemoryDatabase(databaseName: "testDb");

            Console.WriteLine(builder.Configuration.GetConnectionString(connStringSection));

            options.UseNpgsql(builder.Configuration.GetConnectionString(connStringSection), sqlOptions =>
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