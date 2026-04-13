using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.WebHost.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
