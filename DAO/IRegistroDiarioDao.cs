using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace DAO
{
    public interface IRegistroDiarioDao
    {

        Task<(List<DRegistroDiario>, string error)> ListaXCiudadano(int idCiudadano);

    }
}
