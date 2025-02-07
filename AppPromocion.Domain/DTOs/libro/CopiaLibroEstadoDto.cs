using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrestamo.Domain.DTOs.libro
{
    public class CopiaLibroEstadoDto
    {
        public int idCopia { get; set; }
        public string titulo { get; set; }
        public string qr { get; set; }
    }
}
