using AppPromocion.Domain;
using AppPromocion.Infraestructure.ConeccionesBD.Dapper;
using Microsoft.Extensions.Configuration;


namespace AppPromocion.Infraestructure.Global
{
    public class ColaSettings
    {
        public string HostName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string QueueCanje { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}
