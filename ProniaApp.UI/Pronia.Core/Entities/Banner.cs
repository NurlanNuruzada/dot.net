using Pronia.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Entities;

public class Banner : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}

