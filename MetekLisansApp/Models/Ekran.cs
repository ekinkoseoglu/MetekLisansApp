using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models
{
    public class Ekran
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }

        public int EkranNo { get; set; }

        // Hangi menüye ait olduğu (foreign key)
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menu { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
