using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCiudadano
    {
                
        //RETORNAR CIUDADANOS TODOS
        public async Task<(List<DCiudadano>, string)> RetornarListaCiudadanos()
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (List<DCiudadano> listaCiudadanos, string error) = await ciudadanoDao.RetornarListaCiudadano();


            return (listaCiudadanos, error);
        }
        //FIN RETORNAR CIUDADANOS TODOS..................................

        //RETORNAR CIUDADANOS XDNI
        public async Task<(List<DCiudadano>, string errror)> RetornarListaCiudadanosXDni(string dni)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (List<DCiudadano> listaCiudadanos, string error) = await ciudadanoDao.RetornarListaCiudadanoXDni(dni);


            return (listaCiudadanos, error);
        }
        //FIN RETORNAR CIUDADANOS XDNI..................................

        //RETORNAR CIUDADANOS X APELLIDO
        public async Task<(List<DCiudadano>, string error)> RetornarListaCiudadanosXApellido(string apellido)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (List<DCiudadano> listaCiudadanos, string error) = await ciudadanoDao.RetornarListaCiudadanoXApellido(apellido);


            return (listaCiudadanos, error);
        }
        //FIN RETORNAR CIUDADANOS X APELLIDO..................................

        //RETORNAR CIUDADANO X ID
        public async Task<(DCiudadano, string error)> BuscarCiudadanoXID(int id)
        {
            ICiudadanoDao ciudadanoDao = new CiudadanoDaoImpl();

            (DCiudadano dCiudadano, string error) = await ciudadanoDao.BuscarCiudadanoXId(id);


            return (dCiudadano, error);
        }
        //FIN RETORNAR CIUDADANO XID..................................

        
    }
}
