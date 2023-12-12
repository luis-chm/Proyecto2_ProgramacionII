using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Proyecto2_ProgramacionII.Class
{
    public class Asignaciones
    {
        public int AsignacionID { get; set; }
        public int ReparacionID { get; set; }
        public int TecnicoID { get; set; }
        public string FechaAsignacion { get; set; }


        public Asignaciones(int id, int rid, int tid, string fecha)
        {
            AsignacionID = id;
            ReparacionID = rid;
            TecnicoID = tid;
            FechaAsignacion = fecha;

        }
        public Asignaciones(int rid, int tid, string fecha)
        {
            ReparacionID = rid;
            TecnicoID = tid;
            FechaAsignacion = fecha;
        }
        public Asignaciones(int tid, string fecha)
        {
            TecnicoID = tid;
            FechaAsignacion = fecha;
        }
        public Asignaciones(string fecha)
        {
            FechaAsignacion = fecha;
        }

        public Asignaciones((int, int, int, string) value) { } //exepcion para linea 209

        public static int Agregar(int rid, int tid, string fecha)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@RID", rid));
                    cmd.Parameters.Add(new SqlParameter("@TID", tid));
                    cmd.Parameters.Add(new SqlParameter("@FechaAsignacion", fecha));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Borrar(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AID", id));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;


        }
        public static List<Asignaciones> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Asignaciones> asignacion = new List<Asignaciones>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AID", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asignaciones Asignaciones = new Asignaciones(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));  // instancia
                            asignacion.Add(Asignaciones);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return asignacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return asignacion;
        }

        public static int Modificar(int id, int rid, int tid, string fecha)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AID", id));
                    cmd.Parameters.Add(new SqlParameter("@RID", rid));
                    cmd.Parameters.Add(new SqlParameter("@TID", tid));
                    cmd.Parameters.Add(new SqlParameter("@FechaAsignacion", fecha));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }


        public static List<Asignaciones> ObtenerTipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Asignaciones> asignacion = new List<Asignaciones>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asignaciones Asignaciones = new Asignaciones((reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3)));  // instancia
                            asignacion.Add(Asignaciones);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return asignacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return asignacion;
        }
    }
}