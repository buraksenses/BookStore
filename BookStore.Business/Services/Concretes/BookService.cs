using AutoMapper;
using BookStore.Business.DTOs.Book;
using BookStore.Business.Services.Interfaces;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Interfaces;

namespace BookStore.Business.Services.Concretes;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task CreateAsync(CreateBookRequestDto requestDto)
    {
        var author = _mapper.Map<Book>(requestDto);

        await _repository.CreateAsync(author);
    }

    public async Task UpdateAsync(int id, UpdateBookRequestDto requestDto)
    {
        var author = _mapper.Map<Book>(requestDto);

        await _repository.UpdateAsync(id, author);
    }

    public async Task<GetBookRequestDto> GetByIdAsync(int id)
    {
        var author = await _repository.GetOrThrowNotFoundByIdAsync(id);

        var authorDto = _mapper.Map<GetBookRequestDto>(author);

        return authorDto;
    }

    public async Task<List<GetBookRequestDto>> GetAllAsync()
    {
        var authorList = await _repository.GetAllAsync();

        var authorDtoList = _mapper.Map<List<GetBookRequestDto>>(authorList);

        return authorDtoList;
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}