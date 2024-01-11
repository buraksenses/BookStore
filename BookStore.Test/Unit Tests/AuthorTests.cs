using AutoMapper;
using BookStore.Business.DTOs.Author;
using BookStore.Business.Services.Concretes;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Interfaces;
using Moq;

namespace BookStore.Test.Unit_Tests;

public class AuthorTests
{
    private readonly Mock<IAuthorRepository> _mockAuthorRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AuthorService _authorService;

    public AuthorTests()
    {
        _mockAuthorRepo = new Mock<IAuthorRepository>();
        _mockMapper = new Mock<IMapper>();
        _authorService = new AuthorService(_mockAuthorRepo.Object, _mockMapper.Object);
    }


    [Fact]
    public async Task CreateAsync_Successfully()
    {
        // Arrange
        var createDto = new CreateAuthorRequestDto { Name = "Test" , Surname = "User", BirthDate = DateTime.Today.AddYears(-20)};

        _mockMapper.Setup(m => m.Map<Author>(createDto)).Returns(It.IsAny<Author>());
        _mockAuthorRepo.Setup(repo => repo.CreateAsync(It.IsAny<Author>())).Returns(Task.CompletedTask);

        // Act
        await _authorService.CreateAsync(createDto);

        // Assert
        _mockAuthorRepo.Verify(repo => repo.CreateAsync(It.IsAny<Author>()), Times.Once);
    }
    
    [Fact]
    public async Task GetByIdAsync_ReturnsAuthorDto()
    {
        // Arrange
        var authorId = 1;
        var authorDto = new GetAuthorRequestDto { Name = "Test" , Surname = "User", BirthDate = DateTime.Today.AddYears(-20) };

        _mockAuthorRepo.Setup(repo => repo.GetOrThrowNotFoundByIdAsync(authorId)).ReturnsAsync(It.IsAny<Author>());
        _mockMapper.Setup(m => m.Map<GetAuthorRequestDto>(It.IsAny<Author>())).Returns(authorDto);

        // Act
        var result = await _authorService.GetByIdAsync(authorId);

        // Assert
        Assert.Equal(authorDto, result);
    }
    
    [Fact]
    public async Task UpdateAsync_Successfully()
    {
        // Arrange
        var authorId = 1;
        var updateDto = new UpdateAuthorRequestDto { Name = "Test" , Surname = "User"};
        

        _mockAuthorRepo.Setup(repo => repo.GetOrThrowNotFoundByIdAsync(authorId)).ReturnsAsync(It.IsAny<Author>());
        _mockMapper.Setup(m => m.Map(updateDto, It.IsAny<Author>())).Verifiable();
        _mockAuthorRepo.Setup(repo => repo.UpdateAsync(authorId, It.IsAny<Author>())).Returns(Task.CompletedTask);

        // Act
        await _authorService.UpdateAsync(authorId, updateDto);

        // Assert
        _mockAuthorRepo.Verify(repo => repo.UpdateAsync(authorId, It.IsAny<Author>()), Times.Once);
    }

    [Fact]
    public async Task DeleteByIdAsync_Successfully()
    {
        // Arrange
        var authorId = 1;

        _mockAuthorRepo.Setup(repo => repo.DeleteByIdAsync(authorId)).Returns(Task.CompletedTask);

        // Act
        await _authorService.DeleteByIdAsync(authorId);

        // Assert
        _mockAuthorRepo.Verify(repo => repo.DeleteByIdAsync(authorId), Times.Once);
    }


    
}