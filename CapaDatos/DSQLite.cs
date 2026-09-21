using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSQLite
    {
        private readonly string carpetaDatos;
        private readonly string rutaBase;
        private readonly string cadenaConexion;

        public DSQLite()
        {
            carpetaDatos = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AtencionCiudadano"
            );

            rutaBase = Path.Combine(carpetaDatos,"huellas.db");

            cadenaConexion =$"Data Source={rutaBase};Version=3;";
        }

        public void Inicializar()
        {
            if (!Directory.Exists(carpetaDatos))
            {
                Directory.CreateDirectory(carpetaDatos);
            }

            bool baseNueva = !File.Exists(rutaBase);

            if (baseNueva)
            {
                SQLiteConnection.CreateFile(rutaBase);
            }

            CrearTablas();
        }

        private void CrearTablas()
        {
            using (SQLiteConnection conexion =
                   new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS huellas
                (
                    id_huella_ciudadano INTEGER PRIMARY KEY,
                    ciudadano_id INTEGER NOT NULL,
                    dedo_id INTEGER NOT NULL,
                    huella BLOB NOT NULL
                );

                CREATE TABLE IF NOT EXISTS sincronizacion
                (
                    id INTEGER PRIMARY KEY,
                    ultima_version INTEGER NOT NULL
                );
            ";

                using (SQLiteCommand comando =
                       new SQLiteCommand(sql, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void GuardarHuella(int idHuella,int ciudadanoId,int dedoId,byte[] huella)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"INSERT INTO huellas(id_huella_ciudadano, ciudadano_id,dedo_id,huella)
                                VALUES(@idHuella, @ciudadanoId, @dedoId, @huella);";

                using (SQLiteCommand comando = new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idHuella", idHuella);

                    comando.Parameters.AddWithValue("@ciudadanoId", ciudadanoId);

                    comando.Parameters.AddWithValue("@dedoId", dedoId);

                    comando.Parameters.Add("@huella", System.Data.DbType.Binary).Value = huella;

                    comando.ExecuteNonQuery();
                }
            }
        }

        

        //BUSCAR HUELLA X ID
        public byte[] ObtenerHuella(int idHuella)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"SELECT huella FROM huellas HERE id_huella_ciudadano = @idHuella;";

                using (SQLiteCommand comando =new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idHuella",idHuella);

                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        return null;
                    }

                    return (byte[])resultado;
                }
            }
        }
        //FIN BUSCAR HUELLA
        //------------------------------------------------------------------

        //LISTA DE TODAS LAS HUELLAS
        public List<DHuellaLocal> ObtenerTodasLasHuellas()
        {
            List<DHuellaLocal> lista = new List<DHuellaLocal>();

            using (SQLiteConnection conexion =new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"SELECT id_huella_ciudadano, ciudadano_id, dedo_id, huella 
                                FROM huellas
                                ORDER BY id_huella_ciudadano ASC;";


                using (SQLiteCommand comando = new SQLiteCommand(sql, conexion))

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DHuellaLocal huella = new DHuellaLocal();

                        huella.id_huella_ciudadano = Convert.ToInt32(reader["id_huella_ciudadano"]);

                        huella.ciudadano_id = Convert.ToInt32(reader["ciudadano_id"]);

                        huella.dedo_id = Convert.ToInt32(reader["dedo_id"]);

                        //byte[] templateBytes = (byte[])reader["huella"];

                        // Como DHuella actualmente maneja
                        // huella como Base64:
                        //huella.huella = Convert.ToBase64String(templateBytes);
                        huella.huella = (byte[])reader["huella"];

                        lista.Add(huella);
                    }
                }
            }

            return lista;
        }
        //FIN LISTA DE TODAS LAS HUELLAS
        //--------------------------------------------------------------------

        //LIMPIAR HUELLAS
        public void LimpiarHuellas()
        {
            using (SQLiteConnection conexion =
                   new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = "DELETE FROM huellas;";

                using (SQLiteCommand comando =
                       new SQLiteCommand(sql, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
        //FIN LIMPÍAR HUELLAS
        //-------------------------------------------------------------------

        //GUARDAR ULTIMA VERSION
        public void GuardarUltimaVersion(string version)
        {
            using (SQLiteConnection conexion =
                   new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"INSERT INTO sincronizacion(id,ultima_version)
                                VALUES(1,@version)
                                    ON CONFLICT(id)
                                    DO UPDATE SET
                                        ultima_version = @version;
                             ";

                using (SQLiteCommand comando =
                       new SQLiteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@version",version
                    );

                    comando.ExecuteNonQuery();
                }
            }
        }
        //FIN GUARDAR ULTIMA VERSION
        //--------------------------------------------------------------------

        //SINCRONIZACION INICIAL
        public void GuardarSincronizacionInicial(List<DHuella> huellas,string version)
        {
            using (SQLiteConnection conexion =new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                using (SQLiteTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // ---------------------------------
                        // BORRAR HUELLAS ACTUALES
                        // ---------------------------------

                        string sqlBorrar = "DELETE FROM huellas;";

                        using (SQLiteCommand comando =new SQLiteCommand(sqlBorrar,conexion,transaccion))
                        {
                            comando.ExecuteNonQuery();
                        }


                        // ---------------------------------
                        // INSERTAR HUELLAS
                        // ---------------------------------

                        string sqlHuella = @"INSERT INTO huellas(id_huella_ciudadano,ciudadano_id,dedo_id,huella)
                                            VALUES(@idHuella,@ciudadanoId,@dedoId,@huella);";

                        foreach (DHuella huella in huellas)
                        {
                            byte[] templateBytes = Convert.FromBase64String(huella.huella);

                            using (SQLiteCommand comando = new SQLiteCommand(sqlHuella,conexion,transaccion))
                            {
                                comando.Parameters.AddWithValue("@idHuella",huella.id_huella_ciudadano);

                                comando.Parameters.AddWithValue("@ciudadanoId",huella.ciudadano_id);

                                comando.Parameters.AddWithValue("@dedoId",huella.dedo_id);

                                comando.Parameters.Add("@huella",System.Data.DbType.Binary).Value = templateBytes;

                                comando.ExecuteNonQuery();
                            }
                        }


                        // ---------------------------------
                        // GUARDAR VERSION
                        // ---------------------------------

                        string sqlVersion = @"INSERT INTO sincronizacion(id,ultima_version)
                                             VALUES(1,@version)
                                             ON CONFLICT(id) DO UPDATE SET ultima_version = @version;";

                        using (SQLiteCommand comando = new SQLiteCommand(sqlVersion,conexion,transaccion))
                        {
                            comando.Parameters.AddWithValue("@version",version);

                            comando.ExecuteNonQuery();
                        }


                        // ---------------------------------
                        // CONFIRMAR TODO
                        // ---------------------------------

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
        //FIN SINCRONIZACION INICIAL
        //------------------------------------------------------------------------------------

        //OBTENER ULTIMA VERSION
        public long ObtenerUltimaVersion()
        {
            using (SQLiteConnection conexion =new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = @"SELECT ultima_version FROM sincronizacion WHERE id = 1;";

                using (SQLiteCommand comando =new SQLiteCommand(sql, conexion))
                {
                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        return 0;
                    }

                    return Convert.ToInt64(resultado);
                }
            }
        }
        //FIN OBTENER ULTIMA VERSION
        //------------------------------------------------------------------------------------

        //APLICAR SINCRONIZACION INCREMENTAL
        public void AplicarSincronizacionIncremental(List<DHuellaCambio> cambios)
        {
            if (cambios == null || cambios.Count == 0)
                return;


            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                using (SQLiteTransaction transaccion =conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (DHuellaCambio cambio in cambios)
                        {
                            if (cambio.accion == "ALTA")
                            {
                                byte[] templateBytes = Convert.FromBase64String(cambio.huella);

                                string sqlAlta = @"INSERT OR REPLACE INTO huellas(id_huella_ciudadano, ciudadano_id, dedo_id, huella)
                                                VALUES (@idHuella, @ciudadanoId, @dedoId, @huella );";

                                using (SQLiteCommand comando = new SQLiteCommand(sqlAlta, conexion, transaccion))
                                {
                                    comando.Parameters.AddWithValue("@idHuella", cambio.huella_id);

                                    comando.Parameters.AddWithValue( "@ciudadanoId", cambio.ciudadano_id);

                                    comando.Parameters.AddWithValue("@dedoId", cambio.dedo_id);

                                    comando.Parameters.Add("@huella",System.Data.DbType.Binary).Value = templateBytes;

                                    comando.ExecuteNonQuery();
                                }
                            }
                            else if (cambio.accion == "BAJA")
                            {
                                string sqlBaja = @" DELETE FROM huellas WHERE id_huella_ciudadano = @idHuella;";

                                using (SQLiteCommand comando =new SQLiteCommand(sqlBaja, conexion, transaccion))
                                {
                                    comando.Parameters.AddWithValue("@idHuella", cambio.huella_id);

                                    comando.ExecuteNonQuery();
                                }
                            }
                        }

                        // La nueva versión será la del último cambio aplicado
                        string ultimaVersion = cambios[cambios.Count - 1].version;

                        string sqlVersion = @"INSERT INTO sincronizacion(id, ultima_version)
                                              VALUES(1, @version)
                                              ON CONFLICT(id) DO UPDATE SET ultima_version = @version;";

                        using (SQLiteCommand comando = new SQLiteCommand(sqlVersion,conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue("@version",ultimaVersion);

                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
        //FIN APLICAR SINCRONIZACION INCREMENTAL
        //-------------------------------------------------------------------------------------
    }
}
