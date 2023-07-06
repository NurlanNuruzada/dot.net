using Microsoft.AspNetCore.Mvc;

namespace ProniaApp.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
