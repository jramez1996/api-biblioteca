using AppPromocion.Domain.DTOs.PrestamoDto;
using AppPromocion.Application.Contracts.Persistencia.Prestamo;
using AppPromocion.Application.Globals;
using AppPromocion.Infraestructure.ConeccionesBD.Dapper;
using Dapper;

using Microsoft.Extensions.Configuration;

using System.Data;
using System.Numerics;
using AppPrestamo.Domain.DTOs.libro;

namespace AppPromocion.Infraestructure.Repository.Cronograma
{
    public class PrestamoRepository : Base, IPrestamoRepository
    {
        public PrestamoRepository(IConfiguration _configuration) : base(_configuration) { }

       

        public async Task<bool> ValidarCopiaDisponible(int idCopiaLibro)
        {
            // Obtenemos la conexión a la base de datos
            using (IDbConnection _context = Sql.ObtenerConexionConfig(ConexionBD.SQLBaseDeDatos.ApiConfiguracion))
            {
                _context.Open();  // Abrimos la conexión

                try
                {
                    // Definimos la consulta SQL para verificar si la copia está disponible
                    string sql = @"
                    SELECT COUNT(1)
                    FROM catalogo.copia_libro co
                    WHERE co.id_copia_libro = @id_copia_libro
                    AND co.estado_copia = 'Disponible';
                    ";

                    // Ejecutamos la consulta y obtenemos el resultado
                    var resultado = await _context.ExecuteScalarAsync<int>(sql, new { id_copia_libro = idCopiaLibro });

                    // Si el resultado es mayor que 0, significa que la copia está disponible
                    return resultado > 0;
                }
                catch (Exception ex)
                {
                     throw;  // Propagamos el error
                }
                finally
                {
                    // Cerramos la conexión
                    _context.Close();
                    _context.Dispose();
                }
            }
        }

        public async Task<List<CopiaLibroEstadoDto>> LibrosDisponibles()
        {
            // Obtenemos la conexión a la base de datos
            using (IDbConnection _context = Sql.ObtenerConexionConfig(ConexionBD.SQLBaseDeDatos.ApiConfiguracion))
            {
                _context.Open();  // Abrimos la conexión

                try
                {
                    // Definimos la consulta SQL para obtener las copias disponibles
                    string sql = @"
                SELECT co.id_copia_libro AS idCopia, 
                       lib.titulo, 
                       co.qr 
                FROM catalogo.copia_libro co  
                INNER JOIN catalogo.libro lib ON lib.id_libro = co.id_libro 
                WHERE co.estado_copia = 'Disponible';
            ";

                    // Ejecutamos la consulta y obtenemos el resultado
                    var resultados = await _context.QueryAsync<dynamic>(sql);

                    // Si no se encuentran resultados, devolvemos una lista vacía
                    if (resultados == null || !resultados.Any())
                    {
                        return new List<CopiaLibroEstadoDto>();
                    }

                    // Creamos la lista de objetos CopiaLibroEstadoDto y asignamos los valores
                    var listaCopias = resultados.Select(r => new CopiaLibroEstadoDto
                    {
                        idCopia = r.idCopia,  // Asignar id_copia_libro
                        titulo = r.titulo,         // Asignar titulo del libro
                        qr = r.qr     // Sabemos que las copias recuperadas están disponibles
                    }).ToList();

                    // Retornamos la lista de copias
                    return listaCopias;
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, lo propagamos
                    throw new Exception("Error al obtener los libros disponibles.", ex);
                }
                finally
                {
                    // Cerramos la conexión
                    _context.Close();
                    _context.Dispose();
                }
            }
        }

        public async Task<List<ClienteDto>> BuscarClientes(string doc)
        {
            using (IDbConnection _context = Sql.ObtenerConexionConfig(ConexionBD.SQLBaseDeDatos.ApiConfiguracion))
            {
                _context.Open();  // Abrimos la conexión

                try
                {
                    // Definimos la consulta SQL para obtener las copias disponibles
                    string sql = @"SELECT cli.id_cliente Id,cli.nombres Nombres,cli.apellidos Apellidos,cli.numero_documento_identidad Documento FROM [db_sis_biblioteca].[cliente].[cliente] cli where cli.estado=1 and cli.numero_documento_identidad='"+ doc+"';";

                    // Ejecutamos la consulta y obtenemos el resultado
                    var resultados = await _context.QueryAsync<dynamic>(sql);

                    // Si no se encuentran resultados, devolvemos una lista vacía
                    if (resultados == null || !resultados.Any())
                    {
                        return new List<ClienteDto>();
                    }

                    // Creamos la lista de objetos CopiaLibroEstadoDto y asignamos los valores
                    var listaCopias = resultados.Select(r => new ClienteDto
                    {
                        Id = r.Id,  // Asignar id_copia_libro
                        Nombres = r.Nombres,         // Asignar titulo del libro
                        Apellidos = r.Apellidos,         // Asignar titulo del libro
                        Documento = r.Documento     // Sabemos que las copias recuperadas están disponibles
                    }).ToList();

                    // Retornamos la lista de copias
                    return listaCopias;
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, lo propagamos
                    throw new Exception("Error al obtener los libros disponibles.", ex);
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
