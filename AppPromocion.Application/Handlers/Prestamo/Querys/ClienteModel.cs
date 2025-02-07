using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrestamo.Application.Handlers.Prestamo.Querys
{
    public class ClienteModel
    {
        public int IdCopiaLibro { get; set; }
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}
