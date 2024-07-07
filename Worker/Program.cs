using Quartz;
using Quartz.AspNetCore;
using Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddHttpClient<GoldMetaDataWorkerClient>(client =>
{
    client.BaseAddress = new Uri("https://api.jijinhao.com//");
    client.DefaultRequestHeaders.Add("User-Agent",
                                     "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36");
    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
    client.DefaultRequestHeaders.Add("Referer", "https://quote.cngold.org/");
});

builder.AddMetalDb();
builder.Services.AddQuartz();
builder.Services.AddQuartzServer(options => { options.WaitForJobsToComplete = true; });


var host = builder.Build();

// create scheduled jon run every 20 sec
var factory   = host.Services.GetRequiredService<ISchedulerFactory>();
var scheduler = await factory.GetScheduler();

var jobKey = new JobKey("gg");

var job = JobBuilder
         .Create<GoldMetaDataFetchJob>()
         .WithIdentity(jobKey)
         .WithDescription("this is Fucking job")
         .Build()
    ;

var trigger = TriggerBuilder
             .Create()
             .WithIdentity("GoldMetaDataFetchJobTrigger")
             .ForJob(jobKey)
             .WithSchedule(SimpleScheduleBuilder.RepeatMinutelyForever())
             .Build()
    ;

// wait 10 secondes before start
await Task.Delay(10 * 1000);

await scheduler.ScheduleJob(job, trigger);

host.Run();