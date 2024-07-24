namespace Microsoft.Extensions.Logging;


public static partial class LogMessages
{
    [LoggerMessage(Message = "Sold {Quantity} of {Description}", Level = LogLevel.Information)]
    public static partial void LogProductSaleDetails(
        this ILogger logger,
        int          quantity,
        string       description);

    [LoggerMessage(Message = "MetadataFetchJob Started at {Time}", Level = LogLevel.Information)]
    public static partial void LogMetaDataFetchJobStart(this ILogger logger, DateTimeOffset time);

    [LoggerMessage(Message = "MetadataFetchJob End", Level = LogLevel.Information)]
    public static partial void LogMetaDataFetchJobEnd(this ILogger logger);
}