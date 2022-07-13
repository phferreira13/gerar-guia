namespace GerarGuia.Domain.Shared.Configuration
{
    public class ClientApiConfiguration
    {
        public string BaseUrl { get; set; }
        public AuthConfiguration Auth { get; set; }
        public BasicApiConfiguration DarfApi { get; set; }
        public BasicApiConfiguration GnreApi { get; set; }
    }
}
