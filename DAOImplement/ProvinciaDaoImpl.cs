using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class ProvinciaDaoImpl : IProvinciaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public DProvincia buscarProvinciaXId(int id)
        {
            throw new NotImplementedException();
        }

        async public Task<(List<DProvincia>, string)> retornarListaProvinciasXPais(string id_pais)
        {
            string token = SessionManager.Token; // Aquí pones tu token real
            List<DProvincia> listaProvincias = new List<DProvincia>();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/provincias/buscar-xpais?id_pais=" + id_pais);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaProvincias = JsonConvert.DeserializeObject<List<DProvincia>>(content);
                    return (listaProvincias, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
            
        }
    }
}
