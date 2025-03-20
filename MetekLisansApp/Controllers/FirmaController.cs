using MetekLisansApp.Data;
using MetekLisansApp.Models;
using MetekLisansApp.Utility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MetekLisansApp.Controllers
{
    public class FirmaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenHelper _tokenHelper;
        public FirmaController(ApplicationDbContext context, TokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        public async Task<IActionResult> Index()
        {
            var httpContext = HttpContext;
            var isAuth = await _tokenHelper.CheckUserAuthhentication(httpContext);
            if (!isAuth)
            {
                return RedirectToAction("Login", "Account");
            }
            var userRole = HttpContext.Session.GetString("isAuthenticated");
            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Firma firma)
        {
            var httpContext = HttpContext;
            var isAuth = await _tokenHelper.CheckUserAuthhentication(httpContext);
            if (!isAuth)
            {
                return RedirectToAction("Login", "Account");
            }
            var userRole = HttpContext.Session.GetString("isAuthenticated");
            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                _context.Firmalar.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Index", firma);
        }
    }
}
