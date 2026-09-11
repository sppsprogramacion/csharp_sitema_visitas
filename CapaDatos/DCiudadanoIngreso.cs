using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCiudadanoIngreso
    {
        public DCiudadanoVisita ciudadanoResponse { get; set; }
        public List<DInternoVisita> internosResponse { get; set; }
        public List<DMenorVisita> menoresResponse { get; set; } 
    }
}
