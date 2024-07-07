using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Lib;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Worker;

public class GoldMetaDataWorkerClient(HttpClient httpClient)
{
    public async Task<GoldResponseDto?> FetchDataAsync()
    {
        var response = await httpClient.GetAsync($"/quoteCenter/realTime.htm?codes={string.Join(",", Global.Codes)}");

        response.EnsureSuccessStatusCode();

        await using var contentStream      = await response.Content.ReadAsStreamAsync();
        await using var decompressedStream = GetDecompressedStream(contentStream, response.Content.Headers);
        using var       reader             = new StreamReader(decompressedStream, Encoding.UTF8);
        var             content            = await reader.ReadToEndAsync();

        content = content.Split('=')[1].Trim();

        var result = JsonSerializer.Deserialize<GoldResponseDto>(content, Options);

        return result;
    }

    private static Stream GetDecompressedStream(Stream contentStream, HttpContentHeaders headers)
    {
        foreach (var encoding in headers.ContentEncoding)
        {
            switch (encoding.ToLower())
            {
                case "gzip":
                    return new GZipStream(contentStream, CompressionMode.Decompress);
                case "deflate":
                    return new DeflateStream(contentStream, CompressionMode.Decompress);
                case "br":
                    return new BrotliStream(contentStream, CompressionMode.Decompress);
            }
        }

        return contentStream;
    }

    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters                  = { new MatelJsonConverter() },
    };
}