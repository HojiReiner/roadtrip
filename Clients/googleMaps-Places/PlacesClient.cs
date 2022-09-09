using System.Text;
using System.Globalization;
using Roadtrip.Dto.ClientDto;

namespace Roadtrip.Clients
{
    public class PlacesClient : GoogleMapsBaseClient
    {
        public PlacesClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<GMapsPlacesDto> GetHighlightAsync(float latPoint, float lngPoint, bool relevance = false)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"location={latPoint.ToString(CultureInfo.InvariantCulture.NumberFormat)}%2C{lngPoint.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
            query.Append("&type=tourist_attraction");
            if (relevance)
            {
                query.Append("&radius=5000");
            }
            else
            {
                query.Append("&rankby=distance");
            }

            var search = $"/maps/api/place/nearbysearch/json?{query.ToString()}";
            return await GetAsync<GMapsPlacesDto>(search);
        }
    }
}