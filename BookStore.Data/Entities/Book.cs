using System.ComponentModel.DataAnnotations.Schema;
using BookStore.API.Domain;

namespace BookStore.Data.Entities;

public class Book : IEntity<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }

    public int GenreId { get; set; }

    public int PageCount { get; set; }

    public DateTime PublishDate { get; set; }
}