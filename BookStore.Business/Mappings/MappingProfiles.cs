using AutoMapper;
using BookStore.Business.DTOs.Author;
using BookStore.Business.DTOs.Book;
using BookStore.Business.DTOs.Genre;
using BookStore.Data.Entities;

namespace BookStore.Business.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region Author Mappings

        CreateMap<Author, CreateAuthorRequestDto>().ReverseMap();

        CreateMap<Author, UpdateAuthorRequestDto>().ReverseMap();

        CreateMap<Author, GetAuthorRequestDto>().ReverseMap();

        #endregion
        
        #region Book Mappings

        CreateMap<Book, CreateBookRequestDto>().ReverseMap();

        CreateMap<Book, UpdateBookRequestDto>().ReverseMap();

        CreateMap<Book, GetBookRequestDto>().ReverseMap();

        #endregion
        
        #region Genre Mappings

        CreateMap<Genre, CreateGenreRequestDto>().ReverseMap();

        CreateMap<Genre, UpdateGenreRequestDto>().ReverseMap();

        CreateMap<Genre, GetGenreRequestDto>().ReverseMap();

        #endregion
    }
}