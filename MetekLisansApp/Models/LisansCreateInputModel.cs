using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models
{
    
    public class LisansCreateInputModel
    {
        public int? Id { get; set; }

        [Required]
        public int FirmaId { get; set; }

        [Required]
        public List<int> SelectedEkranNo { get; set; }

        [Required]
        public string MachineCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LisansBitisTarihi { get; set; }

        [Required]
        public int KullaniciId { get; set; }
    }
}

