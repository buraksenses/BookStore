using AutoMapper;
using BookStore.Business.DTOs.Genre;
using BookStore.Business.Services.Interfaces;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Interfaces;

namespace BookStore.Business.Services.Concretes;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _repository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task CreateAsync(CreateGenreRequestDto requestDto)
    {
        var author = _mapper.Map<Genre>(requestDto);

        await _repository.CreateAsync(author);
    }

    public async Task UpdateAsync(int id, UpdateGenreRequestDto requestDto)
    {
        var author = _mapper.Map<Genre>(requestDto);

        await _repository.UpdateAsync(id, author);
    }

    public async Task<GetGenreRequestDto> GetByIdAsync(int id)
    {
        var author = await _repository.GetOrThrowNotFoundByIdAsync(id);

        var authorDto = _mapper.Map<GetGenreRequestDto>(author);

        return authorDto;
    }

    public async Task<List<GetGenreRequestDto>> GetAllAsync()
    {
        var authorList = await _repository.GetAllAsync();

        var authorDtoList = _mapper.Map<List<GetGenreRequestDto>>(authorList);

        return authorDtoList;
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}