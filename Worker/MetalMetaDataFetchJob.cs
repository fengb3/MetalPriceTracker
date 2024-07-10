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

        // ��� ������е���һ����¼ (���� cache ��)�� �������λ�ȡ�����ظ� �򲻲���
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
        // ��� cache ��û�������������һ����¼�� ��ֱ�Ӽ�������û��
        else
        {
            //var lastOne = dbContext.Set<MetalMetaData>(code!).FirstOrDefault(m => m.Time >= metaData.Time);

            //if(lastOne != null)
            //{
            //    memoryCache.Set(memoryCacheKey, lastOne);
            //    return;
            //}

            // ʹ�� AnyAsync ����Ƿ�������������ļ�¼
            if (await dbContext.Set<MetalMetaData>(code!).AnyAsync(m => m.Time >= metaData.Time))
            {
                return;
            }
        }

        logger.LogInformation("Insert data to {code} - {time}", metaData.Code, DateTimeOffset.FromUnixTimeMilliseconds(metaData.Time));
        await dbContext.Set<MetalMetaData>(code!).AddAsync(metaData);

        // ���� cache���´β���ʱ ���
        memoryCache.Set(memoryCacheKey, metaData);
    }
}