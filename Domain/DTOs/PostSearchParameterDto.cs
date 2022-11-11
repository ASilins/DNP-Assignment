namespace Domain.DTOs;

public class PostSearchParameterDto
{
    public string? OwnerName { get; }
    public string? TitleContains { get; }

    public PostSearchParameterDto(string? ownerName, string? titleContains)
    {
        OwnerName = ownerName;
        TitleContains = titleContains;
    }
}