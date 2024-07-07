using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

// ReSharper disable InconsistentNaming


namespace Lib;

public class GoldDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var code in Global.Codes)
        {
            modelBuilder.SharedTypeEntity<MetalMetaData>(code);
        }
    }

    public async Task AddAsync(MetalMetaData metaData)
    {
        var code = metaData.Code;
        await Set<MetalMetaData>(code).AddAsync(metaData);
    }

    public void Add(MetalMetaData metaData)
    {
        AddAsync(metaData).GetAwaiter().GetResult();
    }

    public GoldDbContext(DbContextOptions<GoldDbContext> options) : base(options)
    {
    }
}