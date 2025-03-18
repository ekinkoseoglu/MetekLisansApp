using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models
{
    public class Firma
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        public string Kod { get; set; }
    }
}
