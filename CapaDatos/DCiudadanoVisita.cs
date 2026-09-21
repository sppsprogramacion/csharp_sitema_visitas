using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCiudadanoVisita
    {
        public int id_ciudadano { get; set; }
        public int dni { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
        public string nacionalidad { get; set; }
        public string pais { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string municipio { get; set; }
        public string ciudad { get; set; }
        public string barrio { get; set; }
        public string direccion { get; set; }
        public int numero_dom { get; set; }
        public bool esta_prohibido { get; set; }
        public bool tiene_discapacidad { get; set; }
        public string discapacidad_detalle { get; set; }
        public string foto { get; set; }
        public DateTime fecha_alta { get; set; }

    }
}
