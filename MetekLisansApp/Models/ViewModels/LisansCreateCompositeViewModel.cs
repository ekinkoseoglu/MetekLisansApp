using MetekLisansApp.Models.Entities;
using MetekLisansApp.Models.InputModels;

namespace MetekLisansApp.Models.ViewModels
{
    public class LisansCreateCompositeViewModel
    {
        public LisansCreateInputModel Input { get; set; }
        public List<Firma> Firmalar { get; set; }
        public List<Menu> Menuler { get; set; }
        public List<Ekran> Ekranlar { get; set; }
        public bool IsReadOnly { get; set; } = false;
        public string LisansKodu { get; set; }
    }
}
