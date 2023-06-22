using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Product : IEntity
{
    public int Id { get ; set ; }
    [Required]
    public string MainImage { get; set; } = null!;
    [Required, MaxLength(255)]
    public string HoverImage { get; set ; } = null!;
    [Required,MaxLength(255)]
    public string Name { get ; set ; } = null!;
    [Required]
    public decimal Price { get; set ; }
    public int Starts { get; set ; }
}
