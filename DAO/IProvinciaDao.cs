using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IProvinciaDao
    {
        DProvincia buscarProvinciaXId(int id);

        Task<(List<DProvincia>, string error)> retornarListaProvinciasXPais(string id_pais);
    }
}
