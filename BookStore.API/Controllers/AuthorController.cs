using BookStore.Business.DTOs.Author;
using BookStore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var author = await _service.GetByIdAsync(id);

        return Ok(author);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var authors = await _service.GetAllAsync();

        return Ok(authors);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateAuthorRequestDto requestDto)
    {
        await _service.UpdateAsync(id, requestDto);

        return Ok(requestDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAuthorRequestDto requestDto)
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