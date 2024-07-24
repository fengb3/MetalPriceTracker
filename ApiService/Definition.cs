namespace ApiService
{
    public static class Definition
    {
        public const string API_VERSION  = "v1";
        public const string API_BASE_URL = $"/api/{API_VERSION}";
    }
}

namespace ApiService.Endpoints.Codes
{
    public static partial class Get
    {
        public const string URL = $"{Definition.API_BASE_URL}/Codes/Get";
    }

    public static partial class GetAsync
    {
        public const string URL = $"{Definition.API_BASE_URL}/Codes/GetAsync";
    }
}

namespace ApiService.Endpoints.MetalMetadata
{
    public static partial class Get
    {
        public const string URL = $"{Definition.API_BASE_URL}/MetalMetadata/Get";
    }
    
    public static partial class GetAsync
    {
        public const string URL = $"{Definition.API_BASE_URL}/MetalMetadata/GetAsync";
    }
}