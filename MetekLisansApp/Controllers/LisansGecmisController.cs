using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetekLisansApp.Data;
using MetekLisansApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MetekLisansApp.Controllers
{
    public class LisansGecmisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LisansGecmisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tüm lisansları tek bir listede getirir
        public async Task<IActionResult> Index()
        {
            var lisanslar = await _context.Lisanslar
                .OrderByDescending(l => l.LisansVerilmeTarih)
                .ToListAsync();

            return View(lisanslar);
        }
    }
}
