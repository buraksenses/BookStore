using BookStore.Business.DTOs.Author;

namespace BookStore.Business.Services.Interfaces;

public interface IAuthorService
{
    Task CreateAsync(CreateAuthorRequestDto requestDto);

    Task UpdateAsync(int id, UpdateAuthorRequestDto requestDto);

    Task<GetAuthorRequestDto> GetByIdAsync(int id);

    Task<List<GetAuthorRequestDto>> GetAllAsync();

    Task DeleteByIdAsync(int id);
}