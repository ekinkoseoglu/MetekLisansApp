using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetekLisansApp.Data;
using MetekLisansApp.Models;
using MetekLisansApp.Models.Entities;
using MetekLisansApp.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using MetekLisansApp.Utility.Attributes;

namespace MetekLisansApp.Controllers
{
    public class ProjeDurumuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjeDurumuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Auth("Admin, Editor")]
        public async Task<IActionResult> Liste(string firmaAd)
        {
            var query = _context.ProjeDurumu
                                .Include(pd => pd.Firma) 
                                .Include(pd => pd.Statu) 
                                .Include(pd => pd.LisansSure) 
                                .Include(pd => pd.BakimAnlasmasi) 
                                .Include(pd => pd.BakimPaketi) 
                                .Include(pd => pd.Sahip) 
                                .AsQueryable(); 

            if (!string.IsNullOrEmpty(firmaAd))
            {
                query = query.Where(pd => pd.Firma.Ad.Contains(firmaAd));
            }

            var totalCount = await query.CountAsync();

            var projeDurumlari = await query
                .OrderBy(pd => pd.Id)
                .ToListAsync(); 

            var viewModel = new ProjeDurumuListeViewModel
            {
                ProjeDurumlari = projeDurumlari,
                FirmaAdFilter = firmaAd, 
                TotalCount = totalCount
            };

            return Json(viewModel.ProjeDurumlari);
        }

        [HttpGet]
        [Auth("Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            var projeDurumu = await _context.ProjeDurumu
                .Include(pd => pd.Firma)
                .Include(pd => pd.Statu)
                .Include(pd => pd.LisansSure)
                .Include(pd => pd.BakimAnlasmasi)
                .Include(pd => pd.BakimPaketi)
                .Include(pd => pd.Sahip)
                .FirstOrDefaultAsync(pd => pd.Id == id);

            if (projeDurumu == null)
                return NotFound();

            var viewModel = new ProjeDurumuCreateViewModel
            {
                Id = projeDurumu.Id,
                FirmaId = projeDurumu.FirmaId,
                StatuId = projeDurumu.StatuId,
                MevcutLisans = projeDurumu.MevcutLisans,
                LisansAtansinmi = projeDurumu.LisansAtansinmi,
                LisansSureId = projeDurumu.LisansSureId,
                AnlasmaId = projeDurumu.AnlasmaId,
                BakimPaketId = projeDurumu.BakimPaketId,
                BakimSozlesmeBitisTarihi = projeDurumu.BakimSozlesmeBitisTarihi,
                Notlar = projeDurumu.Notlar,
                SahipId = projeDurumu.SahipId,

                Firmalar = await _context.Firmalar.ToListAsync(),
                Statuler = await _context.Statu.ToListAsync(),
                LisansSureleri = await _context.LisansSure.ToListAsync(),
                BakimAnlasmalari = await _context.BakimAnlasmasi.ToListAsync(),
                BakimPaketleri = await _context.BakimPaketi.ToListAsync(),
                Sahipler = await _context.Sahip.ToListAsync()
            };

            return View("Create", viewModel);
        }

        [HttpGet]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Create()
        {
            var viewModel = await GetCreateViewModelAsync(new ProjeDurumuCreateViewModel());
            return View(viewModel);
        }
        

        [HttpPost]
        [Auth("Admin, Editor")]
        public async Task<IActionResult> Create(ProjeDurumuCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = await GetCreateViewModelAsync(model);
                return View(viewModel);
            }

            if (model.Id.HasValue && model.Id.Value > 0)
            {
                var existing = await _context.ProjeDurumu.FindAsync(model.Id.Value);
                if (existing == null)
                    return NotFound();

                existing.FirmaId = model.FirmaId;
                existing.StatuId = model.StatuId;
                existing.MevcutLisans = model.MevcutLisans;
                existing.LisansAtansinmi = model.LisansAtansinmi;
                existing.LisansSureId = model.LisansSureId;
                existing.AnlasmaId = model.AnlasmaId;
                existing.BakimPaketId = model.BakimPaketId;
                existing.BakimSozlesmeBitisTarihi = model.BakimSozlesmeBitisTarihi;
                existing.Notlar = model.Notlar;
                existing.SahipId = model.SahipId;

                _context.ProjeDurumu.Update(existing);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage = "Proje durumu başarıyla güncellendi.";
            }
            else
            {
                var yeni = new ProjeDurumu
                {
                    FirmaId = model.FirmaId,
                    StatuId = model.StatuId,
                    MevcutLisans = model.MevcutLisans,
                    LisansAtansinmi = model.LisansAtansinmi,
                    LisansSureId = model.LisansSureId,
                    AnlasmaId = model.AnlasmaId,
                    BakimPaketId = model.BakimPaketId,
                    BakimSozlesmeBitisTarihi = model.BakimSozlesmeBitisTarihi,
                    Notlar = model.Notlar,
                    SahipId = model.SahipId
                };

                _context.ProjeDurumu.Add(yeni);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage = "Proje durumu başarıyla oluşturuldu.";
            }

            return RedirectToAction("Index");
        }

        private async Task<ProjeDurumuCreateViewModel> GetCreateViewModelAsync(ProjeDurumuCreateViewModel model)
        {
            model.Firmalar ??= await _context.Firmalar.ToListAsync();
            model.Statuler ??= await _context.Statu.ToListAsync();
            model.LisansSureleri ??= await _context.LisansSure.ToListAsync();
            model.BakimAnlasmalari ??= await _context.BakimAnlasmasi.ToListAsync();
            model.BakimPaketleri ??= await _context.BakimPaketi.ToListAsync();
            model.Sahipler ??= await _context.Sahip.ToListAsync();
            return model;
        }

    }
}