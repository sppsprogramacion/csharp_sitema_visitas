using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IParentescoDao
    {
        Task<DParentesco> BuscarParentescoXId(int idParentesco);

        Task<(List<DParentesco>, string error)> RetornarParentescos();
    }
}
