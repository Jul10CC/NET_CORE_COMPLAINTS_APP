using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChapinesGT.Models;
using ChapinesGT.Data;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ChapinesGT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DB_Contexto _context;

        public HomeController(DB_Contexto context)
        {
            _context = context;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string contrasenia)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(contrasenia))
            {
                //DB_Contexto db = new DB_Contexto();
                var user = _context.Usuario.FirstOrDefault(e => e.Email == email && e.Contrasenia == contrasenia);
                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.SerialNumber, Convert.ToString(user.Id)));
                    claims.Add(new Claim(ClaimTypes.Name, user.Email));

                    // Create Identity
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    // Create Principal 
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Sign In
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", new { message = "No se encontraron los datos"});
                }
            }
            else
            {
                return RedirectToAction("Login", new { message = "Es necesario ingresar los datos" });
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
