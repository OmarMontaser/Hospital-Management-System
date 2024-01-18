using HospitalServices;
using HospitalModels;
using HospitalViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hospital_Web.Areas.Doctor.Controllers
{

   [Area("Doctor")]
public class DoctorController : Controller
{ 
        private readonly IDoctorService  _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
    
        public IActionResult Index(int pageNumber =1 , int pageSize=5)
        {
            return View(_doctorService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult AddTiming()
        {
            Timing timing = new Timing();
            List<SelectListItem> morningShiftStart = new List<SelectListItem>();
            List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
            List<SelectListItem> afternoonShiftStart = new List<SelectListItem>();
            List<SelectListItem> afternoonShiftEnd = new List<SelectListItem>();
        
            for(int i =1; i< 11; i++)
            {
                morningShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            for (int i = 1; i < 11; i++)
            {
                morningShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 1; i < 11; i++)
            {
                afternoonShiftStart.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            for (int i = 1; i < 11; i++)
            {
                afternoonShiftEnd.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.morningStart = new SelectList(morningShiftStart, "Value", "Text");
            ViewBag.morningEnd = new SelectList(morningShiftEnd, "Value", "Text");
            ViewBag.afternoonStart = new SelectList(afternoonShiftStart, "Value", "Text");
            ViewBag.afternoonStart = new SelectList(afternoonShiftStart, "Value", "Text");
            TimingViewModel vm = new TimingViewModel();
            vm.Schedule = DateTime.Now;
            vm.Schedule = vm.Schedule.AddDays(1);   
            return View();
        }

        [HttpPost]
        public IActionResult AddingTiming(TimingViewModel vm)
        {
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var Claims = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if(Claims != null)
            {
                vm.Doctor.Id = Claims.Value;
                _doctorService.AddTiming(vm);
            }
             return RedirectToAction("Index");    
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ViewModel = _doctorService.GetTimingById(id);
            return View(ViewModel);
        }


    }
}
