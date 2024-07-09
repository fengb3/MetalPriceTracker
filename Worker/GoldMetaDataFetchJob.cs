using Lib;
using Lib.Helper;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Worker;

public class GoldMetaDataFetchJob(
    MetalMetaDataWorkerClient      client,
    MetalDbContext                 dbContext,
    ILogger<GoldMetaDataFetchJob> logger) : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        using ( var loggingScope = logger.BeginScope("GoldMetaDataFetchJob"))
        {
            logger.LogInformation("Start");

            var result = client.FetchDataAsync().GetAwaiter().GetResult();

            if (result == null)
            {
                throw new NullReferenceException();
            }

            foreach (var metaData in result.MetalMatas.Values)
            {
                logger.LogInformation("Safe insert data to {code} - {time}", metaData.Code, metaData.Time);
                SafeInsert(metaData);
            }

            dbContext.SaveChanges();

            logger.LogInformation("End");
        }


        return Task.CompletedTask;
    }


    private void SafeInsert(MetalMetaData metaData)
    {
        var code = metaData.Code;
        
        Ensure.NotNull(code, nameof(code));
        
        if (dbContext.Set<MetalMetaData>(code!).Any(m => m.Time == metaData.Time))
        {
            return;
        }

        dbContext.Set<MetalMetaData>(code!).Add(metaData);
    }
    
    private async Task SafeInsertAsync(MetalMetaData metaData)
    {
        var code = metaData.Code;
        
        Ensure.NotNull(code, nameof(code));
        
        if (await dbContext.Set<MetalMetaData>(code!).AnyAsync(m => m.Time == metaData.Time))
        {
            return;
        }

        await dbContext.Set<MetalMetaData>(code!).AddAsync(metaData);
    }
}