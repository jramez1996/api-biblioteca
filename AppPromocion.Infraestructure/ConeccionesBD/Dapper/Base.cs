using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPromocion.Infraestructure.ConeccionesBD.Dapper
{
    public class Base
    {
        protected static IConfiguration _dapperConfiguration;

        public IConfiguration DapperConfiguration
        {
            get { return _dapperConfiguration; }
        }

        public Base(IConfiguration _configuration) => _dapperConfiguration = _configuration;
    }
}
