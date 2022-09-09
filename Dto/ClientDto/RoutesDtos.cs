namespace Roadtrip.Dto.ClientDto
{
    public record GMapsRoutesDto
    (
        List<RoutesDto> routes,
        string status
    );

    public record RoutesDto
    (
        List<LegsDto> legs
    );

    public record LegsDto
    (
        List<StepsDto> steps,
        Duration duration
    );

    public record StepsDto
    (
        Location start_location
    );

    public record Location 
    (
        float lat,
        float lng
    );

    public record Duration
    (
        string text
    );
}