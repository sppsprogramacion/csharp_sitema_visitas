using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion
{
    public class ProhibicionLevantarAnularValidator : AbstractValidator<ProhibicionDatos>
    {
        public ProhibicionLevantarAnularValidator()
        {
            
            
            RuleFor(x => x.dtpFechaFinQP.ToString())
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("La fecha de fin es obligatoria");
            RuleFor(x => x.txtMotivoQP)
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
