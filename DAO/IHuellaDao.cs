using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IHuellaDao
    {
        Task<(DHuella, string error)> crearHuella(string huella);
        Task<(List<DHuella>, string error)> retornarListaXCiudadano(int idCiudadano);
        Task<(List<DHuella>, string error)> retornarListaTodas();
        Task<(bool estado, string error)> sincronizar();
        Task<(bool estado, string error)> sincronizacionInicial();
        Task<(bool estado, string error)> sincronizacionIncremental();

        Task<(bool, string error)> quitarHuella(int idHuella, string detalle_motivo);

    }
}
