using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models
{
    public class Kullanici
    {
        public int Id { get; set; }

        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string Sifre { get; set; }

        public bool IsAdmin { get; set; }
    }
}
