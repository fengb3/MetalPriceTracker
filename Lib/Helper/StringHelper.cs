using System.Text.Json;

namespace Lib.Helper;

public static  class StringHelper
{
    public static string ToJsonString(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static string ToQueryString(this object obj)
    {
        var properties = obj.GetType().GetProperties();
        var queryString = string.Join("&", properties.Select(p => $"{p.Name}={p.GetValue(obj)}"));
        return queryString;
    }
}