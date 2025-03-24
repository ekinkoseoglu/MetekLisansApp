using MetekLisansApp.Data;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Utility;
using MetekLisansApp.Utility.Attributes;
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
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Create(Firma firma)
        { 
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
