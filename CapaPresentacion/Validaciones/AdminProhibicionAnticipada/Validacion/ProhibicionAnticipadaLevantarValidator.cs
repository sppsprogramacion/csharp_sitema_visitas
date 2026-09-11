using CapaPresentacion.Validaciones.AdminProhibicionAnticipada.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.AdminProhibicionAnticipada.Validacion
{
    public class ProhibicionAnticipadaLevantarValidator : AbstractValidator<AdminProhibicionAnticipadaDatos>
    {
        public ProhibicionAnticipadaLevantarValidator()
        {

            RuleFor(x => x.dtpFechaFinLevantar.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de fin es obligatoria");
            RuleFor(x => x.txtMotivoLevantar)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El motivo es obligatorio.")
                .Length(1, 2000).WithMessage("El motivo debe tener maximo 2000 caracteres.");

        }

    }
}
