using System.Collections.Concurrent;
using System.Text.Json;
using Lib;
using Xunit.Abstractions;

namespace Test;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Test1()
    {
        var concurrentDictionary = new ConcurrentDictionary<string, GoldResponseDto>();

        var taskList = new List<Task>();
        
        var startTime = DateTimeOffset.Now.AddHours(-7).AddDays(-1);
        
        _testOutputHelper.WriteLine(startTime.ToString());

        for (var i = 0; i < 5; i++)
        {
            var i1 = i;

            {
                var time = startTime.AddDays(i1 * -7);
                var res = await new GoldRequest()
                               .WithCodes("JO_9754")
                               .WithTime(time)
                               .Send()
                    ;

                if (res is null)
                {
                    continue;
                }
                
                concurrentDictionary.TryAdd(time.ToString(), res);

                _testOutputHelper.WriteLine($"{time} - {JsonSerializer.Serialize(res["JO_70"])}\n");
            }
        }
    }
}