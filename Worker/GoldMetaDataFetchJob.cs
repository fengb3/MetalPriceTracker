using Lib;
using Lib.Helper;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Worker;

public class GoldMetaDataFetchJob(
    GoldMetaDataWorkerClient      client,
    GoldDbContext                 dbContext,
    ILogger<GoldMetaDataFetchJob> logger) : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        logger.LogInformation("start Fetch Job");

        var result = client.FetchDataAsync().GetAwaiter().GetResult();

        if (result == null)
        {
            throw new NullReferenceException();
        }

        // await result.MetalMatas
        //             .Values
        //             .Select(SafeInsertAsync)
        //             .WhenAll();
        
        foreach (var metaData in result.MetalMatas.Values)
        {
            logger.LogInformation($"Safe insert data to {metaData.Code} - {metaData.Time}");
            SafeInsert(metaData);
            logger.LogInformation($"End insert data to {metaData.Code} - {metaData.Time}");

        }

        dbContext.SaveChanges();
        
        logger.LogInformation("{list}", dbContext.Set<MetalMetaData>("JO_9753").ToList().ToJsonString());
        
        logger.LogInformation("start Fetch Job");
        
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