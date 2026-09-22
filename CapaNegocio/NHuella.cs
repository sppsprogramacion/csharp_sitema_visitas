using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAO;
using DAOImplement;

namespace CapaNegocio
{
    public class NHuella
    {
        //CREAR HUELLA
        public async Task<(DHuella, string error)> CrearHuella(string huella)
        {
            IHuellaDao huellaDao = new HuellaDaoImplement();

            (DHuella huellaResponse, string errorResponse) = await huellaDao.crearHuella(huella);

            return (huellaResponse, errorResponse);
        }
        //FIN CREAR HUELLA..................................

        //RETORNAR HUELLAS X CIUDADANO
        public async Task<(List<DHuella>, string error)> RetornarListaXCiudadano(int dni)
        {
            IHuellaDao huellaDao = new HuellaDaoImplement();

            (List<DHuella> listaHuellas, string errorResponse) = await huellaDao.retornarListaXCiudadano(dni);

            return (listaHuellas, errorResponse);
        }
        //FIN RETORNAR HUELLAS X CIUDADANO..................................

        //RETORNAR HUELLAS TODAS
        public async Task<(List<DHuella>, string error)> RetornarListaTodas()
        {
            IHuellaDao huellaDao = new HuellaDaoImplement();

            (List<DHuella> listaHuellas, string errorResponse) = await huellaDao.retornarListaTodas();

            return (listaHuellas, errorResponse);
        }
        //FIN RETORNAR HUELLAS TODAS..................................

        //SINCRONIZAR
        public async Task<(bool estado, string error)> Sincronizar()
        {
            IHuellaDao huellaDao = new HuellaDaoImplement();

            (bool estadoResponse, string errorResponse) = await huellaDao.sincronizar();

            return (estadoResponse, errorResponse);
        }
        //FIN SINCRONIZAR
        //------------------------------------------------------------------------------------------

        //SINCRONIZACION INICIAL
        public async Task<(bool estado, string error)> SincronizacionInicial()
        {
            IHuellaDao huellaDao = new HuellaDaoImplement();

            (bool estadoResponse, string errorResponse) = await huellaDao.sincronizacionInicial();

            return (estadoResponse, errorResponse);
        }
        //FIN SINCRONIZACION INICIAL
        //------------------------------------------------------------------------------------------

        //SINCRONIZACION INCREMENTAL
        public async Task<(bool estado, string error)> SincronizacionIncremental()
        {
            IHuellaDao huellaDao = new HuellaDaoImplement();

            (bool estadoResponse, string errorResponse) = await huellaDao.sincronizacionIncremental();

            return (estadoResponse, errorResponse);
        }
        //FIN SINCRONIZACION INICIAL
        //------------------------------------------------------------------------------------------
    }
}
