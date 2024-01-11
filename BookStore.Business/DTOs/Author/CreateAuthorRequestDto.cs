namespace BookStore.Business.DTOs.Author;

public class CreateAuthorRequestDto
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime BirthDate { get; set; }
}