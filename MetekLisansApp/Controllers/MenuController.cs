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

            // GET: Menu/Create – Menü ekleme formu
            public IActionResult Create()
            {
                return View();
            }

            // POST: Menu/Create – Formdan gelen verilerle menü ekleme işlemi
            [HttpPost]
            public async Task<IActionResult> Create(Menu menu)
            {
                if (ModelState.IsValid)
                {
                    menu.CreatedDate = DateTime.Now;
                    menu.UpdatedDate = DateTime.Now;
                    _context.Menuler.Add(menu);
                    await _context.SaveChangesAsync();
                    // Menü başarıyla eklendikten sonra formu temizleyip yeniden yükleyebilirsiniz.
                    return RedirectToAction("Create");
                }
                return View(menu);
            }
        }
    
}
