using IdentityModel.Client;
using Lib;
using Lib.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client.Extensions.Msal;
using Quartz;

namespace Worker;

public class MetalMetaDataFetchJob(
    MetalMetaDataWorkerClient      client,
    MetalDbContext                 dbContext,
    ILogger<MetalMetaDataFetchJob> logger,
    IMemoryCache                   memoryCache) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var ct = context.CancellationToken;

        logger.LogMetaDataFetchJobStart(DateTimeOffset.Now);

        var result = await client.FetchDataAsync(ct);

        if (result == null)
        {
            throw new NullReferenceException("FetchDataAsync returned null");
        }

        var strategy = dbContext.Database.CreateExecutionStrategy();
        
        await strategy.ExecuteAsync(async () =>
        {
            await dbContext.Database.BeginTransactionAsync(ct);

            foreach (var metadata in result.MetalMetas.Values)
            {
                await SafeInsertAsync(metadata);
            }

            await dbContext.SaveChangesAsync(ct);

            await dbContext.Database.CommitTransactionAsync(ct);
        });
        

        logger.LogMetaDataFetchJobEnd();

        // logger.LogInformation("End");
        // }
    }

    private void SafeInsert(MetalMetadata metadata)
    {
        var code = metadata.Code;

        Ensure.NotNull(code, nameof(code));

        var memoryCacheKey = $"{code}";

        if (memoryCache.TryGetValue(memoryCacheKey, out var cachedMetaData))
        {
            if (cachedMetaData is MetalMetadata metalMetaData)
            {
                if (metadata.Time <= metalMetaData.Time)
                {
                    return;
                }
            }
        }

        dbContext.Set<MetalMetadata>(code!).Add(metadata);

        memoryCache.Set(memoryCacheKey, metadata);
    }

    private async Task SafeInsertAsync(MetalMetadata metadata)
    {
        var code = metadata.Code;

        Ensure.NotNull(code, nameof(code));

        var memoryCacheKey = $"{code}";

        // 检查 插入表中的上一条记录 (存在 cache 中)， 如果和这次获取到的重复 则不插入
        if (memoryCache.TryGetValue(memoryCacheKey, out var cachedObj))
        {
            if (cachedObj is MetalMetadata cachedMetadata)
            {
                if (metadata.Time <= cachedMetadata.Time)
                {
                    logger.LogInformation("Meta data for {code} at {time} already exists in cache, skip", code,
                                          DateTimeOffset.FromUnixTimeMilliseconds(metadata.Time));
                    return;
                }
            }
        }
        // 如果 cache 中没有这个表插入的上一条记录， 则直接检查表里有没有
        else
        {
            //var lastOne = dbContext.Set<MetalMetadata>(code!).FirstOrDefault(m => m.Time >= metadata.Time);

            //if(lastOne != null)
            //{
            //    memoryCache.Set(memoryCacheKey, lastOne);
            //    return;
            //}

            // 使用 AnyAsync 检查是否存在满足条件的记录
            if (await dbContext.Set<MetalMetadata>(code!).AnyAsync(m => m.Time >= metadata.Time))
            {
                return;
            }
        }

        logger.LogInformation("Insert data to {code} - {time}", metadata.Code,
                              DateTimeOffset.FromUnixTimeMilliseconds(metadata.Time));
        await dbContext.Set<MetalMetadata>(code!).AddAsync(metadata);

        // 存入 cache，下次插入时 检查
        memoryCache.Set(memoryCacheKey, metadata);
    }

    private void SafeInsert2Async(IQueryable queryable, MetalMetadata metadata)
    {
    }
}