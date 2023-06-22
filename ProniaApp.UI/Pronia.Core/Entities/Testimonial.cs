using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
namespace Pronia.Core.Entities;

public class Testimonial : IEntity
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string UserPosition { get; set; } = null!;
    public string? Description { get; set; }
}
