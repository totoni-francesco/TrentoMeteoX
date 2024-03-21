using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ServiceModel;
using TrentoMeteoApp.ViewModels;
using static Modelli.Class1;

namespace TrentoMeteoApp.Controllers;

public class MeteoController : Controller
{

    private RootObject CaricaDati()
    {
        string uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = client.GetAsync(uri).Result)
            {
                using (HttpContent content = response.Content)
                {
                    string risultato = content.ReadAsStringAsync().Result;
                    RootObject data = JsonConvert.DeserializeObject<RootObject>(risultato);
                    return data;
                }
            }
        }
    }

    public IActionResult Index()
    {
        RootObject data = this.CaricaDati();
        MeteoIndexViewModel vm = new MeteoIndexViewModel(data);
        return View(vm);
    }
}
