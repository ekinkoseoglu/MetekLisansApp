using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetekLisansApp.Data;
using MetekLisansApp.Models;
using System.Linq;
using System.Threading.Tasks;
using MetekLisansApp.Utility;
using MetekLisansApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Core;
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

            var isAuthenticated = HttpContext.Session.GetString("isAuthenticated");
            if (isAuthenticated == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userRole = HttpContext.Session.GetString("UserRole");

            ViewData["UserRole"] = userRole;

            var lisanslar = await _context.Lisanslar
                .OrderByDescending(l => l.LisansVerilmeTarih)
                .ToListAsync();

            var firmaIds = lisanslar.Select(l => l.FirmaId).Distinct().ToList();
            var firmalarDict = await _context.Firmalar
                .Where(f => firmaIds.Contains(f.Id))
                .ToDictionaryAsync(f => f.Id, f => f.Ad);

            var viewModel = lisanslar.Select(l => new LisansGecmisViewModel
            {
                Lisans = l,
                FirmaAd = firmalarDict.ContainsKey(l.FirmaId) ? firmalarDict[l.FirmaId] : ""
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> GetList()
        {
            List<LisansGecmisViewModel> viewModel = new List<LisansGecmisViewModel>();
            var lisanslar = await _context.Lisanslar
                .OrderByDescending(l => l.LisansVerilmeTarih)
                .ToListAsync();
            var firmaIds = lisanslar.Select(l => l.FirmaId).Distinct().ToList();
            var firmalarDict = await _context.Firmalar
                .Where(f => firmaIds.Contains(f.Id))
                .ToDictionaryAsync(f => f.Id, f => f.Ad);
            viewModel = lisanslar.Select(l => new LisansGecmisViewModel
            {
                Lisans = l,
                FirmaAd = firmalarDict.ContainsKey(l.FirmaId) ? firmalarDict[l.FirmaId] : ""
            }).ToList();
            return Json(viewModel);
        }
    }
}
