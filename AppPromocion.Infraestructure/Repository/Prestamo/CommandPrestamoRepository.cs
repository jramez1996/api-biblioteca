

using AppPromocion.Application.Contracts.Persistencia.Prestamo;
using AppPromocion.Domain;
using AppPromocion.Domain.DTOs.PrestamoDto;
using AppPromocion.Infraestructure.ConeccionesBD.Dapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace AppPromocion.Infraestructure.Repository.Prestamo
{
    public class CommandPrestamoRepository : Base, ICommandPrestamoRepository
    {
        //Task<int> CrearPrestamo( List<PrestamoDTO> request, string UsuarioRegistro)
        private readonly ILogger<CommandPrestamoRepository> _logger;
        public CommandPrestamoRepository(IConfiguration configuration, ILogger</*CommandCronogramaRepository*/ CommandPrestamoRepository> logger) : base(configuration) {
            _logger = logger;
        }
        public async Task<int> CrearPrestamo(PrestamoDTO request)
        {
            using (IDbConnection _context = Sql.ObtenerConexionConfig(ConexionBD.SQLBaseDeDatos.ApiConfiguracion))
            {
                _context.Open();  // Abrimos la conexión
                using IDbTransaction transaction = _context.BeginTransaction();  // Iniciamos la transacción
                try
                {
                    // Parámetros para el procedimiento almacenado
                    var parametrosPrestamo = new
                    {
                        fecha_prestamo = DateTime.Now,
                        fecha_devolucion_estimada = request.FechaDevolucionEstimada,
                        estado_prestamo = "En préstamo",
                        id_cliente = request.IdCliente,
                        estado = 1,
                        fecha_registro = DateTime.Now,
                        usuario_registro = request.UsuarioRegistro,
                        id_prestamo = 0 // Este parámetro será de salida
                    };

                    // Crear la lista de libros como un DataTable (esto simula el TVP)
                    var librosTable = new System.Data.DataTable();
                    librosTable.Columns.Add("id_copia_libro", typeof(int));

                    foreach (var libro in request.Libros)
                    {
                        librosTable.Rows.Add(libro);
                    }

                    // Agregar el parámetro TVP
                    var parametrosLibros = new DynamicParameters(parametrosPrestamo);
                    parametrosLibros.Add("@libros", librosTable.AsTableValuedParameter("dbo.TVP_Libros"));

                    // Usamos QueryAsync para recuperar el valor del parámetro de salida
                    var result = await _context.QueryAsync<int>(
                        "[prestamo].[insertar_prestamo_completo]",
                        parametrosLibros,
                        transaction: transaction,
                        commandType: CommandType.StoredProcedure
                    );

                    // El valor de @id_prestamo será el primer valor devuelto
                    int idPrestamo = result.FirstOrDefault();  // Suponemos que 'idPrestamo' es el único valor que se retorna

                    // Si todo fue exitoso, hacemos commit y retornamos el ID del préstamo
                    transaction.Commit();
                    return idPrestamo;  // Retornamos el ID del préstamo recién creado
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, revertimos los cambios
                    transaction.Rollback();
                    _logger.LogError($"Error al crear préstamo: {ex.Message}", ex);
                    throw new Exception("Error al crear el préstamo: " + ex.Message);  // Propagamos el error con un mensaje más claro
                }
                finally
                {
                    // Cerramos la conexión
                    _context.Close();
                    _context.Dispose();
                }
            }
        }


    }
}
