using AppPrestamo.Application.Handlers.Libro.Querys;
using AppPromocion.Application.Contracts.Persistencia.Prestamo;
using AppPromocion.Application.Handlers.Prestamo.Commands.Create;
using AppPromocion.Application.Wrappers;
using AppPromocion.Domain.DTOs.PrestamoDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrestamo.Application.Handlers.Prestamo.Querys
{
    public class LibroHandler : IRequestHandler<LibroQuery, Response<ResultResponse>>
    {



        private readonly IPrestamoRepository _iPrestamoRepository;
        // Obtener la información de la zona horaria

        public LibroHandler(IPrestamoRepository iPrestamoRepository)
        {
            _iPrestamoRepository = iPrestamoRepository;

        }
        public async Task<Response<ResultResponse>> Handle(LibroQuery request, CancellationToken cancellationToken)
        {
            var rp =await  _iPrestamoRepository.LibrosDisponibles();
             return new Response<ResultResponse>(new ResultResponse { IdNew = 0, DataObject = rp}, "");




        }

    }

}
