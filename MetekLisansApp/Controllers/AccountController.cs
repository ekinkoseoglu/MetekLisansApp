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
                return Json(new
                {
                    success = true,
                    kullaniciId = kullanici.Id,
                    isAdmin = kullanici.IsAdmin
                });
            }

            return Json(new
            {
                success = false,
                message = "Kullanıcı adı veya şifre hatalı."
            });
        }
    }
}
