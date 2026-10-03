using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.ClasesEspeciales
{
    public class DEntradaSalidaGrilla
    {
        public int Id { get; set; }
        public string NumFicha { get; set; }
        public string Visita { get; set; }
        public int DniVisita { get; set; }
        public string Interno { get; set; }
        public string Parentesco { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraEgreso { get; set; }
        public string Organismo { get; set; }
    }
}
