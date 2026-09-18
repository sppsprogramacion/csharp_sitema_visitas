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
        Task<(DEntradaSalida, string error)> CrearEntradaSalida(string entradaSalida);
        Task<(bool, string error)> AnularEntradaSalida(int id, string dataAnular);

        Task<(DEntradaSalida, string error)> BuscarEntradaSalidaXId(int idEntradaSalida);
        Task<(DCiudadanoIngreso, string error)> BuscarCiudadanoIngresoXDni(int dniCiudadano);
        Task<(List<DEntradaSalida>, string error)> ListaEntradaSalidaXCiudadano(int idCiudadano);
    }
}
