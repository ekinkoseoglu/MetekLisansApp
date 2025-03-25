using MetekLisansApp.Data;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Utility;
using MetekLisansApp.Utility.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Auth("Admin, Editor, User")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Liste()
        {
            var firmalar = await _context.Firmalar.ToListAsync();
            return Json(firmalar);
        }

        [Auth("Admin, Editor")]
        public IActionResult Create()
        {
            return View(new Firma());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Create(Firma firma)
        {
            if (ModelState.IsValid)
            {
    
                _context.Firmalar.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(firma);
        }

        [Auth("Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return View("Create", firma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Edit(Firma firma)
        {
            if (ModelState.IsValid)
            {
                _context.Firmalar.Update(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Create", firma);
        }
    }
}
