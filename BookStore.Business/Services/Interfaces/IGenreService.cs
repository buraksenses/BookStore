using BookStore.Business.DTOs.Genre;

namespace BookStore.Business.Services.Interfaces;

public interface IGenreService 
{
    Task CreateAsync(CreateGenreRequestDto requestDto);

    Task UpdateAsync(int id, UpdateGenreRequestDto requestDto);

    Task<GetGenreRequestDto> GetByIdAsync(int id);

    Task<List<GetGenreRequestDto>> GetAllAsync();

    Task DeleteByIdAsync(int id);
}