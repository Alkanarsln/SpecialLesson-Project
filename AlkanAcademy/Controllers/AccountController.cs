using AlkanAcademy.Core.Service;
using AlkanAcademy.Model.Entities;
using AlkanAcademy.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlkanAcademy.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly ICoreService<Pupil> _pupildb;
        private readonly ICoreService<Instructor> _Instructordb;
        public AccountController(ICoreService<Pupil> pupildb, ICoreService<Instructor> instructordb)
        {
            _pupildb = pupildb;
            _Instructordb = instructordb;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (lvm.LoginType == 1)
            {
                var kayit = _Instructordb.GetRecord(x => x.Email == lvm.Email && x.Password == lvm.Password);
                if (kayit != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim ("ID", kayit.ID.ToString()),
                        new Claim ("LoginType", lvm.LoginType.ToString()),
                        new Claim (ClaimTypes.Email, lvm.Email),
                        new Claim (ClaimTypes.Anonymous,lvm.Password)

                    };

                    var user = new ClaimsIdentity(claims, "Login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(user);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Instructor", new { area = "User" });
                }

            }

            else if (lvm.LoginType == 2)
            {
                var kayit = _pupildb.GetRecord(x => x.Email == lvm.Email && x.Password == lvm.Password);
                if (kayit != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("OGRID", kayit.ID.ToString()),
                        new Claim("LoginType", lvm.LoginType.ToString()),
                        new Claim(ClaimTypes.Email, lvm.Email),
                        new Claim(ClaimTypes.Anonymous, lvm.Password)

                    };
                    var user = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(user);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Pupil", new { area = "User" });

                }

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
