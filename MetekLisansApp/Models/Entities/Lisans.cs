namespace MetekLisansApp.Models.Entities
{

    public class Lisans
    {
        public int Id { get; set; }

        public int FirmaId { get; set; }

        public DateTime LisansBitisTarih { get; set; }
        public DateTime LisansVerilmeTarih { get; set; }

        public string LisansKodu { get; set; }

        public int OlusturanUserId { get; set; }
        public string SeciliDegerler { get; set; }

    }


}
