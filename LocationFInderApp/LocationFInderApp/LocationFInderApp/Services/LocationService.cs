using LocationFInderApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocationFInderApp.Services
{
    public class LocationService
    {
        private const string ApiBaseUrl = "http://194.233.74.220:82/api/Location";
        private readonly HttpClient _httpClient;

        public LocationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task SendLocationAsync(LocationView location)
        {
            var json = JsonConvert.SerializeObject(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{ApiBaseUrl}/addlocation", content);
        }
    }
}
