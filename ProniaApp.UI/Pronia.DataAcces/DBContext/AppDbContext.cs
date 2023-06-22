

using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities;

namespace Pronia.DataAcces.DBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Banner> Banners { get; set; }
}
