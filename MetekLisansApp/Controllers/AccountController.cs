using MetekLisansApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MetekLisansApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
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
                // Oturum açıldıktan sonra hem KullaniciId hem de Role bilgisi session’a kaydediliyor
                HttpContext.Session.SetString("KullaniciId", kullanici.Id.ToString());
                HttpContext.Session.SetString("UserRole", kullanici.Role);
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
    }
}
