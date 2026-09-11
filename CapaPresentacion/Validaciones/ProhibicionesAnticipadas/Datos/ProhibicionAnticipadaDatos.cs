using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.ProhibicionesAnticipadas.Datos
{
    public class ProhibicionAnticipadaDatos
    {
        
        public string txtApellidoVisita { get; set; }
        public string txtNombreVisita { get; set; }
        public string txtDniVisita { get; set; }
        public string cmbSexoVisita { get; set; }
        public DateTime dtpFechaInicio { get; set; }
        public DateTime dtpFechaFin { get; set; }
        public string txtDetalleVisitaAnticipada { get; set; }
        public string txtApellidoInterno { get; set; }
        public string txtNombreInterno { get; set; }
    }
}
