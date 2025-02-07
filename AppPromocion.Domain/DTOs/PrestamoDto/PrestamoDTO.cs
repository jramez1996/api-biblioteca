using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPromocion.Domain;
namespace AppPromocion.Domain.DTOs.PrestamoDto
{
    public class PrestamoDTO
    {
        public int IdCliente { get; set; }  // ID del cliente que realiza el préstamo
        public DateTime FechaDevolucionEstimada { get; set; }  // Fecha estimada para la devolución de los libros
        public string UsuarioRegistro { get; set; }  // Usuario que está registrando el préstamo
        public List<int> Libros { get; set; }  // Lista de libros que el cliente desea prestar

      
    }

   


}
