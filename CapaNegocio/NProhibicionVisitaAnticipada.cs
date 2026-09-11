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
    public class NProhibicionVisitaAnticipada
    {
        //CREAR PROHIBICION
        public async Task<(DProhibicionAnticipada, string error)> CrearProhibicion(string prohibicioAnticipada)
        {
            IProhibicionVisitaAnticipadaDao prohibicionDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (DProhibicionAnticipada prohibicionResponse, string errorResponse) = await prohibicionDao.CrearProhivisionAnticipada(prohibicioAnticipada);

            return (prohibicionResponse, errorResponse);
        }
        //FIN CREAR PROHIBICION..................................

        //EDITAR PROHIBICION
        public async Task<(bool, string error)> EditarProhibicion(int id, string prohibicionAnticipada)
        {
            IProhibicionVisitaAnticipadaDao prohibicionVisitaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.EditarProhibicionVisitaAnticipada(id, prohibicionAnticipada);

            return (prohibicionResponse, error);
        }
        //FIN EDITAR PROHIBICION....................................................

        //LEVANTAR MANUAL PROHIBICION
        public async Task<(bool, string error)> LevantarManualProhibicion(int id, string dataLevantar)
        {
            IProhibicionVisitaAnticipadaDao prohibicionVisitaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.LevantarProhibicionAnticipada(id, dataLevantar);

            return (prohibicionResponse, error);
        }
        //FIN LEVANTAR MANUAL PROHIBICION..................................

        //BUSCAR X ID
        public async Task<(DProhibicionAnticipada, string error)> BuscarProhibicionXId(int id)
        {
            IProhibicionVisitaAnticipadaDao prohibicionDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (DProhibicionAnticipada dProhibicion, string error) = await prohibicionDao.BuscarProhibicionAnticipadaXId(id);


            return (dProhibicion, error);
        }
        //FIN BUSCAR XID..................................

        //RETORNAR TODOS
        public async Task<(List<DProhibicionAnticipada>, string)> ListaProhibicionesTodas()
        {
            IProhibicionVisitaAnticipadaDao prohibicionAnticipadaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (List<DProhibicionAnticipada> listaProhibiciones, string error) = await prohibicionAnticipadaDao.ListaProhibicionesTodas();


            return (listaProhibiciones, error);
        }
        //FIN RETORNAR TODOS..................................

        
        //RETORNAR X APELLIDO
        public async Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesXApellido(string apellido)
        {
            IProhibicionVisitaAnticipadaDao prohibicionAnticipadaDao = new ProhibisionVisitaAnticipadaDaoImpl();

            (List<DProhibicionAnticipada> listaProhibiciones, string error) = await prohibicionAnticipadaDao.ListaProhibicionesAnticipadasXApellido(apellido);

            return (listaProhibiciones, error);
        }
        //FIN RETORNAR X APELLIDO..................................
    }
}
