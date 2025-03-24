using MetekLisansApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models.ViewModels
{
    public class ProjeDurumuCreateViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Firma seçimi zorunludur")]
        public int FirmaId { get; set; }

        [Required(ErrorMessage = "Statü seçimi zorunludur")]
        public int StatuId { get; set; }

        [Required(ErrorMessage = "Lisans tarihi zorunludur")]
        public DateTime MevcutLisans { get; set; }

        public bool LisansAtansinmi { get; set; }

        [Required(ErrorMessage = "Lisans süresi zorunludur")]
        public int LisansSureId { get; set; }

        [Required(ErrorMessage = "Anlaşma tipi zorunludur")]
        public int AnlasmaId { get; set; }

        [Required(ErrorMessage = "Bakım paketi zorunludur")]
        public int BakimPaketId { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur")]
        public DateTime BakimSozlesmeBitisTarihi { get; set; }

        [StringLength(500, ErrorMessage = "Notlar 500 karakteri geçemez")]
        public string? Notlar { get; set; }

        [Required(ErrorMessage = "Sahip bilgisi zorunludur")]
        public int SahipId { get; set; }

        public List<Firma>? Firmalar { get; set; }
        public List<Statu>? Statuler { get; set; }
        public List<LisansSure>? LisansSureleri { get; set; }
        public List<BakimAnlasmasi>? BakimAnlasmalari { get; set; }
        public List<BakimPaketi>? BakimPaketleri { get; set; }
        public List<Sahip>? Sahipler { get; set; }
    }
}

