using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lib;

public class JiJinHaoMetalJsonConverter : JsonConverter<JiJinHaoMetalResponseDto>
{
    public override JiJinHaoMetalResponseDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        var response = new JiJinHaoMetalResponseDto
        {
            MetalMatas = new Dictionary<string, MetalMetaData>()
        };

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return response;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string? propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "flag":
                        response.Flag = reader.GetBoolean();
                        break;
                    case "errorCode":
                        response.ErrorCode = JsonSerializer.Deserialize<string[]>(ref reader, options);
                        break;
                    default:
                    {
                        if (propertyName.StartsWith("JO_"))
                        {
                            var goldData = JsonSerializer.Deserialize<MetalMetaData>(ref reader, options);
                            response.MetalMatas.Add(propertyName, goldData);
                        }

                        break;
                    }
                }
            }
        }

        throw new JsonException("Invalid JSON format");
    }

    public override void Write(Utf8JsonWriter writer, JiJinHaoMetalResponseDto value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteBoolean("flag", value.Flag);
        writer.WritePropertyName("errorCode");
        JsonSerializer.Serialize(writer, value.ErrorCode, options);

        foreach (var kvp in value.MetalMatas)
        {
            writer.WritePropertyName(kvp.Key);
            JsonSerializer.Serialize(writer, kvp.Value, options);
        }

        writer.WriteEndObject();
    }
}