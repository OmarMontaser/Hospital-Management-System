using Microsoft.AspNetCore.Mvc;

namespace Hospital_Web.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
