using System.Text.Json;

namespace Lib.Helper;

public static  class StringHelper
{
    public static string ToJsonString(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}