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

namespace ChapinesGT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DB_Contexto _context;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
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
        public IActionResult Login(string email, string contrasenia)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(contrasenia))
            {
                //DB_Contexto db = new DB_Contexto();
                var user = _context.Usuario.FirstOrDefault(e => e.Email == email && e.Contrasenia == contrasenia);
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(user.Email, true);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,"myName"),
                        new Claim(ClaimTypes.Role,"myRole")
                    };
                    var claimIdentity = new ClaimsIdentity(claims, "id card");
                    var claimPrinciple = new ClaimsPrincipal(claimIdentity);
                    var authenticationProperty = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    HttpContext.SignInAsync(claimPrinciple, authenticationProperty);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("No Encontramos tus datos");
                }
            }
            else
            {
                return View("LLena los campos para poder Iniciar sesion");
            }
        }

        public IActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index");
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