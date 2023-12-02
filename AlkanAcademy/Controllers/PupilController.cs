using AlkanAcademy.Core.Service;
using AlkanAcademy.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlkanAcademy.WebUI.Controllers
{
    public class PupilController : Controller
    {
        private readonly ICoreService<Pupil> _pu;
        public PupilController(ICoreService<Pupil> pu)
        {
            _pu = pu;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PupList()
        {
            return View(_pu.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Pupil p)
        {
            if (p.PupilName != null && p.PupilSurname != null && p.Email != null && p.Password != null && p.Gender != null)
            {
                return _pu.Add(p) ? RedirectToAction("Index", "Home") : View();
            }
            ViewBag.PupilAddError = "Zorunlu Alanlar Boş Bırakılamaz";
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_pu.GetByID(id));
        }
        [HttpPost]
        public IActionResult Update(Pupil p)
        {
            if (p.PupilName != null && p.PupilSurname != null && p.Gender != null && p.Email != null && p.Password != null)
            {
                return _pu.Update(p) ? View("PupList", _pu.GetAll()) : View();

            }
            ViewBag.PupilUpdateError = "Zorunlu alanları boş bırakmayınız";
            return View();
        }
        public IActionResult Delete(int id)
        {
            return _pu.Delete(id) ? View("PupList", _pu.GetAll()) : View();
        }

    }
}
