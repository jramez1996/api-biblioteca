using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPromocion.Infraestructure.ConeccionesBD.Dapper
{
    public class Sql : Base
    {
        public Sql(IConfiguration _configuration) : base(_configuration) => _dapperConfiguration = _configuration;
   
        static internal IDbConnection ObtenerConexion(string dataBaseName)
        {
            return new SqlConnection(ConfigurationCadenaConexion(dataBaseName));
        }
        static internal IDbConnection ObtenerConexionConfig(string dataBaseName)
        {
            return new SqlConnection(ConfigurationCadenaConfigConexion(dataBaseName));
        }

        private static string ConfigurationCadenaConfigConexion(string dataBaseName)
        {
            var dapperConnectionString = _dapperConfiguration["ConnectionStrings:ConnectionPromocionConf"];
           
            dapperConnectionString = dapperConnectionString.Replace(ConexionBD.DefaultConexion.ReemplazarBaseDatos, dataBaseName);

            if (ConexionBD.SqlServidoresBaseDatosLista.ApiPromo.Contains(dataBaseName))
                dapperConnectionString = dapperConnectionString.Replace(ConexionBD.DefaultConexion.ReemplazarServidor, ConexionBD.SQLServidores.ApiConfProduccion);

            if (string.IsNullOrEmpty(dapperConnectionString))
                throw new ArgumentException("El parametro connectionString no tiene información.");

            if (string.IsNullOrEmpty(dapperConnectionString))
                throw new ArgumentException("No se ha especificado el nombre del servidor.");

            return dapperConnectionString;
        }
        private static string ConfigurationCadenaConexion(string dataBaseName)
        {
            var dapperConnectionString = _dapperConfiguration["ConnectionStrings:ConnectionPromocion"];
            dapperConnectionString = dapperConnectionString.Replace(ConexionBD.DefaultConexion.ReemplazarBaseDatos, dataBaseName);
            
            if (ConexionBD.SqlServidoresBaseDatosLista.ApiPromo.Contains(dataBaseName))
                dapperConnectionString = dapperConnectionString.Replace(ConexionBD.DefaultConexion.ReemplazarServidor, ConexionBD.SQLServidores.ApiPromoProduccion);

            if (string.IsNullOrEmpty(dapperConnectionString))
                throw new ArgumentException("El parametro connectionString no tiene información.");

            if(string.IsNullOrEmpty(dapperConnectionString))
                throw new ArgumentException("No se ha especificado el nombre del servidor.");

            return dapperConnectionString;
        }
    }
}
