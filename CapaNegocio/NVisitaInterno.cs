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
    public class NVisitaInterno
    {
        //RETORNAR PARENTESCOS POR CIUDADANO
        public async Task<(List<DVisitaInterno>, string error)> RetornarListaParentescos(int idCiudadano)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (List<DVisitaInterno> listaParentescos, string errorResponse) = await visitaInternoDao.RetornarParentescosXCiudadano(idCiudadano);


            return (listaParentescos, errorResponse);
        }
        //FIN RETORNAR PARENTESCOS POR CIUDADANO..................................

        //CAMBIAR PARENTESCO
        public async Task<(bool, string error)> CambiarParentesco(int id, string prohibicioVisita)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.CambiarParentesco(id, prohibicioVisita);

            return (visitaInternoResponse, error); ;
        }
        //FIN CAMBIAR PARENTESCO..................................

        //PROHIBIR PARENTESCO
        public async Task<(bool, string error)> ProhibirParentesco(int id, string prohibicionParentesco)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.ProhibirParentesco(id, prohibicionParentesco);

            return (visitaInternoResponse, error); ;
        }
        //FIN PROHIBIR PARENTESCO..................................

        //LEVANTAR PROHIBICION PARENTESCO
        public async Task<(bool, string error)> LevantarProhibicionParentesco(int id, string dataLevantar)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.LevantarProhibicionParentesco(id, dataLevantar);

            return (visitaInternoResponse, error); ;
        }
        //FIN LEVANTAR PROHIBICION PARENTESCO..................................

        //REVINCULAR PARENTESCO
        public async Task<(bool, string error)> RevincularParentesco(int id, string dataActualizar)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.RevincularParentesco(id, dataActualizar);

            return (visitaInternoResponse, error); ;
        }
        //FIN REVINCULAR PARENTESCO..................................

        //DESVINCULAR PARENTESCO
        public async Task<(bool, string error)> DesvincularParentesco(int id, string dataActualizar)
        {
            IVisitaInternoDao visitaInternoDao = new VisitaInternoDaoImpl();

            (bool visitaInternoResponse, string error) = await visitaInternoDao.DesvincularParentesco(id, dataActualizar);

            return (visitaInternoResponse, error); ;
        }
        //FIN DESVINCULAR PARENTESCO..................................
    }
}
