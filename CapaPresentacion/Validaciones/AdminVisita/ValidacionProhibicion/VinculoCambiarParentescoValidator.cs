using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion
{
    public class VinculoCambiarParentescoValidator : AbstractValidator<ProhibicionDatos>
    {
        public VinculoCambiarParentescoValidator()
        {

            RuleFor(x => x.cmbParentescos)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para parentesco.")
                .NotEmpty().WithMessage("Debe ingresar un valor para parentesco.")
                .Length(1, 20).WithMessage("El identificador de parentesco debe tener entre 1 y 20 caracteres.");
            RuleFor(x => x.txtMotivoModificarParentesco)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El motivo es obligatorio.")
                .Length(1, 1500).WithMessage("El motivo debe tener maximo 2000 caracteres.");

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
