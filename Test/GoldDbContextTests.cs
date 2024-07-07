using System.Diagnostics;
using Lib;
using Microsoft.EntityFrameworkCore;
using Worker;
using Xunit.Abstractions;

namespace Test;

public class GoldDbContextTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    private GoldDbContext _dbContext;


    public GoldDbContextTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        var options = new DbContextOptionsBuilder<GoldDbContext>()
                     .UseInMemoryDatabase(databaseName: "TestDb")
                     .Options;

        _dbContext = new GoldDbContext(options);
    }

    [Fact]
    public void SaveMetas_AddsJO_9753Entity()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<GoldDbContext>()
                     .UseInMemoryDatabase(databaseName: "TestDb") // Use a unique name for each test method
                     .Options;

        // Act
        using (var context = new GoldDbContext(options))
        {
            var mata = new JO_9753
            {
                Code = "JO_9753"
            };
            context.Add(mata);
            context.SaveChanges();
        }

        // Assert
        using (var context = new GoldDbContext(options))
        {
            Assert.Equal(1, context.Set<MetalMetaData>("JO_9753").Count());
        }
    }

    [Fact]
    public async Task SaveMetas_Adds_All_Entity()
    {
        GoldMetaDataWorkerClient client = new(new HttpClient()
        {
            BaseAddress = new Uri("https://api.jijinhao.com//"),
            DefaultRequestHeaders =
            {
                {
                    "User-Agent",
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36"
                },
                { "Accept-Encoding", "gzip, deflate, br" },
                { "Referer", "https://quote.cngold.org/" }
            }
        });

        var result = await client.FetchDataAsync();

        var tasks = result?.MetalMatas
                           .Values
                           .Select(_dbContext.AddAsync)
            ;

        Debug.Assert(tasks != null, nameof(tasks) + " != null");

        foreach (var task in tasks)
            await Task.Run(() => task);

        await _dbContext.SaveChangesAsync();
    }
}