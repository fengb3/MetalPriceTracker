using Lib;
using Lib.Helper;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Worker;

public class GoldMetaDataFetchJob(
    MetalMetaDataWorkerClient     client,
    MetalDbContext                dbContext,
    ILogger<GoldMetaDataFetchJob> logger) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        using (logger.BeginScope("GoldMetaDataFetchJob"))
        {
            logger.LogInformation("Start");

            var result = await client.FetchDataAsync();

            if (result == null)
            {
                throw new NullReferenceException("FetchDataAsync returned null");
            }

            foreach (var metaData in result.MetalMatas.Values)
            {
                logger.LogInformation($"Safe insert data to {metaData.Code} - {metaData.Time}");
                await SafeInsertAsync(metaData);
            }

            await dbContext.SaveChangesAsync();

            logger.LogInformation("End");
        }
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