using System.Text.Json.Serialization;

namespace Lib;

public record JiJinHaoMetalResponseDto
{
    public bool      Flag      { get; set; }
    public string[]? ErrorCode { get; set; }

    [JsonIgnore]
    public Dictionary<string, MetalMetaData> MetalMatas { get; init; } = [];
}