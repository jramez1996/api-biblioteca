using MediatR;
using AppPromocion.Application.Wrappers;

namespace AppPrestamo.Application.Handlers.Prestamo.Querys
{
    // Asegúrate de que ClienteQuery herede de IRequest<Response<ResultResponse>>
    public class ClienteQuery : IRequest<Response<ResultResponse>>
    {
        // Aquí puedes agregar los parámetros que necesitas para la consulta, por ejemplo, un ClienteId
        public string documento { get; set; }

        public ClienteQuery(string documento1)
        {
            documento = documento1;
        }
    }


}
