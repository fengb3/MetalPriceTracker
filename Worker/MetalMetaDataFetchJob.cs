using Lib;
using Lib.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client.Extensions.Msal;
using Quartz;

namespace Worker;

public class MetalMetaDataFetchJob(
    MetalMetaDataWorkerClient     client,
    MetalDbContext                dbContext,
    ILogger<MetalMetaDataFetchJob> logger, 
    IMemoryCache memoryCache) : IJob
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

        var memoryCacheKey = $"{code}";

        if (memoryCache.TryGetValue(memoryCacheKey, out var cachedMetaData))
        {
            if (cachedMetaData is MetalMetaData metalMetaData)
            {
                if (metaData.Time <= metalMetaData.Time)
                {
                    return;
                }
            }
        }

        dbContext.Set<MetalMetaData>(code!).Add(metaData);

        memoryCache.Set(memoryCacheKey, metaData);
    }

    private async Task SafeInsertAsync(MetalMetaData metaData)
    {
        var code = metaData.Code;

        Ensure.NotNull(code, nameof(code));

        var memoryCacheKey = $"{code}";

        // 检查 插入表中的上一条记录 (存在 cache 中)， 如果和这次获取到的重复 则不插入
        if (memoryCache.TryGetValue(memoryCacheKey, out var cachedMetaData))
        {
            if (cachedMetaData is MetalMetaData metalMetaData)
            {
                if (metaData.Time <= metalMetaData.Time)
                {
                    logger.LogInformation("Meta data for {code} at {time} already exists in cache, skip", code, DateTimeOffset.FromUnixTimeMilliseconds(metaData.Time));
                    return;
                }
            }
        }
        // 如果 cache 中没有这个表插入的上一条记录， 则直接检查表里有没有
        else
        {
            //var lastOne = dbContext.Set<MetalMetaData>(code!).FirstOrDefault(m => m.Time >= metaData.Time);

            //if(lastOne != null)
            //{
            //    memoryCache.Set(memoryCacheKey, lastOne);
            //    return;
            //}

            // 使用 AnyAsync 检查是否存在满足条件的记录
            if (await dbContext.Set<MetalMetaData>(code!).AnyAsync(m => m.Time >= metaData.Time))
            {
                return;
            }
        }

        logger.LogInformation("Insert data to {code} - {time}", metaData.Code, DateTimeOffset.FromUnixTimeMilliseconds(metaData.Time));
        await dbContext.Set<MetalMetaData>(code!).AddAsync(metaData);

        // 存入 cache，下次插入时 检查
        memoryCache.Set(memoryCacheKey, metaData);
    }
}