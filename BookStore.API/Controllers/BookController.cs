using BookStore.Business.DTOs.Book;
using BookStore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;

    public BookController(IBookService service)
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
        var authors = await _service.GetAllAsync();

        return Ok(authors);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateBookRequestDto requestDto)
    {
        await _service.UpdateAsync(id, requestDto);

        return Ok(requestDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBookRequestDto requestDto)
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