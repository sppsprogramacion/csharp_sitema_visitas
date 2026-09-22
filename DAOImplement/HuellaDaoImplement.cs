using CapaDatos;
using CommonCache;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace DAOImplement
{
    public class HuellaDaoImplement : IHuellaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR HUELLA
        public async Task<(DHuella, string error)> crearHuella(string huella)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            DHuella dataHuella = new DHuella();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(huella, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/huellas", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataHuella = JsonConvert.DeserializeObject<DHuella>(contentRespuesta);

                    return (dataHuella, null);
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
        //FIN CREAR HUELLA
        //----------------------------------------------------------------------------------
               

        //LISTA TODAS LAS HUELLAS
        public async Task<(List<DHuella>, string error)> retornarListaTodas()
        {
            //variable token
            string token = SessionManager.Token;
            List<DHuella> listaHuellas = new List<DHuella>();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //agregar tpken a la cabecera
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/huellas/todos");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaHuellas = JsonConvert.DeserializeObject<List<DHuella>>(content);
                        return (listaHuellas, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (null, $"Error en la busqueda: {mensaje}");
                    }
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
        //FIN LISTA TODAS LAS HUELLAS
        //---------------------------------------------------------------------------------------

        //LISTA HUELLAS X CIUDADANO
        public async Task<(List<DHuella>, string error)> retornarListaXCiudadano(int idCiudadano)
        {
            //variable token
            string token = SessionManager.Token;
            List<DHuella> listaHuellas = new List<DHuella>();

            try
            { 

                using (HttpClient httpClient = new HttpClient())
                {
                    //agregar tpken a la cabecera
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/huellas/ciudadano/" + idCiudadano);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        listaHuellas = JsonConvert.DeserializeObject<List<DHuella>>(content);
                        return (listaHuellas, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (null, $"Error en la busqueda: {mensaje}");
                    }
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
        //FIN LISTA HUELLAS X CIUDADANO
        //-----------------------------------------------------------------------------------------

        //SINCRONIZAR
        public async Task<(bool estado, string error)> sincronizar()
        {
            DSQLite sqlite = new DSQLite();

            sqlite.Inicializar();

            long ultimaVersion = sqlite.ObtenerUltimaVersion();

            if (ultimaVersion == 0)
            {
                return await sincronizacionInicial();
            }

            return await sincronizacionIncremental();
        }
        //FIN SINCRONIZAR
        //----------------------------------------------------------------------------------------


        //SINCRONIZACION INICIAL
        public async Task<(bool estado, string error)> sincronizacionInicial()
        {
            //variable token
            string token = SessionManager.Token;
            DHuellasSincronizacionInicial dHuellasSincronizacionInicial = new DHuellasSincronizacionInicial();


            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    //agregar tpken a la cabecera
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/huellas/sincronizacion-inicial");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        dHuellasSincronizacionInicial = JsonConvert.DeserializeObject<DHuellasSincronizacionInicial>(content);

                        //INICIALIZAR HUELLAS
                        DSQLite sqlite = new DSQLite();

                        sqlite.Inicializar();

                        sqlite.GuardarSincronizacionInicial(
                            dHuellasSincronizacionInicial.huellas,
                            dHuellasSincronizacionInicial.version
                        );
                        //FIN INICIALIZAR HUELLAS

                        return (true, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        return (false, $"Error en la sincronizacion: {mensaje}");
                    }
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
        //FIN SINCRONIZACION INICIAL
        //------------------------------------------------------------------------------------------

        //SINCRONIZACION INCREMENTAL
        public async Task<(bool estado, string error)> sincronizacionIncremental()
        {
            string token = SessionManager.Token;

            try
            {
                DSQLite sqlite = new DSQLite();
                sqlite.Inicializar();

                long ultimaVersion = sqlite.ObtenerUltimaVersion();

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/huellas/sincronizacion/" + ultimaVersion);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();

                        List<DHuellaCambio> cambios = JsonConvert.DeserializeObject<List<DHuellaCambio>>(content);

                        if (cambios == null || cambios.Count == 0)
                        {
                            return (true, null);
                        }

                        sqlite.AplicarSincronizacionIncremental(cambios);

                        return (true, null);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();

                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();

                        return (false,$"Error en la sincronización: {mensaje}"
                        );
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return (false, $"Error de conexión: {ex.Message}");
            }
            catch (JsonException)
            {
                return (false, "Error inesperado al procesar la respuesta.");
            }
            catch (Exception ex)
            {
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN SINCRONIZACION INCREMENTAL
        //--------------------------------------------------------------------------------------


        //QUITAR HUELLA
        public Task<(bool, string error)> quitarHuella(int idHuella, string detalle_motivo)
        {
            throw new NotImplementedException();
        }

        //FIN QUITAR HUELLA
        //-------------------------------------------------------------------------------------
    }
}
