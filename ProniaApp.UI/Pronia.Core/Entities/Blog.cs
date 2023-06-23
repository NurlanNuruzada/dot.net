using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Blog : IEntity
{
    public int Id { get; set; }
    [Required,MaxLength(90)]
    public string Who { get; set; } = null!;
    public DateTime dateTime { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public string ImagePath { get; set; } = null!;
}
