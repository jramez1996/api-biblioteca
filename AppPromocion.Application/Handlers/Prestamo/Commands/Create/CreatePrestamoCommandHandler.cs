



using AppPromocion.Application.Contracts.Persistencia.Prestamo;
using AppPromocion.Application.Wrappers;
using AppPromocion.Domain.DTOs.PrestamoDto;
using MediatR;

namespace AppPromocion.Application.Handlers.Prestamo.Commands.Create
{
    public class CreatePrestamoCommandHandler : IRequestHandler<CreatePrestamoCommand, Response<ResultResponse>>
    {
        private readonly ICommandPrestamoRepository _iComandPrestamoRepository;
        private readonly IPrestamoRepository _iprestamoRepository;


        // Obtener la información de la zona horaria

        public CreatePrestamoCommandHandler(ICommandPrestamoRepository iComandPrestamoRepository, IPrestamoRepository icanjeRepository)
        {
            _iComandPrestamoRepository = iComandPrestamoRepository;
            _iprestamoRepository = icanjeRepository;

        }
        public async Task<Response<ResultResponse>> Handle(CreatePrestamoCommand request, CancellationToken cancellationToken)
        {
            List<int> responseLibroPrestado = new List<int>();
            // Validación de datos del préstamo
            if (request.Libros == null || request.Libros.Count == 0)
            {
                return new Response<ResultResponse>(null, "No se especificaron libros para el préstamo.");
            }
            if (request.Libros.Count >3)
            {
                return new Response<ResultResponse>(null, "Ahy mas de 3 libros.");
            }
            foreach (var item in request.Libros)
            {
                var existeCopiaDis=await _iprestamoRepository.ValidarCopiaDisponible(item);
                if (existeCopiaDis)
                {
                    responseLibroPrestado.Add(item);

                }
            }
            if (responseLibroPrestado.Count!= request.Libros.Count)
            {
                return new Response<ResultResponse>(null, "Ahy Algun libro prestado de lo enviado.");
            }

            var prestamo = new PrestamoDTO
            {
                IdCliente = request.IdCliente,
               
                Libros= responseLibroPrestado,
                FechaDevolucionEstimada = request.FechaDevolucionEstimada,
                UsuarioRegistro = request.UsuarioRegistro
            };
            var prestamoId = await _iComandPrestamoRepository.CrearPrestamo(prestamo);
            return new Response<ResultResponse>(new ResultResponse { IdNew = prestamoId, DataObject = null }, "Préstamo creado con éxito.");




        }

    }
}
