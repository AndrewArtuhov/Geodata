using Core.Interfaces;
using Core.Models;
using Dadata;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DadataService
    {
        private IAPISettings _searchSettings;  

        public DadataService(IAPISettings settings)
        {
            _searchSettings = settings;
        }

        public async Task<string> GetAddressByPosition(PositionModel position)
        {
            var token = $"{_searchSettings.ApiKey}";
            var api = new SuggestClientAsync(token);
            var result = await api.Geolocate(position.Latitude, position.Longitude);
            return JsonConvert.SerializeObject(result);
        }
    }
}
