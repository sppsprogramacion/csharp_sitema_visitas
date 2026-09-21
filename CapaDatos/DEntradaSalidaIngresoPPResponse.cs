using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DEntradaSalidaIngresoPPResponse
    {
        public string numero_ficha { get; set; }
        public string ciudadano { get; set; }
        public string interno { get; set; }
        public string parentesco { get; set; }
        public string menores { get; set; }
        public string casillero { get; set; }
        public DateTime fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public string organismo { get; set; }
        
    }
}
