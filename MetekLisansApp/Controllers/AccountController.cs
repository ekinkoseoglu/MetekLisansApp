using MetekLisansApp.Data;
using MetekLisansApp.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MetekLisansApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenHelper _tokenHelper;
        public AccountController(ApplicationDbContext context, TokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Kullanicilar
               .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);
            if (kullanici != null)
            {
                var token = _tokenHelper.GenerateToken(kullanici.KullaniciAdi, kullanici.Sifre);

                HttpContext.Session.SetString("KullaniciId", kullanici.Id.ToString());
                HttpContext.Session.SetString("UserRole", kullanici.Role);
                HttpContext.Session.SetString("isAuthenticated", "1");
                HttpContext.Session.SetString("userToken", token);

                return Json(new
                {
                    success = true,
                    kullaniciId = kullanici.Id,
                    rol = kullanici.Role
                });
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return Json(new
            {
                success = false,
                message = "Kullanıcı adı veya şifre hatalı."
            });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
