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

        // GET: Ekran/Create – Ekran ekleme formu, Menü listesini view'e gönderiyoruz
        public IActionResult Create()
        {
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.Id).ToList();
            return View();
        }

        // POST: Ekran/Create – Formdan gelen verilerle ekran ekleme işlemi
        [HttpPost]
        public async Task<IActionResult> Create(Ekran ekran)
        {
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
