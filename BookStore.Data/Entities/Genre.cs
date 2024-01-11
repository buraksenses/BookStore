using System.ComponentModel.DataAnnotations.Schema;
using BookStore.API.Domain;

namespace BookStore.Data.Entities;

public class Genre : IEntity<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; } = true;
}