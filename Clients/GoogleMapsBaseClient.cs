using Roadtrip.Utilities;

namespace Roadtrip.Clients
{
    public class GoogleMapsBaseClient
    {
        protected readonly HttpClient _httpClient;

        protected readonly string? _apiKey;

        public GoogleMapsBaseClient(HttpClient httpClient)
        {
            _httpClient = httpClient; 
            _apiKey = GMapsHttpClient.apiKey;
        }

        public async Task<D> GetAsync<D>(string query) where D : notnull
        {   
            //Add api key
            query += $"&key={_apiKey}";
            
            var response = await _httpClient.GetFromJsonAsync<D>(query);
            
            return response;
        }
    }
}