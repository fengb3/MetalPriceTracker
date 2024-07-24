using Lib;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Endpoints.MetalMetadata;

public static partial class Get
{
    // public const string URL = "/Metas/Get";
    
    public record RequestBody
    {
        [QueryParam]
        public string Code { get; init; }
        
        [QueryParam]
        public long StartTime { get; init; }
        
        [QueryParam]
        public long EndTime { get; init; }
    }

    public record ResponseBody
    {
        public required IEnumerable<Lib.MetalMetadata> Metas { get; init; }
    }

    internal class Endpoint(ILogger<Endpoint> logger, MetalDbContext dbContext) : Endpoint<RequestBody, ResponseBody>
    {
        public override void Configure()
        {
            Get(URL);
            AllowAnonymous();
        }

        public override async Task<ResponseBody> ExecuteAsync(RequestBody req, CancellationToken ct)
        {
            logger.LogInformation("Executing MetalMetadataGet endpoint - " +
                                  "Code: {Code}, Start {start}, End: {end}", req.Code, req.StartTime, req.EndTime);

            var metas = await FetchMetalMetadataAsync(req.Code, req.StartTime, req.EndTime, ct);

            return new ResponseBody
            {
                Metas = metas
            };
        }

        private async Task<IEnumerable<Lib.MetalMetadata>> FetchMetalMetadataAsync(
            string code, long startTime, long endTime, CancellationToken ct)
        {
            
            return await dbContext.Set<Lib.MetalMetadata>(code)
                            .Where(m => m.Time >= startTime && m.Time <= endTime)
                            .ToListAsync(ct);
            // // Implement the logic to fetch the metal metadata based on the query parameters
            // // This is a placeholder implementation
            // return Task.FromResult(Enumerable.Empty<Lib.MetalMetadata>());
        }
    }

}

// public class MetalMetadataGet(ILogger<MetalMetadataGet> logger, MetalDbContext dbContext)
//     : Endpoint<Get.RequestBody, Get.ResponseBody>
// {
//     public override void Configure()
//     {
//         Get(Contract.MetalMetadata.Get.URL);
//         AllowAnonymous();
//     }
//
//     public override async Task<Get.ResponseBody> ExecuteAsync(Get.RequestBody req, CancellationToken ct)
//     {
//         // return base.ExecuteAsync(req, ct);
//
//         logger.LogInformation("Executing MetalMetadataGet endpoint");
//         logger.LogInformation("Code: {Code}, Start {start}, End: {end}", req.Code, req.StartTime, req.EndTime);
//
//         var metaDatas = await FetchMetalMetadataAsync(req.Code, req.StartTime, req.EndTime, ct);
//
//         return new Get.ResponseBody
//         {
//             MetaDatas = metaDatas
//         };
//     }
//
//     // public override async Task<Get.ResponseBody> ExecuteAsync(CancellationToken ct)
//     // {
//     //     // Retrieve query parameters
//     //     // var query = Query<Get.RequestBody>("q");
//     //
//     //     // Fetch the metal metadata based on the query parameters
//     //     var metaDatas = await FetchMetalMetadataAsync(query.Code, query.StartTime, query.EndTime, ct);
//     //
//     //     // Return the response with the fetched data
//     //     return new Get.ResponseBody
//     //     {
//     //         MetaDatas = metaDatas
//     //     };
//     // }
//
//     private Task<IEnumerable<Lib.MetalMetadata>> FetchMetalMetadataAsync(
//         string code, long startTime, long endTime, CancellationToken ct)
//     {
//         // Implement the logic to fetch the metal metadata based on the query parameters
//         // This is a placeholder implementation
//         return Task.FromResult(Enumerable.Empty<Lib.MetalMetadata>());
//     }
// }