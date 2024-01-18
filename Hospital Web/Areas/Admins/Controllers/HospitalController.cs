using HospitalServices;
using HospitalViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Web.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class HospitalController : Controller
    {
        private IHospitalInfo _hospitalinfo;

        public HospitalController(IHospitalInfo hospitalinfo)
        {
            _hospitalinfo = hospitalinfo;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_hospitalinfo.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewmodel = _hospitalinfo.GetHospitalById(id);
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel vm)
        {
            _hospitalinfo.UpdateHospitalInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalInfoViewModel vm)
        {
            _hospitalinfo.InsertHospitalInfo(vm);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            _hospitalinfo.DeleteHospitalInfo(id);
            return RedirectToAction("Indxe");
        }

    }
}
