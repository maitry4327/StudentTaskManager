using Microsoft.AspNetCore.Mvc;

namespace StudentTaskManager.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
