using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Lib;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Worker;

public class MetalMetaDataWorkerClient(HttpClient httpClient)
{
    /// <summary>
    /// 获取贵金属数据
    /// </summary>
    /// <returns></returns>
    public async Task<JiJinHaoMetalResponseDto?> FetchDataAsync()
    {
        var response = await httpClient.GetAsync($"/quoteCenter/realTime.htm?code={string.Join(",", Global.Codes)}");

        response.EnsureSuccessStatusCode();

        await using var contentStream      = await response.Content.ReadAsStreamAsync();
        await using var decompressedStream = GetDecompressedStream(contentStream, response.Content.Headers);
        using var       reader             = new StreamReader(decompressedStream, Encoding.UTF8);
        var             content            = await reader.ReadToEndAsync();

        content = content.Split('=')[1].Trim();

        var result = JsonSerializer.Deserialize<JiJinHaoMetalResponseDto>(content, Options);

        return result;
    }

    /// <summary>
    /// 获取到解压后的流
    /// </summary>
    /// <param name="contentStream"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
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
        Converters                  = { new JiJinHaoMetalJsonConverter() },
    };
}