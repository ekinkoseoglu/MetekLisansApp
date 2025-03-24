using MetekLisansApp.Data;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Utility;
using MetekLisansApp.Utility.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MetekLisansApp.Controllers
{
    public class EkranController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenHelper _tokenHelper;
        public EkranController(ApplicationDbContext context,
            TokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }
        [Auth("Admin, Editor, User")]
        public IActionResult Index()
        {
            ViewData["Menuler"] = _context.Menuler.OrderBy(m => m.Id).ToList();
            return View();
        }

        [HttpPost]
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
            return View("Index",ekran);
        }
    }
}
