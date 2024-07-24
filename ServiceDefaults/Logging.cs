using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;

namespace Microsoft.Extensions.Logging;

public static class LoggingExtension
{
    private static Logger Logger => new LoggerConfiguration()
                                   .Enrich.FromLogContext()
                                   .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
                                   .CreateLogger();

    public static ILoggingBuilder UseMyCustomizedLog(this IHostApplicationBuilder builder)
    {
        return builder.Logging
                      .ClearProviders()
                      .AddSerilog(Logger)
            ;
    }
}

// public class LoggingActionFilter : IActionFilter
// {
//     private readonly ILogger<LoggingActionFilter> _logger;
//
//     public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
//     {
//         _logger = logger;
//     }
//
//     public void OnActionExecuting(ActionExecutingContext context)
//     {
//         _logger.LogInformation($"Entering method {context.ActionDescriptor.DisplayName} with arguments {string.Join(", ", context.ActionArguments.Select(a => a.Key + "=" + a.Value))}");
//     }
//
//     public void OnActionExecuted(ActionExecutedContext context)
//     {
//         if (context.Exception == null)
//         {
//             _logger.LogInformation($"Exiting method {context.ActionDescriptor.DisplayName}");
//         }
//         else
//         {
//             _logger.LogError(context.Exception, $"Exception in method {context.ActionDescriptor.DisplayName}");
//         }
//     }
// }
//
// public static  class LoggingActionFilterExtension
// {
//     public static void Configure(this IServiceCollection services)
//     {
//         services.AddControllers(options =>
//         {
//             options.Filters.Add<LoggingActionFilter>();
//         });
//     }
// }