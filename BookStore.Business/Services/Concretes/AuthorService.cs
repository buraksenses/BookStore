using AutoMapper;
using BookStore.Business.DTOs.Author;
using BookStore.Business.Services.Interfaces;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Interfaces;

namespace BookStore.Business.Services.Concretes;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task CreateAsync(CreateAuthorRequestDto requestDto)
    {
        var author = _mapper.Map<Author>(requestDto);

        await _repository.CreateAsync(author);
    }

    public async Task UpdateAsync(int id, UpdateAuthorRequestDto requestDto)
    {
        var author = _mapper.Map<Author>(requestDto);

        await _repository.UpdateAsync(id, author);
    }

    public async Task<GetAuthorRequestDto> GetByIdAsync(int id)
    {
        var author = await _repository.GetOrThrowNotFoundByIdAsync(id);

        var authorDto = _mapper.Map<GetAuthorRequestDto>(author);

        return authorDto;
    }

    public async Task<List<GetAuthorRequestDto>> GetAllAsync()
    {
        var authorList = await _repository.GetAllAsync();

        var authorDtoList = _mapper.Map<List<GetAuthorRequestDto>>(authorList);

        return authorDtoList;
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}