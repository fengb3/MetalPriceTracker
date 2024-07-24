using Microsoft.AspNetCore.Mvc;
using WebApiClientCore;
using WebApiClientCore.Attributes;

namespace Lib.RestfulApi;

public class MetalRequest
{
    [FromQuery]
    public DateTimeOffset StartTime { get; set; }
    [FromQuery]
    public DateTimeOffset EndTime   { get; set; }
}

public class MetalResponseBody
{
    public required IEnumerable<MetalMetadata> MetalMetas { get; set; }
}