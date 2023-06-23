

using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pronia.Core.Entities;


namespace Pronia.DataAcces.DBContext;

public class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Sponsor> sponsors { get; set; }
    public DbSet<Blog> blogs { get; set; }
    public DbSet<Testimonial> Testimonial { get; set; }
}
