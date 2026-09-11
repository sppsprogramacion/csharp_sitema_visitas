using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IProhibicionVisitaAnticipadaDao
    {
        Task<(DProhibicionAnticipada, string error)> CrearProhivisionAnticipada(string prohibicionVisita);
        Task<(bool, string error)> LevantarProhibicionAnticipada(int id, string dataLevantar);
        Task<(bool, string error)> EditarProhibicionVisitaAnticipada(int id, string prohibicionVisita);
        Task<(DProhibicionAnticipada, string error)> BuscarProhibicionAnticipadaXId(int idProhibicionvisita);
        Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesAnticipadasXApellido(string apellido);
        Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesTodas();
    }
}
