using MediatR;
using AppPromocion.Application.Wrappers;

namespace AppPrestamo.Application.Handlers.Libro.Querys
{
    // Asegúrate de que ClienteQuery herede de IRequest<Response<ResultResponse>>
    public class LibroQuery : IRequest<Response<ResultResponse>>
    {
        // Aquí puedes agregar los parámetros que necesitas para la consulta, por ejemplo, un ClienteId
        public LibroQuery()
        {
        }
    }


}
