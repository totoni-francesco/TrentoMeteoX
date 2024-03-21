using System.ServiceModel;
using Newtonsoft.Json;
using static Modelli.Class1;

namespace TrentoMeteoSOAP.Service
{
    public class Service
    {
        [ServiceContract]
        public interface ISoapService
        {
            //Operazione per l'ottenimento delle informazioni meteo
            [OperationContract]
            Giorni[] GetWeather(string? day = null);
        }

        public class SoapService : ISoapService
        {
            public Giorni[] GetWeather(string? day = null)
            {
                //URI API meteo
                string Uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";
                //Client HTTP
                using (HttpClient client = new HttpClient())
                {
                    //Richiesta GET all'API meteo
                    using (HttpResponseMessage risposta = client.GetAsync(Uri).Result)
                    {
                        //Ottenimento dei dati di risposta
                        using (HttpContent content = risposta.Content)
                        {
                            //Lettura dei dati di risposta come una stringa
                            String risultato = content.ReadAsStringAsync().Result;
                            RootObject data = JsonConvert.DeserializeObject<RootObject>(risultato);
                            //Estrazione dei dati giornalieri
                            Giorni[] dayData = data.previsione[0].giorni;
                            //ritorno dei dati in base al giorno specificato
                            return day != null ? dayData.Where(d => d.giorno == day).ToArray() : dayData;
                        }
                    }
                }
            }
        }
    }
}
