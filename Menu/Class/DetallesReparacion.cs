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
    public class DetallesReparacion
    {
        public int DetalleID { get; set; }
        public int ReparacionID { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        public DetallesReparacion(int id, int rid, string des, string fechaI, DateTime fechaF)
        {
            DetalleID = id;
            ReparacionID = rid;
            Descripcion = des;
            FechaInicio = fechaI;
            FechaFin = fechaF;

        }
        public DetallesReparacion (int rid, string des, string fechaI, DateTime fechaF)
        {
            ReparacionID = rid;
            Descripcion = des;
            FechaInicio = fechaI;
            FechaFin = fechaF;
        }
        public DetallesReparacion(string des, string fechaI, DateTime fechaF)
        {
            Descripcion = des;
            FechaInicio = fechaI;
            FechaFin = fechaF;
        }

        public DetallesReparacion(string fechaI, DateTime fechaF)
        {
            FechaInicio = fechaI;
            FechaFin = fechaF;
        }

        public DetallesReparacion(DateTime fechaF)
        {
           
            FechaFin = fechaF;
        }

        public DetallesReparacion((int, int, string, string, string) value) { } //exepcion para linea 223

        public static int Agregar(int rid,string des, string fechaI, DateTime fechaF)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@RID", rid));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", des));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaI));
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaF));


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
                    SqlCommand cmd = new SqlCommand("BorrarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DID", id));


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
        public static List<DetallesReparacion> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<DetallesReparacion> Detalle_Reparacion = new List<DetallesReparacion>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DID", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetallesReparacion DetallesReparacion = new DetallesReparacion(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4));  // instancia
                            Detalle_Reparacion.Add(DetallesReparacion);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Detalle_Reparacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Detalle_Reparacion;
        }

        public static int Modificar(int id, int rid, string des, string fechaI, DateTime fechaF)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DID", id));
                    cmd.Parameters.Add(new SqlParameter("@RID", rid));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", des));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaI));
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaF));


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


        public static List<DetallesReparacion> ObtenerTipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<DetallesReparacion> Detalle_Reparacion = new List<DetallesReparacion>();
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
                            DetallesReparacion DetallesReparacion = new DetallesReparacion((reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));  // instancia
                            Detalle_Reparacion.Add(DetallesReparacion);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Detalle_Reparacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Detalle_Reparacion;
        }
    }
}