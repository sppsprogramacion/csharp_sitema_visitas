using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion
{
    public class ExcepcionIngresoNuevaValidator : AbstractValidator<ProhibicionDatos>
    {
        public ExcepcionIngresoNuevaValidator()
        {
            
            RuleFor(x => x.txtMotivoExcepcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El motivo es obligatoria.")
                .Length(1, 200).WithMessage("El motivo debe tener maximo 200 caracteres.");
            RuleFor(x => x.txtDetalleExcepcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El detalle es obligatorio.")
                .Length(1, 1000).WithMessage("El detalle debe tener maximo 1000 caracteres.");
            RuleFor(x => x.dtpFechaExcepcion.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de excepcion es obligatoria");
            RuleFor(x => x.txtIdInternoExcepcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para el identificador del interno (id interno).")
                .Must(BeAnInteger).WithMessage("El el identificador del interno (id interno) debe ser un numero entero.");

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
