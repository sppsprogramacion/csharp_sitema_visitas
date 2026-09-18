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
        //CREAR ENTRADA SALIDA
        public async Task<(DEntradaSalida, string error)> CrearEntradaSalida(string entradaSalida)
        {
            IEntradaSalidaDao entradaSalidaDao = new EntradaSalidaDaoImplement();

            (DEntradaSalida entradaSalidaResponse, string errorResponse) = await entradaSalidaDao.CrearEntradaSalida(entradaSalida);

            return (entradaSalidaResponse, errorResponse);
        }
        //FIN CREAR ENTRADA SALIDA..................................................................

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
