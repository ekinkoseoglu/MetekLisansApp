using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetekLisansApp.Data;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Utility;
using MetekLisansApp.Utility.Attributes;

namespace MetekLisansApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenHelper _tokenHelper;

        public MenuController(ApplicationDbContext context, TokenHelper tokenHelper)
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
            var menuler = await _context.Menuler.ToListAsync();
            return Json(menuler);
        }

        [Auth("Admin, Editor")]
        public IActionResult Create()
        {
            return View(new Menu());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.CreatedDate = DateTime.Now;
                menu.UpdatedDate = DateTime.Now;
                _context.Menuler.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        [Auth("Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View("Create", menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.UpdatedDate = DateTime.Now;
                _context.Menuler.Update(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Create", menu);
        }
    }
}
