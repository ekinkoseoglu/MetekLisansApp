using MetekLisansApp.Data;
using MetekLisansApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MetekLisansApp.Controllers
{
    
        public class MenuController : Controller
        {
            private readonly ApplicationDbContext _context;

            public MenuController(ApplicationDbContext context)
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

            return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Menu menu)
        {
            var userRole = HttpContext.Session.GetString("isAuthenticated");
            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
                {
                    menu.CreatedDate = DateTime.Now;
                    menu.UpdatedDate = DateTime.Now;
                    _context.Menuler.Add(menu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create");
                }
                return View(menu);
            }
        }
    
}
