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
    public class NParentesco
    {
        //RETORNAR PARENTESCOS TODOS
        public async Task<(List<DParentesco>, string)> RetornarListaParentescos()
        {
            IParentescoDao parentescoDao = new ParentescoDaoImpl();

            (List<DParentesco> listaResponse, string errorResponse) = await parentescoDao.RetornarParentescos();


            return (listaResponse, errorResponse);
        }
        //FIN RETORNAR PARENTESCOS TODOS..................................
    }
}
