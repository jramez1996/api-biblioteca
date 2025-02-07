
using AppPrestamo.Domain.DTOs.libro;
using AppPromocion.Domain.DTOs.PrestamoDto;

namespace AppPromocion.Application.Contracts.Persistencia.Prestamo
{
    public interface IPrestamoRepository
    {
        //    Task<List<PrestamoDTO>> GetObtenerPrestamo(int IdSegmentoPromocionDetalle);
        Task<bool> ValidarCopiaDisponible(int idCopiaLibro);

        public Task<List<CopiaLibroEstadoDto>> LibrosDisponibles();
        public Task<List<ClienteDto>> BuscarClientes(string doc);
    }
}
