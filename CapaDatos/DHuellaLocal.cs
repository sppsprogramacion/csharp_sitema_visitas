using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DHuellaLocal
    {
        public int id_huella_ciudadano { get; set; }
        public int ciudadano_id { get; set; }
        public int dedo_id { get; set; }
        public byte[] huella { get; set; }
    }
}
