using MetekLisansApp.Data;
using MetekLisansApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MetekLisansApp.Controllers
{
    public class EkranController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EkranController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var userRole = HttpContext.Session.GetString("isAuthenticated");
            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.Id).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ekran ekran)
        {
            var userRole = HttpContext.Session.GetString("isAuthenticated");
            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                ekran.CreatedDate = DateTime.Now;
                ekran.UpdatedDate = DateTime.Now;
                _context.Ekranlar.Add(ekran);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.SiraNo).ToList();
            return View(ekran);
        }
    }
}
