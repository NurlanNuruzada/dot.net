using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Sponsor : IEntity
{
    public int Id { get; set; }
    [Required,MaxLength(300)]
    public string ImagePath { get; set; } = null!;
}
