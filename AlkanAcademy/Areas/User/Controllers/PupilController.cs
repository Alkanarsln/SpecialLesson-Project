using AlkanAcademy.Core.Service;
using AlkanAcademy.Model.Entities;
using AlkanAcademy.WebUI.Areas.User.Models.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AlkanAcademy.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class PupilController : Controller
    {
        private readonly ICoreService<Instructor> _Ins;
        private readonly ICoreService<Pupil> _pupil;
        private readonly ICoreService<Branch> _branch;
        public PupilController(ICoreService<Instructor> Ins, ICoreService<Pupil> pupil, ICoreService<Branch> branch)
        {
            _Ins = Ins;
            _pupil = pupil;
            _branch = branch;
        }
        public IActionResult Index()
        {
            return View(_Ins.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_Ins.GetByID(id));
        }


        public IActionResult BranchList()
        {

         return View(_branch.GetAll());

        }

        public IActionResult Info()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("OGRID")).Value);
            var result = _pupil.GetRecord(x => x.ID == id);


            var record = new PupilDto()
            {
                PupilID = result.ID,
                PupilName = result.PupilName,
                PupilSurname = result.PupilSurname,
                Email = result.Email,
                Password = result.Password,
                Gender = result.Gender,

            };

            return View(record);

        }
        public IActionResult InsAdd(int id)
        {
            return View(_Ins.GetByID(id));
        }

        [HttpPost]
        public IActionResult InsAdd(Instructor I, string PuName, string PuSurname)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("OGRID")).Value);
            var result = _branch.GetRecord(x => x.PupilID == id);

            var record = new Branch()
            {
                InstructorName = I.InstructorName,
                InstructorSurname = I.InstructorSurname,
                BranchName = I.BranchName,
                PupilName = PuName,
                PupilSurname = PuSurname,
                InstructorID = I.ID,
                PupilID = id


            };

            return _branch.Add(record) ? RedirectToAction("Index", "Pupil", new { Areas = "User" }) : View();



        }
        public IActionResult InsDelete()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("OGRID")).Value);

            var result = _branch.GetRecord(x => x.PupilID == id);

            return _branch.Delete(result.ID) ? RedirectToAction("Index", "Pupil", new { Areas = "User" }) : View();
        }
        public IActionResult UpdatePup()
        {
            var ogrid = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("OGRID")).Value);
            var kayit = _pupil.GetRecord(x => x.ID == ogrid);

            if (kayit != null)
            {
                var Pup = _pupil.GetByID(kayit.ID);

                var record = new Pupil()
                {
                    ID = ogrid,
                    PupilName = Pup.PupilName,
                    PupilSurname = Pup.PupilSurname,
                    Email = Pup.Email,
                    Password = Pup.Password,
                    Gender = Pup.Gender,


                };

                return View(record);
            }

           
            return RedirectToAction("Info", "Pupil", "User");
        }

        [HttpPost]
        public IActionResult UpdatePup(Pupil P)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("OGRID")).Value);
            var Kayit = _pupil.GetRecord(x => x.ID == id);

            if (Kayit != null)
            {
                Kayit.PupilName = P.PupilName;
                Kayit.PupilSurname = P.PupilSurname;

                Kayit.Email = P.Email;
                Kayit.Password = P.Password;
                Kayit.Gender = P.Gender;

                return _pupil.Update(Kayit) ? RedirectToAction("Info", "Pupil", "User") : View();
            }
            return View();
        }
        

    }
}

