using System.ComponentModel.DataAnnotations;

namespace Pronia.Areas.Admin.ProductViewModel;

public class ProductView
{
    [Required]
    public IFormFile MainImage { get; set; } = null!;
    [Required]
    public IFormFile HoverImage { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Starts { get; set; }
}

