using Microsoft.AspNetCore.Mvc;
using WebApiClientCore.Attributes;
using HttpGetAttribute = WebApiClientCore.Attributes.HttpGetAttribute;

namespace Web2.Data
{
    // [HttpHost("http+https://api-service/")]
    public interface IMetalMetaApi
    {
        [HttpGet("/api/MetalMetaData/GetCodesAsync")]
        Task<HttpResponseMessage> GetCodesAsync();

        [HttpGet("/api/MetalMetaData/GetAsync/{code}")]
        Task<HttpResponseMessage> GetAsync(string code, [FromQuery] long startTime, [FromQuery] long endTime);
    }
}
