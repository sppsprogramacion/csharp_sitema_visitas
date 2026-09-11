using CapaDatos;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using CommonCache;
using System.Net.Http.Headers;

namespace DAOImplement
{
    public class ProhibisionVisitaAnticipadaDaoImpl : IProhibicionVisitaAnticipadaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR PROHIBICION
        public async Task<(DProhibicionAnticipada, string error)> CrearProhivisionAnticipada(string prohibicionVisita)
        {
            DProhibicionAnticipada dataProhibicion = new DProhibicionAnticipada();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(prohibicionVisita, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/prohibiciones-anticipadas", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataProhibicion = JsonConvert.DeserializeObject<DProhibicionAnticipada>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataProhibicion, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error al crear: {mensaje}");
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
        //FIN CREAR PROHIBICION............................................................

        //EDITAR
        public async Task<(bool, string error)> EditarProhibicionVisitaAnticipada(int id, string prohibicionAnticipada)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(prohibicionAnticipada, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/prohibiciones-anticipadas/" + id, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo editar el registro");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en la edición: {mensaje}");
                }

            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN EDITAR.........................................................

        //LEVANTAR PROHIBICION
        public async Task<(bool, string error)> LevantarProhibicionAnticipada(int id, string dataLevantar)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataLevantar, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/prohibiciones-anticipadas/levantar-manual?id_prohibicion=" + id, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo levantar la prohibicion");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en el levantamiento: {mensaje}");
                }


            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN LEVANTAR PROHIBICION

        //BUSCAR X ID
        public async Task<(DProhibicionAnticipada, string error)> BuscarProhibicionAnticipadaXId(int idProhibicionvisita)
        {
            DProhibicionAnticipada dProhibicion = new DProhibicionAnticipada();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-anticipadas/" + idProhibicionvisita);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dProhibicion = JsonConvert.DeserializeObject<DProhibicionAnticipada>(content);
                    return (dProhibicion, null);
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
        //FIN BUSCAR X ID....................................................

        //LISTA X APELLIDO
        public async Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesAnticipadasXApellido(string apellido)
        {
            List<DProhibicionAnticipada> listaProhibiciones = new List<DProhibicionAnticipada>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-anticipadas/buscarlista-xapellido?apellido=" + apellido);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaProhibiciones = JsonConvert.DeserializeObject<List<DProhibicionAnticipada>>(content);
                    return (listaProhibiciones, null);
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

        //FIN LISTA X APELLIDO..........................................................
        
        //LISTA TODAS
        public async Task<(List<DProhibicionAnticipada>, string error)> ListaProhibicionesTodas()
        {
            List<DProhibicionAnticipada> listaProhibiciones = new List<DProhibicionAnticipada>();

            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/prohibiciones-anticipadas/todos");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaProhibiciones = JsonConvert.DeserializeObject<List<DProhibicionAnticipada>>(content);
                    return (listaProhibiciones, null);
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
        //FIN LISTA TODAS
    }
}
