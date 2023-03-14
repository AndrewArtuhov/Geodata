using Core.Interfaces;

namespace Core.Entities
{
    public class DadataSearchSetting : IAPISettings
    {
        public DadataSearchSetting(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Param { get; set; }
    }
}
