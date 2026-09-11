using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion
{
    public class VinculoProhibirValidator : AbstractValidator<ProhibicionDatos>
    {
        public VinculoProhibirValidator()
        {

            RuleFor(x => x.dtpFechaIniProhibirParentesco.ToString())
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La fecha de inicio es obligatoria");
            RuleFor(x => x.dtpFechaFinProhibirParentesco.ToString())
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La fecha de fin es obligatoria");
            RuleFor(x => x.txtDetalleProhibirParentesco)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("El detalle es obligatorio.")
                    .Length(1, 1500).WithMessage("El detalle debe tener maximo 2000 caracteres.");

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

