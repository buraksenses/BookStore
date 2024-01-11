namespace BookStore.Business.DTOs.Genre;

public class GetGenreRequestDto
{
    public string Name { get; set; }

    public bool IsActive { get; set; } = true;
}