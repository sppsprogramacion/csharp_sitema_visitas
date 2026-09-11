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
    public class SexoDaoImpl : ISexoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public DSexo buscarSexoXId(int id)
        {
            throw new NotImplementedException();
        }

        async public Task<(List<DSexo>, string)> retornarListaSexo()
        {
            string token = SessionManager.Token; // Aquí pones tu token real
            List<DSexo> listaSexo = new List<DSexo>();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/sexo");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaSexo = JsonConvert.DeserializeObject<List<DSexo>>(content);
                    return (listaSexo, null);
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
