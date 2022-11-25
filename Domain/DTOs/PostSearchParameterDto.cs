namespace Domain.DTOs;

public class PostSearchParameterDto
{
    public string? OwnerName { get; }
    public string? TitleContains { get; }
    public int? Id { get; }

    public PostSearchParameterDto(string? ownerName, string? titleContains, int? id)
    {
        OwnerName = ownerName;
        TitleContains = titleContains;
        Id = id;
    }
}