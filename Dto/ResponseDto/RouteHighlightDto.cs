using Roadtrip.Dto.ClientDto;

namespace Roadtrip.Dto.ResponseDto
{
    public record RouteHighlightDto
    (
        List<RoutesResponseDto> routes
    );

    public record RoutesResponseDto
    (
        string duration,
        HashSet<ResultsDto> highlights 
    );
}