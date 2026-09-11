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
    public class ParentescoDaoImpl : IParentescoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public Task<DParentesco> BuscarParentescoXId(int idParentesco)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<DParentesco>, string)> RetornarParentescos()
        {
            string token = SessionManager.Token; // Aquí pones tu token real
            List<DParentesco> listaParentescos = new List<DParentesco>();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/parentescos/todos");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaParentescos = JsonConvert.DeserializeObject<List<DParentesco>>(content);
                    return (listaParentescos, null);
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
