using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

// ReSharper disable InconsistentNaming


namespace Lib;

public class MetalDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var code in Global.Codes)
        {
            modelBuilder.SharedTypeEntity<MetalMetadata>(code);
        }
    }

    public async Task AddAsync(MetalMetadata metadata)
    {
        var code = metadata.Code;
        await Set<MetalMetadata>(code).AddAsync(metadata);
    }

    public void Add(MetalMetadata metadata)
    {
        AddAsync(metadata).GetAwaiter().GetResult();
    }

    public MetalDbContext(DbContextOptions<MetalDbContext> options) : base(options)
    {
    }
}