using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DBitacoraProhibicionAnticipada
    {
        public int id_bitacora_prohibicion_anticipada { get; set; }
        public int prohibicion_anticipada_id { get; set; }
        public DProhibicionAnticipada prohibicion { get; set; }
        public string motivo { get; set; }
        public string detalle_motivo { get; set; }
        public string datos_modificados { get; set; }
        public DateTime fecha_cambio { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
        
    }
}
