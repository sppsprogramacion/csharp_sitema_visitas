using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using CapaDatos;
using Conexion;
using DAO;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using CommonCache;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class RegistroDiarioDaoImpl : IRegistroDiarioDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();


        //RETORNAR LISTA X CIUDADANO
        async public Task<(List<DRegistroDiario>, string error)> ListaXCiudadano(int idCiudadano)
        {
            List<DRegistroDiario> listaRegistroDiario = new List<DRegistroDiario>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/registro-diario/lista-xciudadano?id_ciudadano=" + idCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaRegistroDiario = JsonConvert.DeserializeObject<List<DRegistroDiario>>(content);
                    return (listaRegistroDiario, null);
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
        //FIN RETORNAR LISTA X CIUDADANO...................................
    }
}
