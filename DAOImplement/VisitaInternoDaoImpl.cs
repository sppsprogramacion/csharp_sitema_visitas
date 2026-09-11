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
    public class VisitaInternoDaoImpl : IVisitaInternoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //BUSCAR PARENTESCO  X ID
        public Task<(DVisitaInterno, string)> BuscarParentescoXId(int idProhibicionvisita)
        {
            throw new NotImplementedException();
        }
        //FIN BUSCAR PARENTESCO  X ID...............................

        //RETORNAR PARENTESCO POR CIUDADANO
        public async Task<(List<DVisitaInterno>, string error)> RetornarParentescosXCiudadano(int idCiudadano)
        {
            string token = SessionManager.Token; // Aquí pones tu token real
            List<DVisitaInterno> listaVinculos = new List<DVisitaInterno>();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/visitas-internos/buscarlista-xciudadano?id_ciudadano=" + idCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaVinculos = JsonConvert.DeserializeObject<List<DVisitaInterno>>(content);
                    return (listaVinculos, null);
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
        //FIN RETORNAR PARENTESCO POR CIUDADANO.................................

        //RETORNAR PARENTESCOS POR INTERNO
        public Task<(List<DVisitaInterno>, string error)> RetornarParentescosXInterno(int idInterno)
        {
            throw new NotImplementedException();
        }
        //FIN RETORNAR PARENTESCOS POR INTERNO...................................

        //CAMBIAR PARENTESCO
        public async Task<(bool, string error)> CambiarParentesco(int id, string dataCambiar)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataCambiar, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/cambiar-parentesco?id_visita_interno=" + id, content);

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
                        return (false, "No se pudo cambiar el parentesco.");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en el cambio de parentesco: {mensaje}");
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
        //FIN CAMBIAR PARENTESCO...................................................

        
        public async Task<(bool, string error)> LevantarProhibicionParentesco(int id, string dataLevantar)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataLevantar, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/levantar-prohibicion-parentesco?id_visita_interno=" + id, content);

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
                        return (false, "No se pudo levantar la prohibicion el parentesco.");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en levantar la prohibicion del parentesco: {mensaje}");
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

        //PROHIBIR PARENTESCO
        public async Task<(bool, string error)> ProhibirParentesco(int id, string dataProhibir)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataProhibir, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/prohibir-parentesco?id_visita_interno=" + id, content);

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
                        return (false, "No se pudo prohibir el parentesco.");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en la prohibicion del parentesco: {mensaje}");
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
        //FIN PROHIBIR PARENTESCO........................................................

        public Task<(bool, string error)> AnularParentesco(int id, string dataAnular)
        {
            throw new NotImplementedException();
        }

        //REVINCULAR PARENTESCO
        public async Task<(bool, string error)> RevincularParentesco(int id, string dataActualizar)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataActualizar, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/revincular-parentesco?id_visita_interno=" + id, content);

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
                        return (false, "No se pudo revincular el parentesco.");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en la revinculacion del parentesco: {mensaje}");
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
        //FIN REVINCULAR PARENTESCO.....................................................

        //DESVINCULAR PARENTESCO
        public async Task<(bool, string error)> DesvincularParentesco(int id, string dataActualizar)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(dataActualizar, Encoding.UTF8, "application/json");

                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/visitas-internos/desvincular-parentesco?id_visita_interno=" + id, content);

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
                        return (false, "No se pudo revincular el parentesco.");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error en la revinculacion del parentesco: {mensaje}");
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
        //FIN DESVINCULAR PARENTESCO

    }
}
