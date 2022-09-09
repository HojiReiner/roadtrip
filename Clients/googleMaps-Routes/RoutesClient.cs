using System.Text;
using System.Globalization;
using Roadtrip.Dto.ClientDto;

namespace Roadtrip.Clients
{
    public class RoutesClient : GoogleMapsBaseClient
    {
        public RoutesClient(HttpClient httpClient) : base(httpClient) {}

        public async Task<GMapsRoutesDto> GetRouteAsync(float latStart, float lngStart, float latEnd, float lngEnd) 
        {   
            StringBuilder query = new StringBuilder();

            query.Append("alternatives=true");
            query.Append($"&origin={latStart.ToString(CultureInfo.InvariantCulture.NumberFormat)},{lngStart.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
            query.Append($"&destination={latEnd.ToString(CultureInfo.InvariantCulture.NumberFormat)},{lngEnd.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
            
            var search = $"maps/api/directions/json?{query.ToString()}";
            return await GetAsync<GMapsRoutesDto>(search);
        }
    }
}