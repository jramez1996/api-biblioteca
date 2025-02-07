using AppPromocion.Domain.DTOs.PrestamoDto;
namespace AppPromocion.Application.Contracts.Persistencia.Prestamo
{
    public interface ICommandPrestamoRepository
    {
        Task<int> CrearPrestamo(PrestamoDTO request);
        //public async Task<int> CrearPrestamo(PrestamoDTO request);

    }
}
