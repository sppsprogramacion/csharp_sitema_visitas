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
    public class NBitacoraProhibicionAnticipadas
    {
        //RETORNAR BITACORA PROHIBICIONES ANTICIPADA POR PROHIBICION
        public async Task<(List<DBitacoraProhibicionAnticipada>, string error)> RetornarListaBitacoraProhibicionesAnticipadas(int idProhibicion)
        {
            IBitacoraProhibicionAnticipadaDao bitacoraProhibicionDao = new BitacoraProhibicionAnticipadaDaoImplement();

            (List<DBitacoraProhibicionAnticipada> listaBitacoraProhibiciones, string errorResponse) = await bitacoraProhibicionDao.retornarBitacoraProhibicionAnticipadasXProhibicion(idProhibicion);


            return (listaBitacoraProhibiciones, errorResponse);
        }
        //FIN BITACORA PROHIBICIONES VISITA POR PROHIBICION..................................
    }
}
