using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.EdicionProhibicion
{
    public class ProhibicionEdicionValidator : AbstractValidator<ProhibicionDatos>
    {
        public ProhibicionEdicionValidator()
        {
            
            RuleFor(x => x.txtDisposicion)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La disposición es obligatoria.")
                    .Length(1, 100).WithMessage("La disposición debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtDetalle)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("El detalle es obligatorio.")
                    .Length(1, 2000).WithMessage("El detalle debe tener maximo 2000 caracteres.");
            RuleFor(x => x.dtpFechaInicio.ToString())
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La fecha de inicio es obligatoria");
            RuleFor(x => x.dtpFechaFin.ToString())
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La fecha de fin es obligatoria");
            RuleFor(x => x.txtMotivo)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("El motivo es obligatorio.")
                    .Length(1, 2000).WithMessage("El motivo debe tener maximo 2000 caracteres.");

        }

        private bool BeAnInteger(string numero)
        {
            int numerox;
            try
            {
                numerox = int.Parse(numero);
            }
            catch
            {
                return false;
            }

            return numerox % 1 == 0;
        }

    }
}
