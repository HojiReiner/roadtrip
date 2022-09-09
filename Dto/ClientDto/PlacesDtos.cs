namespace Roadtrip.Dto.ClientDto
{
    public record GMapsPlacesDto
    (
        HashSet<ResultsDto> results,
        string status
    );

    public record ResultsDto
    (
        string name,
        float rating,
        int user_ratings_total
   );
}