using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetekLisansApp.Data;
using MetekLisansApp.Models;
using System.Linq;
using System.Threading.Tasks;
using MetekLisansApp.Utility;

namespace MetekLisansApp.Controllers
{
    public class LisansGecmisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenHelper _tokenHelper;

        public LisansGecmisController(ApplicationDbContext context, TokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        public async Task<IActionResult> Index()
        {
            var httpContext = HttpContext;
            var isAuth = await _tokenHelper.CheckUserAuthhentication(httpContext);
            if (!isAuth)
            {
                return RedirectToAction("Login", "Account");
            }

            var userRole = HttpContext.Session.GetString("isAuthenticated");
            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var lisanslar = await _context.Lisanslar
                .OrderByDescending(l => l.LisansVerilmeTarih)
                .ToListAsync();

            return View(lisanslar);
        }
    }
}
