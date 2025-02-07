using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPromocion.Infraestructure.ConeccionesBD.Dapper
{
    public class ConexionBD
    {
        public static class SQLBaseDeDatos
        {
            public const string ApiPromocionMarqueting = "marketing";
            public const string ApiPromocion = "BdPromocion";
            public const string ApiConfiguracion= "BdConfiguracion";
        }

        public static class SQLServidores
        {
            public const string ApiPromoProduccion = "BdPromocionProd";
            public const string ApiConfProduccion = "BdConfiguracionnProd";
            public const string ApiPromocionMarqueting = "marketingProd";
        }

        public static class SqlServidoresBaseDatosLista
        {
            public static readonly string[] ApiPromo =
            {
                SQLBaseDeDatos.ApiPromocion,
                SQLBaseDeDatos.ApiConfiguracion
            };
        }

        public static class DefaultConexion
        {
            public static string ReemplazarBaseDatos = "DefaultDataBase";
            public static string ReemplazarServidor = "DefaultServer";
            public static string ReemplazarUsuario = "DefaultUser";
            public static string ReemplazarContrasena = "DefaultPassword";

            public static string IpServidorEncrypt = "5AyCSFt52NLAiKh+36NwLQ==";
            public static string UsuarioEncrypt = "g4cmhf7yP48=";
            public static string ContrasenaEncrypt = "pr5W5PA7dFBmBP4IeKJ3tQ==";
            public static string BaseDatosEncrypt = "TtZmdF0ZwlpphFiER53z3SOGccltNzzJ";
        }

        //public SqlConnection ObtenerConexion()
        //{
        //    var conexion = new SqlConnection(_connectionString);
        //    conexion.Open();
        //    return conexion;
        //}
    }
}
