using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IEntradaSalidaDao
    {
        Task<(DEntradaSalidaIngresoPPResponse, string error)> CrearEntradaSalida(string entradaSalida);
        Task<(bool, string error)> AnularEntradaSalida(int id, string dataAnular);
        Task<(DEntradaSalida, string error)> BuscarEntradaSalidaXId(int idEntradaSalida);
        Task<(DCiudadanoIngresoControl, string error)> BuscarCiudadanoIngresoControlXFicha(int numeroFicha);
        Task<(DCiudadanoIngreso, string error)> BuscarCiudadanoIngresoXDni(int dniCiudadano);
        Task<(List<DEntradaSalida>, string error)> ListaEntradaSalidaXCiudadano(int idCiudadano);
        Task<(List<DEntradaSalidaConsulta>, string error)> ListaEntradaSalidaActuales();
        Task<(bool, string error)> EgresoPuertaPrincipal(int idEntradaSalida, string dataEgreso);
    }
}
