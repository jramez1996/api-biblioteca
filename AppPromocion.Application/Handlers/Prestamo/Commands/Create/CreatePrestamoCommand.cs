using AppPromocion.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppPromocion.Domain;
namespace AppPromocion.Application.Handlers.Prestamo.Commands.Create
{
    public class CreatePrestamoCommand : IRequest<Response<ResultResponse>>
    {
        public int IdCliente { get; set; }  // El ID del cliente que está realizando el préstamo
        public List<int> Libros { get; set; }  // Lista de libros que se están prestando
        public DateTime FechaDevolucionEstimada { get; set; }  // Fecha estimada de devolución del préstamo
        public string UsuarioRegistro { get; set; }  // El usuario que está registrando el préstamo

        public CreatePrestamoCommand(int idCliente, List<int> libros, DateTime fechaDevolucionEstimada, string usuarioRegistro)
        {
            IdCliente = idCliente;
            Libros = libros ?? new List<int>();
            FechaDevolucionEstimada = fechaDevolucionEstimada;
            UsuarioRegistro = usuarioRegistro;
        }
    }

    // DTO para representar los libros que se van a prestar
    public class LibroPrestadoDTO
    {
        public int IdLibro { get; set; }  // El ID del libro
    }

}
