
using AppPromocion.Application.Handlers.Prestamo.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;



using System.Collections.Concurrent;
using AppPromocion.Application.Handlers.Prestamo.Commands.Create;
using AppPrestamo.Application.Handlers.Prestamo.Querys;
using AppPrestamo.Application.Handlers.Libro.Querys;


namespace AppPromocion.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PrestamoController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost("creacionPrestamo")]
        public async Task<ActionResult<int>> creacionCronograma([FromBody] CreatePrestamoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);

        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("buscarCliente/{documento}")]
        public async Task<ActionResult<ClienteModel>> ObtenerCliente(string documento)
        {
            var result = await _mediator.Send(new ClienteQuery(documento));

            if (result == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra el préstamo
            }

            return Ok(result); // Retorna 200 OK con el objeto del préstamo
        }
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("ObtenerLibro")]
        public async Task<ActionResult<ClienteModel>> ObtenerLibro()
        {
            var result = await _mediator.Send(new LibroQuery());

            if (result == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra el préstamo
            }

            return Ok(result); // Retorna 200 OK con el objeto del préstamo
        }




    }
}
