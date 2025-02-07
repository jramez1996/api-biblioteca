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
    public class ClienteHandler : IRequestHandler<ClienteQuery, Response<ResultResponse>>
    {



        private readonly IPrestamoRepository _iPrestamoRepository;
        // Obtener la información de la zona horaria

        public ClienteHandler(IPrestamoRepository iPrestamoRepository)
        {
            _iPrestamoRepository = iPrestamoRepository;

        }
        public async Task<Response<ResultResponse>> Handle(ClienteQuery request, CancellationToken cancellationToken)
        {
            var rp =await  _iPrestamoRepository.BuscarClientes(request.documento);
             return new Response<ResultResponse>(new ResultResponse { IdNew = 0, DataObject = rp}, "");




        }

    }

}
