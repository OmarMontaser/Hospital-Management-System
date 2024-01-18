using HospitalServices;
using HospitalViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital_Web.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class ContactController : Controller
    {
        private IContactService _contact;
        private IHospitalInfo _hospital;

        public ContactController(IContactService contact, IHospitalInfo hospital)
        {
            _contact = contact;
            _hospital = hospital;
        }


        public IActionResult Index(int PageSize , int PageNumber)
        {
            return View(_contact.GetAll(PageSize , PageNumber));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(_hospital.GetAll(), "id", "Name");
            var viewmodel = _contact.GetContactById(id);
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospital = new SelectList(_hospital.GetAll(), "id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            _contact.InsertContact(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
