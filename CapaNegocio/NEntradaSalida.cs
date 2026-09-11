using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NEntradaSalida
    {
        //BUSCAR CIUDADANO INGRESO
        public async Task<(DCiudadanoIngreso, string error)> BuscarCiudadanoIngresoXDni(int dniCiudadano)
        {
            IEntradaSalidaDao entradaSalidaDao = new EntradaSalidaDaoImplement();

            (DCiudadanoIngreso ciudadanoIngresoResponse, string errorResponse) = await entradaSalidaDao.BuscarCiudadanoIngresoXDni(dniCiudadano);


            return (ciudadanoIngresoResponse, errorResponse);
        }
        //FIN BUSCAR CIUDADANO INGRESO
        //------------------------------------------------------------------------------------------
    }
}
