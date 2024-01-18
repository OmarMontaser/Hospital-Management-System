using HospitalServices;
using HospitalViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Web.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class RoomController : Controller
    {
        private IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }

        public IActionResult Index(int pageNumber , int pageSize=5 )
        {
            return View(_room.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }

    }
}
