using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAcces.DBContext;
using ProniaApp.ViewModels;

namespace ProniaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Shippings = await _context.Shippings.ToListAsync(),
                Products = await _context.Products.ToListAsync(),
                Banners = await _context.Banners.ToListAsync()
            };
            return View(homeVm);
        }
    }
}
