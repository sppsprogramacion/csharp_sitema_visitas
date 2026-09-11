using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion
{
    public class VinculoDesvincularRevincularValidator : AbstractValidator<ProhibicionDatos>
    {
        public VinculoDesvincularRevincularValidator()
        {

            RuleFor(x => x.txtDetalleVinculacionParentesco)
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
