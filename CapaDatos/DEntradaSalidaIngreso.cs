using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DEntradaSalidaIngreso
    {
        public int id_entrada_salida { get; set; }
        public string numero_ficha { get; set; }
        public string nombre_visita { get; set; }
        public int dni_visita { get; set; }
        public string sexo_visita { get; set; }
        public DateTime fecha_nacimiento_visita { get; set; }
        public int edad_visita { get; set; }
        public string foto_visita { get; set; }
        public bool tiene_discapacidad { get; set; }
        public string discapacidad_detalle { get; set; }
        public DateTime fecha_alta_visita { get; set; }
        public string nombre_interno { get; set; }
        public string parentesco { get; set; }
        public string casillero { get; set; }
        public DateTime fecha_registro { get; set; }
        public string hora_registro { get; set; }
        public string organismo { get; set; }
        public List<DMenorVisitaIngresado> menoresIngresadosResponse { get; set; }
    }
}
