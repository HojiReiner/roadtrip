using Roadtrip.Clients;
using Roadtrip.Dto.ResponseDto;
using Microsoft.AspNetCore.Mvc;

namespace Roadtrip.Controllers
{
    [ApiController]
    [Route("api/highlight")]
    public class HighlightController : ControllerBase
    {
        private readonly PlacesClient _placesClient;

        public HighlightController(PlacesClient placesClient)
        {
            _placesClient = placesClient;
        }

        [HttpGet]
        public async Task<ActionResult<HighlightDto>> GetHighlightAsync(float latPoint, float lngPoint)
        {
            var res = await _placesClient.GetHighlightAsync(latPoint, lngPoint);
            return Ok(res.results.Where(h => h.rating >= 3.5).First());
        }

    }
}