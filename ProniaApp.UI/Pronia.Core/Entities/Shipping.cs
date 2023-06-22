using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Shipping : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(55)]
    public string Title { get; set; } = null!;
    [Required, MaxLength(155)]
    public string Description { get ; set ; } = null!;
    [Required,MaxLength(255)]
    public string ImagePath { get ; set ; } = null!;
    [Required, MaxLength(255)]
    public string ImageDesc { get ; set ; } = null!;
}
