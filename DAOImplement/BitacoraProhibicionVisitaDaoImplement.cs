using CapaDatos;
using Conexion;
using DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class BitacoraProhibicionVisitaDaoImplement : IBitacoraProhibicionVisitaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public Task<DBitacoraProhibicionVisita> buscarBitacoraProhibicionVisitaXId(int idBitacora)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DBitacoraProhibicionVisita>> retornarBitacoraProhibicionVisitaXProhibicion(int idProhibicion)
        {
            List<DBitacoraProhibicionVisita> listaBitacoraProhibicion = new List<DBitacoraProhibicionVisita>();

            var httpResponse = await this.httpClient.GetAsync(url_base + "/bitacora-prohibiciones-visita/buscar-xprohibicion?id_prohibicion=" + idProhibicion);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                listaBitacoraProhibicion = JsonConvert.DeserializeObject<List<DBitacoraProhibicionVisita>>(content);

            }
            var objeto = listaBitacoraProhibicion;

            return listaBitacoraProhibicion;
        }
    }
}
