using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityModel;
using Lib;
using Lib.EventStream;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetalMetaDataController : ControllerBase
{
    private readonly MetalDbContext _dbContext;

    public MetalMetaDataController(MetalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetCodesAsync")]
    public async Task GetCodesAsync()
    {
        async IAsyncEnumerable<string> EnumerateArrayAsync(string[] array)
        {
            foreach (var item in array)
            {
                yield return item;
                await Task.Yield(); // Yield control to mimic asynchronous behavior
            }
        }

        await Response.SendChunksAsync(EnumerateArrayAsync(Global.Codes));
    }


    [HttpGet("GetAsync/{code}")]
    public async Task GetAsync(string code, [FromQuery] long startTime, [FromQuery] long endTime)
    {
        var filteredMetalDataAsync = _dbContext.Set<MetalMetaData>(code)
                                  .Where(m => m.Time >= startTime && m.Time <= endTime)
                                  .AsAsyncEnumerable();

        await Response.SendChunksAsync(filteredMetalDataAsync);
    }
}