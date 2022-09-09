using Roadtrip.Clients;
using Roadtrip.Dto.ClientDto;
using Roadtrip.Dto.ResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace Roadtrip.Controllers
{
    [ApiController]
    [Route("api/routes")]
    public class RoutesController : ControllerBase
    {
        private readonly RoutesClient _routesClient;
        private readonly PlacesClient _placesClient;

        public RoutesController(RoutesClient routesClient, PlacesClient placesClient)
        {
            _routesClient = routesClient;
            _placesClient = placesClient;
        }

        [HttpGet]
        public async Task<ActionResult<RouteHighlightDto>> GetRouteAsync(float lat0, float lng0, float lat1, float lng1)
        {
            var res = await _routesClient.GetRouteAsync(lat0, lng0, lat1, lng1);

            RouteHighlightDto routeHighlight = new(new List<RoutesResponseDto>());
            foreach(var route in res.routes)
            {   
                RoutesResponseDto routesResponse = new(route.legs.First().duration.text, new HashSet<ResultsDto>());
                routeHighlight.routes.Add(routesResponse);


                var steps = route.legs.First().steps.ToList<StepsDto>();
                
                //Checks every 5 step for highlight
                for(int i = 0; i < steps.Count; i += 5)
                {   
                    var step = steps[i].start_location;
                    var points = await _placesClient.GetHighlightAsync(step.lat, step.lng, true);

                    routeHighlight.routes.Last().highlights.UnionWith(points.results.Where(point => point.rating >= 3.5));
                }
            }

            return Ok(routeHighlight);
        }
    }
}