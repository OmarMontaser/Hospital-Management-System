using Microsoft.AspNetCore.Mvc;
using HospitalServices;
namespace Hospital_Web.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class UserController : Controller
    {
        private IApplicationUserService _userService;
        public UserController(IApplicationUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(int pageNumber = 1 , int pageSize=5)
        {
            return View(_userService.GetAll(pageNumber , pageSize));
        }

        public IActionResult AllDoctor(int pageNumber = 1, int pageSize = 5)
        {
            return View(_userService.GetAllDoctor(pageNumber, pageSize));
        }


    }
}
