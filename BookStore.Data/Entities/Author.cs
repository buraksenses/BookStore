using System.ComponentModel.DataAnnotations.Schema;
using BookStore.API.Domain;

namespace BookStore.Data.Entities;

public class Author : IEntity<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }

    public DateTime BirthDate { get; set; }
}