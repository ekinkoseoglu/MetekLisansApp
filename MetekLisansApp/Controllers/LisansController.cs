using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetekLisansApp.Data;
using MetekLisansApp.Models;
using MetekLisansApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetekLisansApp.Controllers
{
    public class LisansController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LisansController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var firmalar = await _context.Firmalar.ToListAsync();
            var menuler = await _context.Menuler.OrderBy(m => m.SiraNo).ToListAsync();
            var ekranlar = await _context.Ekranlar.ToListAsync();

            var userRole = HttpContext.Session.GetString("UserRole") ?? "User";

            var viewModel = new LisansCreateCompositeViewModel
            {
                Input = new LisansCreateInputModel(),
                Firmalar = firmalar,
                Menuler = menuler,
                Ekranlar = ekranlar,
                IsReadOnly = userRole != "Admin" 
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lisans = await _context.Lisanslar.FindAsync(id);
            if (lisans == null)
            {
                return NotFound();
            }

            var seciliDegerler = JsonSerializer.Deserialize<SeciliDegerlerDto>(lisans.SeciliDegerler);
            List<int> selectedEkranNo = new List<int>();
            if (seciliDegerler != null && !string.IsNullOrEmpty(seciliDegerler.SelectedEkranNo))
            {
                selectedEkranNo = seciliDegerler.SelectedEkranNo
                                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => int.Parse(s))
                                    .ToList();
            }

            var firmalar = await _context.Firmalar.ToListAsync();
            var menuler = await _context.Menuler.OrderBy(m => m.SiraNo).ToListAsync();
            var ekranlar = await _context.Ekranlar.ToListAsync();

            var inputModel = new LisansCreateInputModel
            {
                Id = lisans.Id,
                FirmaId = lisans.FirmaId,
                MachineCode = seciliDegerler?.MachineCode ?? string.Empty,
                LisansBitisTarihi = DateTime.ParseExact(seciliDegerler?.LisansBitisTarihi ?? "01.01.0001", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                SelectedEkranNo = selectedEkranNo,
                KullaniciId = lisans.OlusturanUserId
            };

            var userRole = HttpContext.Session.GetString("UserRole") ?? "User";

            var viewModel = new LisansCreateCompositeViewModel
            {
                Input = inputModel,
                Firmalar = firmalar,
                Menuler = menuler,
                Ekranlar = ekranlar,
                IsReadOnly = userRole != "Admin"
            };

            return View("Create", viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(LisansCreateCompositeViewModel model)
        {
            var input = model.Input;
            string ekranNoList = input.SelectedEkranNo != null ? string.Join(",", input.SelectedEkranNo) : "";
            var seciliDegerlerDto = new
            {
                SelectedEkranNo = ekranNoList,
                MachineCode = input.MachineCode,
                LisansBitisTarihi = input.LisansBitisTarihi.ToString("dd.MM.yyyy")
            };
            string jsonBody = JsonSerializer.Serialize(seciliDegerlerDto);



            //Http gönderme işlemi
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri("http://localhost:5000/api/Lisans/GenerateLisansKod"),
            //    Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            //};
            //var response = await client.SendAsync(request);
            //if (!response.IsSuccessStatusCode)
            //{
            //    ModelState.AddModelError("", "Lisans kodu oluşturulurken bir hata oluştu.");
            //    return RedirectToAction("Create");
            //}
            //dummyLisansKod = await response.Content.ReadAsStringAsync();

            string dummyLisansKod = "kjhkjkljh2lkjhlkjhlk2jh";


            var firma = await _context.Firmalar.FirstOrDefaultAsync(f => f.Id == input.FirmaId);
            if (firma == null)
            {
                ModelState.AddModelError("", "Seçilen firma bulunamadı.");
                return RedirectToAction("Create");
            }

            if (input.Id.HasValue)
            {
                var existingLisans = await _context.Lisanslar.FindAsync(input.Id.Value);
                if (existingLisans == null)
                {
                    return NotFound();
                }
                existingLisans.FirmaAd = firma.Ad;
                existingLisans.FirmaId = firma.Id;
                existingLisans.LisansVerilmeTarih = DateTime.Now;
                existingLisans.LisansBitisTarih = input.LisansBitisTarihi;
                existingLisans.LisansKodu = dummyLisansKod;
                existingLisans.OlusturanUserId = input.KullaniciId;
                existingLisans.SeciliDegerler = jsonBody;

                _context.Lisanslar.Update(existingLisans);
                await _context.SaveChangesAsync();
                TempData["LisansKodu"] = dummyLisansKod;
                return RedirectToAction("Create");
            }
            else
            {
                var lisans = new Lisans
                {
                    FirmaAd = firma.Ad,
                    FirmaId = firma.Id,
                    LisansVerilmeTarih = DateTime.Now,
                    LisansBitisTarih = input.LisansBitisTarihi,
                    LisansKodu = dummyLisansKod,
                    OlusturanUserId = input.KullaniciId,
                    SeciliDegerler = jsonBody
                };

                await _context.Lisanslar.AddAsync(lisans);
                await _context.SaveChangesAsync();
                TempData["LisansKodu"] = dummyLisansKod;
                return RedirectToAction("Create");
            }
        }
    }
}
