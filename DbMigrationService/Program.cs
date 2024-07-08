using DbMigrationService;
using Lib;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ApiDbInitializer>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
       .WithTracing(tracing => tracing.AddSource(ApiDbInitializer.ActivitySourceName));

// builder.Services.AddDbContextPool<MetalDbContext>(options =>
//                                                        options.UseNpgsql(builder.Configuration.GetConnectionString("db1"), sqlOptions =>
//                                                        {
//                                                               sqlOptions.MigrationsAssembly("DatabaseMigrations.MigrationService");
//                                                               // Workaround for https://github.com/dotnet/aspire/issues/1023
//                                                               sqlOptions.ExecutionStrategy(c => new RetryingExecutionStrategies(c));
//                                                        }));
// builder.EnrichNpgsqlDbContext<MetalDbContext>(settings =>
//                                                       // Disable Aspire default retries as we're using a custom execution strategy
//                                                       settings.DisableRetry = true);

builder.AddMetalDb();

var host = builder.Build();
host.Run();