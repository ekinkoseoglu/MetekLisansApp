using System.ComponentModel.DataAnnotations;

namespace MetekLisansApp.Models.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }

        public int SiraNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
