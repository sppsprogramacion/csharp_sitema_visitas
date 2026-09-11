using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DEntradaSalida
    {
        public int id_entrada_salida { get; set; }
        public string numero_ficha { get; set; }
        public int numero_aux { get; set; }
        public int interno_id { get; set; }
        public DInterno interno { get; set; }
        public string nombre_interno { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public string nombre_visita { get; set; }
        public int edad { get; set; }
        public int sexo_id { get; set; }
        public DSexo sexo { get; set; }
        public string parentesco_id { get; set; }
        public DParentesco parentesco { get; set; }
        public string categoria { get; set; }
        public int ciudadano_tutor_id { get; set; }
        public DCiudadano ciudadano_tutor { get; set; }
        public DateTime fecha_ingreso_principal { get; set; }
        public string hora_ingreso_principal { get; set; }
        public string hora_egreso_principal { get; set; }
        public DateTime fecha_ingreso_control_interno { get; set; }
        public string hora_ingreso_control_interno { get; set; }
        public string hora_egreso_control_interno { get; set; }
        public DateTime fecha_ingreso_mesa_control { get; set; }
        public string hora_ingreso_mesa_control { get; set; }
        public string hora_egreso_mesa_control { get; set; }
        public DateTime fecha_ingreso_acceso_4 { get; set; }
        public string hora_ingreso_acceso_4 { get; set; }
        public string hora_egreso_acceso_4 { get; set; }
        public string menores { get; set; }
        public string pabellon { get; set; }
        public string casillero { get; set; }
        public string observaciones_usuarios { get; set; }
        public bool cancelado { get; set; }
        public string detalle_cancelado { get; set; }

        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
