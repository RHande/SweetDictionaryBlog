namespace SweetDictionary.Models.Categories;

public sealed record CategoryResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; }
}