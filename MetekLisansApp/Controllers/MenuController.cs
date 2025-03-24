using MetekLisansApp.Data;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Utility;
using Microsoft.AspNetCore.Mvc;
using MetekLisansApp.Utility.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
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
            return View("Index", menu);
        }
    }
}
