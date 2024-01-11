using BookStore.Business.DTOs.Genre;
using BookStore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var book = await _service.GetByIdAsync(id);

        return Ok(book);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var genres = await _service.GetAllAsync();

        return Ok(genres);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateGenreRequestDto requestDto)
    {
        await _service.UpdateAsync(id, requestDto);

        return Ok(requestDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateGenreRequestDto requestDto)
    {
        await _service.CreateAsync(requestDto);

        return Ok(requestDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _service.DeleteByIdAsync(id);

        return Ok();
    }
}