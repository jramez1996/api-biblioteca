//using AppPromocion.Application.Handlers.Avances.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPromocion.Application.Handlers.Prestamo.Commands.Create
{
    public  class CreateCanjeValidator : AbstractValidator<CreatePrestamoCommand>
    {
        public CreateCanjeValidator()
        {
            //RuleFor(v => v.IdSegmentoPromocionDetalle)
            //    .NotEmpty().WithMessage("{IdSegmentoPromocionDetalle} no puede ser campo vacio.")
            //    .NotNull().WithMessage("{IdSegmentoPromocionDetalle} no puede ser campo nulo.");

            RuleFor(v => v.UsuarioRegistro)
            .NotEmpty().WithMessage("{UsuarioRegistro} no puede ser campo vacio.")
            .NotNull().WithMessage("{UsuarioRegistro} no puede ser campo nulo.");

        }
    }
}
