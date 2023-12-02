using Microsoft.AspNetCore.Mvc;

namespace AlkanAcademy.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
