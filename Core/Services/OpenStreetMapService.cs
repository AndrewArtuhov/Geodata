using System.Net.Http;
using System.Threading.Tasks;
using System;
using Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace Core.Services
{
    public class OpenStreetMapService
    {
        private readonly HttpClient _httpClient;
        private IAPISettings _searchSettings;

        public OpenStreetMapService(IAPISettings settings)
        {
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
            _searchSettings = settings;
            _httpClient.BaseAddress = new Uri(_searchSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
        }

        public async Task<string> GetPositionByAddress(AddressModel address)
        {
            var urlParams = _searchSettings.Param.Replace("{country}", address.Country).Replace("{city}", address.City).Replace("{street}", $"{address.Street} {address.NumberHouse}");
            var response = await _httpClient.GetAsync(urlParams);
            var models = new List<PositionModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                models = JsonConvert.DeserializeObject<PositionModel[]>(json).ToList();
            }
            return JsonConvert.SerializeObject(models.FirstOrDefault());
        }
    }
}
