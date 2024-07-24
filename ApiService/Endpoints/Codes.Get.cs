using Lib;

namespace ApiService.Endpoints.Codes;

public partial class Get
{
    // public const string URL = $"{Definition.API_BASE_URL}/Codes/Get";

    public partial class ResponseBody
    {
        public IEnumerable<string> Codes { get; set; }
    };

    internal class Endpoint : EndpointWithoutRequest<ResponseBody>
    {
        public override void Configure()
        {
            Get(URL);
            AllowAnonymous();
        }

        public override Task<ResponseBody> ExecuteAsync(CancellationToken ct)
        {
            return Task.FromResult(new Get.ResponseBody
            {
                Codes = Global.Codes
            });
        }
    }
}