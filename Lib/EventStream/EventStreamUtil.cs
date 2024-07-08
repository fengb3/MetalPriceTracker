using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Lib.EventStream;

public static class EventStreamUtil
{
    public const string CONTENT_TYPE = "text/event-stream";
    public const string DATA_PREFIX = "data: ";
    public const string DATA_SUFFIX = "\n\n";
    
    public static async Task SendChunksAsync<T>(this HttpResponse response, IAsyncEnumerable<T> requestData)
    {
        response.ContentType = CONTENT_TYPE;

        await foreach(var responseChunkBody in requestData)
        {
            await response.WriteAsync(DATA_PREFIX + JsonSerializer.Serialize(responseChunkBody) + DATA_SUFFIX);
            await response.Body.FlushAsync();
        }
    }
    
    public static async IAsyncEnumerable<T> ReceiveChunkAsync<T>(this HttpResponseMessage response, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync(cancellationToken);
            if (line != null && line.StartsWith(DATA_PREFIX))
            {
                var json = line.Substring(DATA_PREFIX.Length);
                var data = JsonSerializer.Deserialize<T>(json);
                if (data != null)
                {
                    yield return data;
                }
            }
        }
    }
}