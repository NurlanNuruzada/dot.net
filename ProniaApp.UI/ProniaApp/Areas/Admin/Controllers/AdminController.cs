using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Areas.Admin.Extension;
using Pronia.Areas.Admin.ProductViewModel;
using Pronia.Core.Entities;
using Pronia.DataAcces.DBContext;

namespace Pronia.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles ="Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public AdminController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
    {
        _context = context;
        _mapper = mapper;
        _env = env;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Products.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create(ProductView product_view)
    {
        if (!ModelState.IsValid)
        {
            return View(product_view);
        }
        if (!product_view.MainImage.CorrectForamt("image"))
        {
            ModelState.AddModelError("MImage", "Select correct image format!");
            return View(product_view);
        }
        if (!product_view.MainImage.CheckSize(100))
        {
            ModelState.AddModelError("MImage", "Size must be less than 100 kb");
            return View(product_view);
        }

        string filePath = await product_view.MainImage.CopyFileAsync(_env.WebRootPath, "assetsf", "images", "product");
        Product product = _mapper.Map<Product>(product_view);
        product.HoverImage = filePath;
        product.MainImage = filePath; 

        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var product = _context.Products.Find(id);
        if (product is null)
        {
            return NotFound();
        }
        return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(product);                     
        }
        Product? product1 = await _context.Products.AsNoTracking().FirstOrDefaultAsync(s=>s.Id==id);
        if (product1 is null)
        {
            return NotFound();
        }
        _context.Entry(product).State= EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null)
        {
            return NotFound();
        }
        return View();
    }
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
