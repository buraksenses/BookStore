namespace BookStore.Business.DTOs.Genre;

public class UpdateGenreRequestDto
{
    public string Name { get; set; }

    public bool IsActive { get; set; } = true;
}