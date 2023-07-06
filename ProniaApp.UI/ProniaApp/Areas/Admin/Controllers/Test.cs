using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.Areas.Admin.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
