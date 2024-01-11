using BookStore.Business.DTOs.Book;

namespace BookStore.Business.Services.Interfaces;

public interface IBookService 
{
    Task CreateAsync(CreateBookRequestDto requestDto);

    Task UpdateAsync(int id, UpdateBookRequestDto requestDto);

    Task<GetBookRequestDto> GetByIdAsync(int id);

    Task<List<GetBookRequestDto>> GetAllAsync();

    Task DeleteByIdAsync(int id);
}