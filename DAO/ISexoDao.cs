using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ISexoDao
    {
        
        DSexo buscarSexoXId(int id);

        Task<(List<DSexo>, string error)> retornarListaSexo();
    }
}
