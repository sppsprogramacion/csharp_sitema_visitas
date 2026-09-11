using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DBitacoraProhibicionVisita
    {
        public int id_bitacora_prohibicion_visita { get; set; }
        public int prohibicion_visita_id { get; set; }
        public DProhibicionVisita prohibicion { get; set; }
        public string disposicion { get; set; }
        public string detalle { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool vigente { get; set; }
        public bool anulado { get; set; }
        public string motivo { get; set; }
        public string detalle_motivo { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
        public DateTime fecha_cambio { get; set; }
    }
}
