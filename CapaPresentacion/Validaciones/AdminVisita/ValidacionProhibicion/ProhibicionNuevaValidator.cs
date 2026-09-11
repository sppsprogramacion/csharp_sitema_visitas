using CapaDatos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones
{
    public class ProhibicionNuevaValidator : AbstractValidator<ProhibicionDatos>
    {
        public ProhibicionNuevaValidator()
        {
            RuleFor(x => x.txtIdCiudadano.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para id_ciudadano.")
                .Must(BeAnInteger).WithMessage("El id_ciudadano debe ser un numero entero.");
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
                //.Must(BeAValidDate).WithMessage("La fecha de inicio no es valida.");
            RuleFor(x => x.dtpFechaFin.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de fin es obligatoria");
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

        private bool BeAValidDate(string fecha)
        {
            return DateTime.TryParseExact(fecha, "dd/MM/aaaa", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
