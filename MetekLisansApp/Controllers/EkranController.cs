using MetekLisansApp.Data;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Utility;
using MetekLisansApp.Utility.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetekLisansApp.Controllers
{
    public class EkranController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenHelper _tokenHelper;
        public EkranController(ApplicationDbContext context, TokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        [Auth("Admin, Editor, User")]
        public IActionResult Index()
        {
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.SiraNo).ToList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Liste()
        {
            var ekranlar = await _context.Ekranlar.Include(e => e.Menu).ToListAsync();
            return Json(ekranlar);
        }

        [Auth("Admin, Editor")]
        public IActionResult Create()
        {
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.SiraNo).ToList();
            return View(new Ekran());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Create(Ekran ekran)
        {
            if (ModelState.IsValid)
            {
                ekran.CreatedDate = DateTime.Now;
                ekran.UpdatedDate = DateTime.Now;
                _context.Ekranlar.Add(ekran);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.SiraNo).ToList();
            return View(ekran);
        }

        [Auth("Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            var ekran = await _context.Ekranlar.FindAsync(id);
            if (ekran == null)
            {
                return NotFound();
            }
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.SiraNo).ToList();
            return View("Create", ekran);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Edit(Ekran ekran)
        {
            if (ModelState.IsValid)
            {
                ekran.UpdatedDate = DateTime.Now;
                _context.Ekranlar.Update(ekran);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.SiraNo).ToList();
            return View("Create", ekran);
        }
    }
}
