using static Modelli.Class1;

namespace TrentoMeteoApp.ViewModels
{
    public class MeteoIndexViewModel
    {
        //array dei giorni metereologici
        public RootObject giorni { get; set; }

        public MeteoIndexViewModel(RootObject giorni)
        {
            this.giorni = giorni;
        }
    }
}
