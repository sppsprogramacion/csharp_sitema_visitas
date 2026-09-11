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
    public class NBitacoraProhibicionVisita
    {
        //RETORNAR BITACORA PROHIBICIONES VISITA POR PROHIBICION
        public async Task<List<DBitacoraProhibicionVisita>> RetornarListaBitacoraProhibicionesVisita(int idProhibicion)
        {
            IBitacoraProhibicionVisitaDao bitacoraProhibicionVisitaDao = new BitacoraProhibicionVisitaDaoImplement();

            List<DBitacoraProhibicionVisita> listaBitacoraProhibicionesVisita = await bitacoraProhibicionVisitaDao.retornarBitacoraProhibicionVisitaXProhibicion(idProhibicion);


            return listaBitacoraProhibicionesVisita;
        }
        //FIN BITACORA PROHIBICIONES VISITA POR PROHIBICION..................................
    }
}
