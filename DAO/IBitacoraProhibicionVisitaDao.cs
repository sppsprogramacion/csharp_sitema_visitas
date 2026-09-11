using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IBitacoraProhibicionVisitaDao
    {
        Task<DBitacoraProhibicionVisita> buscarBitacoraProhibicionVisitaXId(int idBitacora);

        Task<List<DBitacoraProhibicionVisita>> retornarBitacoraProhibicionVisitaXProhibicion(int idProhibicion);
    }
}
