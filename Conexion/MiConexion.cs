using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class MiConexion
    {
        private static string url = "http://localhost:3000/api";

        //private static string url = "http://programacionspps.online/api";

        public static string getConexion()
        {
            return url;
        }

        public static string HacerSolicitud(string endpoint)
        {
            try
            {
                string urlCompleta = getConexion() + endpoint;
                using (var client = new WebClient())
                {
                    string respuesta = client.DownloadString(urlCompleta);
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return "Error: No se pudo resolver el nombre del servidor. Verifique su conexión a Internet.";
                }
                else
                {
                    return $"Error al intentar conectarse a la API: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }
    }
}
