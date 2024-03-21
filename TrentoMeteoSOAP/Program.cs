using SoapCore;
using static TrentoMeteoSOAP.Service.Service;


namespace TrentoMeteoSOAP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Aggiunta del supporto per SOAP all'app
            builder.Services.AddSoapCore();
            //Registrazione del servizio in app
            builder.Services.AddScoped<ISoapService, SoapService>();
            
            var app = builder.Build();
            app.UseRouting();
            //Configurazione degli endpoint SOAP in app
            app.UseEndpoints(endpoints =>
            {
                //Aggiunta endpoint SOAP con specifica del percorso file wsdl
                endpoints.UseSoapEndpoint<ISoapService>("/Service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });
            //Avvio applicazione su un determinato indirizzo e porta
            app.Run();
        }
    }
}
