using AlkanAcademy.Core.Service;
using AlkanAcademy.Model.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlkanAcademy.WebUI.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ICoreService<Instructor> _Ins;
     
        public InstructorController(ICoreService<Instructor> Ins)
        {
            _Ins = Ins;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsList()
        {
            return View(_Ins.GetAll());
        }
        
        public IActionResult Details(int id)
        {
            return View(_Ins.GetByID(id));
        }

      


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor In)
        {
            if (In.InstructorName != null && In.InstructorSurname != null && In.BranchName != null && In.Email != null && In.Password != null && In.Adress != null && In.Phone != null && In.Price != null && In.Description != null )
            {
                return _Ins.Add(In) ? RedirectToAction("Index", "Home") : View();

            }
            ViewBag.InstructorAddError = "Zorunlu alanları boş bırakmayınız";
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_Ins.GetByID(id));
        }
        [HttpPost]
        public IActionResult Update(Instructor I)
        {
            if (I.InstructorName != null && I.InstructorSurname != null && I.Email != null && I.Password != null && I.Adress != null && I.Phone != null && I.Price != null && I.Description != null && I.BranchName!=null)
            {
                return _Ins.Update(I) ? View("InsList", _Ins.GetAll()) : View();

            }
            ViewBag.InstructorUpdateError = "Zorunlu alanları boş bırakmayınız";
            return View();
        }
        public IActionResult Delete(int id)
        {
            return _Ins.Delete(id) ? View("InsList", _Ins.GetAll()) : View();
        }
       

    }


}

