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

        // Rol bilgisi: "Admin", "Editor" veya "User"
        [Required]
        public string Role { get; set; }
    }
}
