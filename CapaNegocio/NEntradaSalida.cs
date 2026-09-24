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
        public async Task<(DEntradaSalidaIngresoPPResponse, string error)> CrearEntradaSalida(string entradaSalida)
        {
            IEntradaSalidaDao entradaSalidaDao = new EntradaSalidaDaoImplement();

            (DEntradaSalidaIngresoPPResponse entradaSalidaResponse, string errorResponse) = await entradaSalidaDao.CrearEntradaSalida(entradaSalida);

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

        //BUSCAR CIUDADANO INGRESO CONTROL
        public async Task<(DCiudadanoIngresoControl, string error)> BuscarCiudadanoIngresoControlXFicha(int numeroFicha)
        {
            IEntradaSalidaDao entradaSalidaDao = new EntradaSalidaDaoImplement();

            (DCiudadanoIngresoControl ciudadanoIngresoResponse, string errorResponse) = await entradaSalidaDao.BuscarCiudadanoIngresoControlXFicha(numeroFicha);


            return (ciudadanoIngresoResponse, errorResponse);
        }
        //FIN BUSCAR CIUDADANO INGRESO CONTROL
        //------------------------------------------------------------------------------------------

        //EGRESO
        public async Task<(bool, string error)> EgresoPuertaPrincipal(int idEntradaSalida, string dataegreso)
        {
            IEntradaSalidaDao entradaSalidaDao = new EntradaSalidaDaoImplement();

            (bool egresoResponse, string error) = await entradaSalidaDao.EgresoPuertaPrincipal(idEntradaSalida, dataegreso);

            return (egresoResponse, error);
        }
        //FIN EGRESO 
        //---------------------------------------------------------------------------------
    }
}
