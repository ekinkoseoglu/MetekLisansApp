using MetekLisansApp.Models.Entities;

namespace MetekLisansApp.Models.ViewModels
{
    public class ProjeDurumuListeViewModel
    {
        public List<ProjeDurumu> ProjeDurumlari{ get; set; }

        public string FirmaAdFilter { get; set; }


        public int TotalCount { get; set; }

    }
}
