using System.Diagnostics;
using Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Worker;
using Xunit.Abstractions;

namespace Test;

public class MetalDbContextTests
{
	private readonly ITestOutputHelper _testOutputHelper;

	private MetalDbContext _dbContext;


	public MetalDbContextTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;

		var options = new DbContextOptionsBuilder<MetalDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDb")
			.Options;

		_dbContext = new MetalDbContext(options);
	}

	[Fact]
	public void SaveMetas_AddsJO_9753Entity()
	{
		// Arrange
		var options = new DbContextOptionsBuilder<MetalDbContext>()
			.UseInMemoryDatabase(databaseName: "TestDb") // Use a unique name for each test method
			.Options;

		// Act
		using (var context = new MetalDbContext(options))
		{
			var mata = new JO_9753
			{
				Code = "JO_9753"
			};
			context.Add(mata);
			context.SaveChanges();
		}

		// Assert
		using (var context = new MetalDbContext(options))
		{
			Assert.Equal(1, context.Set<MetalMetadata>("JO_9753").Count());
		}
	}

	[Fact]
	public async Task SaveMetas_Adds_All_Entity()
	{
		MetalMetaDataWorkerClient client = new(new HttpClient()
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
		}, new Logger<MetalMetaDataWorkerClient>(new LoggerFactory()));

		var result = await client.FetchDataAsync();

		var tasks = result?.MetalMetas
				.Values
				.Select(_dbContext.AddAsync)
			;

		Debug.Assert(tasks != null, nameof(tasks) + " != null");

		foreach (var task in tasks)
			await Task.Run(() => task);

		await _dbContext.SaveChangesAsync();
	}
}