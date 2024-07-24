using System.Runtime.CompilerServices;
using Lib;

namespace ApiService.Endpoints.Codes;

public static partial class GetAsync
{
    // public const string URL = "codes";

    public record ResponseChunk
    {
        public required string Code { get; set; }
    }

    internal class Endpoint : EndpointWithoutRequest<ResponseChunk>
    {
        public override void Configure()
        {
            Get(URL);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendEventStreamAsync("codes", ConvertArrayToAsyncEnumerable(Global.Codes, ct), ct);
        }

        private async IAsyncEnumerable<ResponseChunk> ConvertArrayToAsyncEnumerable(
            string[] array, [EnumeratorCancellation] CancellationToken ct = default)
        {
            foreach (var item in array)
            {
                if (ct.IsCancellationRequested)
                {
                    yield break;
                }

                var chunk = new ResponseChunk()
                {
                    Code = item
                };
                yield return chunk; // Asynchronously yield each string in the array
                await Task.Delay(1, ct); // Simulate a delay of 1 second
                // await Task.Yield(); // This line is optional, ensuring the method yields control back to the caller, making it more asynchronous in nature.
            }
        }
    }
}