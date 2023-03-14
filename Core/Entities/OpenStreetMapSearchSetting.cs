using Core.Interfaces;

namespace Core.Entities
{
    public class OpenStreetMapSearchSetting : IAPISettings
    {
        public OpenStreetMapSearchSetting(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Param { get; set; } = "search?country={country}&city={city}&street={street}&format=json&limit=2";
    }
}
