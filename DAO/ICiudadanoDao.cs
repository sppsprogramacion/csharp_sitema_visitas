using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace DAO
{
    public interface ICiudadanoDao
    {
        
        Task<(DCiudadano, string error)> BuscarCiudadanoXId(int id);

        Task<(List<DCiudadano>, string error)> RetornarListaCiudadano();

        Task<(List<DCiudadano>, string error)> RetornarListaCiudadanoXDni(string dni);

        Task<(List<DCiudadano>, string error)> RetornarListaCiudadanoXApellido(string apellido);

        
    }
}
