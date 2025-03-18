using MetekLisansApp.Data;
using MetekLisansApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MetekLisansApp.Controllers
{
    public class FirmaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FirmaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Firma firma)
        {
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
