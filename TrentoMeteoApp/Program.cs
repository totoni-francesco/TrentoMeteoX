namespace TrentoMeteoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Crea oggetto per la configurazione app web
            var builder = WebApplication.CreateBuilder(args);

            //Aggiunge il servizio per supporto del controller
            builder.Services.AddControllersWithViews();
            
            //Cosstruzione appweb
            var appweb = builder.Build();

            //Configuarazione app web
            if (!appweb.Environment.IsDevelopment())
            {
                appweb.UseExceptionHandler("/Meteo/Error");
                appweb.UseHsts();
            }

            appweb.UseHttpsRedirection();

            appweb.UseStaticFiles();

            appweb.UseRouting();

            appweb.UseAuthorization();

            //Mapping della rotta che userà il controller
            appweb.MapControllerRoute(
                name: "default",
                pattern: "{controller=Meteo}/{action=Index}/{id?}");
            //Esecuzione dell'app
            appweb.Run();
        }
    }
}