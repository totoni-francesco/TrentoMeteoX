namespace TrentoMeteoApp.Models
{
    public class ErrorViewModel
    {
        //Identificatore per la richiesta che ha generato l'errore
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
