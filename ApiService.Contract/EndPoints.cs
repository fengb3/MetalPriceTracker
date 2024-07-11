namespace ApiService.Contract;

public class EndPoints
{
    private const string API_BASE_URL = "/api";
    
    public static class Codes
    {
        private const string BASE_URL = $"{API_BASE_URL}/Codes";
        public const string GET_ALL  = $"{BASE_URL}/GetCodesAsync";
    }

    public static class MetalMeta
    {
        private const string BASE_URL = $"{API_BASE_URL}/MetalMetaData";
        
        public const string Create = BASE_URL;
        public const string GET    = $"{BASE_URL}/{{code}}";
    }
}