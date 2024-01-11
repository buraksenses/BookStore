namespace BookStore.Business.DTOs.Genre;

public class CreateGenreRequestDto
{
    public string Name { get; set; }

    public bool IsActive { get; set; } = true;
}