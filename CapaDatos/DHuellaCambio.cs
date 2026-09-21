using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DHuellaCambio
    {
        public string version { get; set; }
        public string accion { get; set; }
        public int huella_id { get; set; }
        public int? ciudadano_id { get; set; }
        public int? dedo_id { get; set; }
        public string huella { get; set; }
    }
}
