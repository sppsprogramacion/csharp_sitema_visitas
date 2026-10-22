using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DEntradaSalidaSabanaCiudadano
    {
        public int id_entrada_salida { get; set; }
        public string numero_ficha { get; set; }
        public string nombre_interno { get; set; }
        public string parentesco { get; set; }
        public string menores { get; set; }
        public DateTime fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public string hora_egreso { get; set; }
        public string organismo { get; set; }
    }
}
