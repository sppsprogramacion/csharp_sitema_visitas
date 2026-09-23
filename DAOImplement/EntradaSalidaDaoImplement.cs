using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class EntradaSalidaDaoImplement : IEntradaSalidaDao
    {

        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //NUEVO INGRESO
        public async Task<(DEntradaSalidaIngresoPPResponse, string error)> CrearEntradaSalida(string entradaSalida)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            DEntradaSalidaIngresoPPResponse dataEntradaSalida = new DEntradaSalidaIngresoPPResponse();

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(entradaSalida, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/entradas-salidas", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataEntradaSalida = JsonConvert.DeserializeObject<DEntradaSalidaIngresoPPResponse>(contentRespuesta);

                    return (dataEntradaSalida, null);
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
        // FIN NUEVO INGRESO      

        //BUSCAR CIUDADANO INGRESO X DNI
        public async Task<(DCiudadanoIngreso, string error)> BuscarCiudadanoIngresoXDni(int dniCiudadano)
        {
            DCiudadanoIngreso dCiudadanoIngreso = new DCiudadanoIngreso();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/entradas-salidas/buscar-ciudadano/" + dniCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dCiudadanoIngreso = JsonConvert.DeserializeObject<DCiudadanoIngreso>(content);
                    return (dCiudadanoIngreso, null);
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
        //FIN BUSCAR CIUDADANO INGRESO X DNI
        //--------------------------------------------------------------------------


        //BUSCAR CIUDADANO INGRESADO PATRA CONTROL
        public async Task<(DCiudadanoIngresoControl, string error)> BuscarCiudadanoIngresoControlXFicha(int numeroFicha)
        {
            DCiudadanoIngresoControl dCiudadanoIngreso = new DCiudadanoIngresoControl();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/entradas-salidas/buscar-ciudadano-ingreso-control/" + numeroFicha);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dCiudadanoIngreso = JsonConvert.DeserializeObject<DCiudadanoIngresoControl>(content);
                    return (dCiudadanoIngreso, null);
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
        //FIN BUSCAR CIUDADANO INGRESADO PATRA CONTROL
        //--------------------------------------------------------------------------

        public Task<(DEntradaSalida, string error)> BuscarEntradaSalidaXId(int idEntradaSalida)
        {
            throw new NotImplementedException();
        }


        public Task<(List<DEntradaSalida>, string error)> ListaEntradaSalidaXCiudadano(int idCiudadano)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string error)> AnularEntradaSalida(int id, string dataAnular)
        {
            throw new NotImplementedException();
        }

        
    }
}
