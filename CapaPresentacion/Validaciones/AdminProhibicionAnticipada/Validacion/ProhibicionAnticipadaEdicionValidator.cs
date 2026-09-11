using CapaPresentacion.Validaciones.AdminProhibicionAnticipada.Datos;
using CapaPresentacion.Validaciones.ProhibicionesAnticipadas.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminProhibicionAnticipada.Validacion
{
    public class ProhibicionAnticipadaEdicionValidator : AbstractValidator<AdminProhibicionAnticipadaDatos>
    {
        public ProhibicionAnticipadaEdicionValidator()
        {

            RuleFor(x => x.txtApellidoVisita)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Length(1, 100).WithMessage("El apellido debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtNombreVisita)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(1, 100).WithMessage("El nombre debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtDniVisita)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para dni de visita.")
                .Must(BeAnInteger).WithMessage("El dni de visita debe ser un numero entero.");
            RuleFor(x => x.cmbSexoVisita)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para sexo null.")
                .NotEmpty().WithMessage("Debe ingresar un valor para sexo.")
                .Must(BeAnInteger).WithMessage("El sexo debe ser valido.");
            RuleFor(x => x.dtpFechaInicio.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria");
            //.Must(BeAValidDate).WithMessage("La fecha de inicio no es valida.");
            RuleFor(x => x.dtpFechaFin.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de fin es obligatoria");
            RuleFor(x => x.txtDetalleProhibicionAnticipada)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El detalle es obligatorio.")
                .Length(1, 2000).WithMessage("El detalle debe tener maximo 2000 caracteres.");
            RuleFor(x => x.txtApellidoInterno)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Length(1, 100).WithMessage("El apellido debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtNombreInterno)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(1, 100).WithMessage("El nombre debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtMotivoDetalle)
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
