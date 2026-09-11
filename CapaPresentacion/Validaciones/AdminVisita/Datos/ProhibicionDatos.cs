using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones
{
    public class ProhibicionDatos
    {
        //public int id_prohibicion_visita { get; set; }
        public string txtIdCiudadano { get; set; }
        //public int organismo_id { get; set; }
        //public DateTime fecha_prohibicion { get; set; }
        public string txtDisposicion { get; set; }
        public string txtDetalle { get; set; }
        public DateTime dtpFechaInicio { get; set; }
        public DateTime dtpFechaFin { get; set; }        

        //para edicion
        public string txtMotivo { get; set; }

        //para levantar prohibicion y prohibir
        public string txtMotivoQP { get; set; }
        public DateTime dtpFechaFinQP { get; set; }

        //VINCULOS
        //para prohibir/levantar parentesco
        public DateTime dtpFechaIniProhibirParentesco { get; set; }
        public DateTime dtpFechaFinProhibirParentesco { get; set; }
        public string txtDetalleProhibirParentesco { get; set; }

        //para revincular/desvincular
        public string txtDetalleVinculacionParentesco { get; set; }

        //para cambiar parentesco
        public string cmbParentescos { get; set; }
        public string txtMotivoModificarParentesco { get; set; }

        //para novedades
        public string txtNuevaNovedad { get; set; }

        //EXCEPCION DE INGRESO
        //para NUEVA excepcion de ingreso
        public DateTime dtpFechaExcepcion { get; set; }
        public string txtMotivoExcepcion { get; set; }
        public string txtDetalleExcepcion { get; set; }
        public string txtIdInternoExcepcion { get; set; }
        //cumplimentar y anular
        public string txtDetalleCumplAnularExcepcion { get; set; }

    }
}
