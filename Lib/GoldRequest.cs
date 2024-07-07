using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lib;

public record GoldRequest
{
    public long TimeStamp => Time.ToUnixTimeMilliseconds();

    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

    public List<string> Codes { get; set; } = [];
    
    public static GoldRequest Create() => new();
}

public static class CodeRequestBuilderExtensions
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters                  = { new MatelJsonConverter() },
    };

    public static GoldRequest WithCode(this GoldRequest @params, string code)
    {
        @params.Codes = [code];
        return @params;
    }

    public static GoldRequest WithCodes(this GoldRequest @params, params string[] codes)
    {
        @params.Codes = codes.ToList();
        return @params;
    }

    public static GoldRequest AddCode(this GoldRequest @params, string code)
    {
        @params.Codes.Add(code);
        return @params;
    }

    public static GoldRequest AddCodes(this GoldRequest @params, List<string> codes)
    {
        @params.Codes = codes;
        return @params;
    }

    public static GoldRequest WithTime(this GoldRequest @params, DateTimeOffset time)
    {
        @params.Time = time;
        return @params;
    }

    public static GoldRequest WithTimeStamp(this GoldRequest @params, long timeStamp)
    {
        @params.Time = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp);
        return @params;
    }

    public static async Task<GoldResponseDto?> Send(this GoldRequest @params)
    {
        using var client = new HttpClient
        {
            DefaultRequestHeaders =
            {
                { "User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36" },
                { "Accept-Encoding", "gzip, deflate, br" },
                { "Referer", "https://quote.cngold.org/" }
            }
        };

        var requestUri = $"https://api.jijinhao.com/quoteCenter/realTime.htm?codes={string.Join(",", @params.Codes)}";

        Console.WriteLine(requestUri);
        
        var response = await client.GetAsync(requestUri);

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
}