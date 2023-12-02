using AlkanAcademy.Core.Service;
using AlkanAcademy.Model.Entities;
using AlkanAcademy.WebUI.Areas.User.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AlkanAcademy.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class InstructorController : Controller
    {
        private readonly ICoreService<Instructor> _Ins;
        private readonly ICoreService<Pupil> _pupil;
        private readonly ICoreService<Branch> _branch;
        public InstructorController(ICoreService<Instructor> Ins, ICoreService<Pupil> pupil, ICoreService<Branch> branch)
        {
            _Ins = Ins;
            _pupil = pupil;
            _branch = branch;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var result = _Ins.GetRecord(x => x.ID == id);


            var record = new InstructorDto()
            {
                InstructorID = result.ID,
                InstructorName = result.InstructorName,
                InstructorSurname = result.InstructorSurname,
                Email = result.Email,
                Password= result.Password,
                Adress = result.Adress,
                Phone = result.Phone,
                Price = result.Price,
                BranchName= result.BranchName,
                Description= result.Description,


            };

            return View(record);
            
        }

        public IActionResult UpdateIns()
        {
            var Insid = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var kayit = _Ins.GetRecord(x => x.ID == Insid);
            
            if (kayit != null)
            {
                var Ins = _Ins.GetByID(kayit.ID);

                var record = new Instructor()
                {
                    ID= Insid,
                    InstructorName = Ins.InstructorName,
                    InstructorSurname = Ins.InstructorSurname,
                    BranchName = Ins.BranchName,
                    Email = Ins.Email,
                    Password = Ins.Password,
                    Adress = Ins.Adress,
                    Phone = Ins.Phone,
                    Price = Ins.Price,
                    Description = Ins.Description,
                    
                };

                return View(record);
            }

            ViewBag.EditError = "Güncellenecek Bilgi Bulunamadı";
            return RedirectToAction("Info", "Instructor","User");
        }

        [HttpPost]
        public IActionResult UpdateIns(Instructor I)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var Kayit = _Ins.GetRecord(x => x.ID == id);

            if (Kayit!=null)
            {
                Kayit.InstructorName = I.InstructorName;
                Kayit.InstructorSurname = I.InstructorSurname;
                Kayit.BranchName = I.BranchName;
                Kayit.Email = I.Email;
                Kayit.Password = I.Password;
                Kayit.Adress = I.Adress;
                Kayit.Phone = I.Phone;
                Kayit.Price = I.Price;
                Kayit.Description = I.Description;
                return _Ins.Update(Kayit) ? RedirectToAction("Info", "Instructor","User") : View();
            }
            return View();
        }

        public IActionResult BranchList()
        {
            return View(_branch.GetAll());
        }


    }
}
