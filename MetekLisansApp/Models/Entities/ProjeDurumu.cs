using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models.Entities
{
    public class ProjeDurumu
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Firma")]
        [Required(ErrorMessage = "Firma seçimi zorunludur")]
        [Display(Name = "Firma")]
        public int FirmaId { get; set; }
        public Firma Firma { get; set; } // Mevcut 'Firma' entity'niz

        [ForeignKey("Statu")]
        [Required(ErrorMessage = "Statü seçimi zorunludur")]
    
        public int StatuId { get; set; }
        public Statu Statu { get; set; }

        public DateTime MevcutLisans { get; set; }

        public bool LisansAtansinmi { get; set; } // LisansAtansınmı adını sadeleştirdim.

        [ForeignKey("LisansSure")]
        public int LisansSureId { get; set; }
        public LisansSure LisansSure { get; set; }

        [ForeignKey("BakimAnlasmasi")]
        public int AnlasmaId { get; set; }
        public BakimAnlasmasi BakimAnlasmasi { get; set; }

        [ForeignKey("BakimPaketi")]
        public int BakimPaketId { get; set; }
        public BakimPaketi BakimPaketi { get; set; }

        public DateTime BakimSozlesmeBitisTarihi { get; set; }

        public string? Notlar { get; set; }

        [ForeignKey("Sahip")]
        public int SahipId { get; set; }
        public Sahip Sahip { get; set; }
    }
}
