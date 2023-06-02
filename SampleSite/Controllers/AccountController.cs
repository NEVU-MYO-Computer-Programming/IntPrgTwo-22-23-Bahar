using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using SampleSite.Models;
using SampleSite.ViewModels;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace SampleSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly SampleContext _context;


        public AccountController(IConfiguration _con)
        {
            _context = new SampleContext(_con);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CheckUser(entity.Username, entity.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, entity.Username));
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        throw new Exception("User not found!");
                    }
                }
                else
                {
                    throw new Exception("Please check form data!");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View(entity);
        }


        public IActionResult Logout() { return View(); }


        private bool CheckUser(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password && x.IsActive == 1);
            return user != null;
        }


    }
}
