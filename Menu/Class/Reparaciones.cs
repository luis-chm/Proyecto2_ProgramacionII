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
    public class Reparaciones
    {
        public int ReparacionID { get; set; }
        public int EquipoID { get; set; }
        public string FechaSolicitud { get; set; }
        public string Estado { get; set; }
        

        public Reparaciones(int id, int eid, string fecha, string estado)
        {
            ReparacionID = id;
            EquipoID = eid;
            FechaSolicitud = fecha;
            Estado = estado;
            
        }
        public Reparaciones(int eid, string fecha, string estado)
        {
            EquipoID = eid;
            FechaSolicitud = fecha;
            Estado = estado;
        }
        public Reparaciones(string fecha, string estado)
        {
            FechaSolicitud = fecha;
            Estado = estado;
        }
        public Reparaciones(string estado)
        {
            Estado = estado;
        }

        public Reparaciones((int, int, string, string) value) { } //adicion

        public static int Agregar(int eid, string fecha, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EID", eid));
                    cmd.Parameters.Add(new SqlParameter("@FechaSolicitud", fecha));
                    cmd.Parameters.Add(new SqlParameter("@Estado", estado));


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
                    SqlCommand cmd = new SqlCommand("BorrarReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@RID", id));


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
        public static List<Reparaciones> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Reparaciones> reparacion = new List<Reparaciones>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@RID", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reparaciones Reparaciones = new Reparaciones(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));  // instancia
                            reparacion.Add(Reparaciones);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return reparacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return reparacion;
        }

        public static int Modificar(int id, int eid, string fecha, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@RID", id));
                    cmd.Parameters.Add(new SqlParameter("@EID", eid));
                    cmd.Parameters.Add(new SqlParameter("@FechaSolicitud", fecha));
                    cmd.Parameters.Add(new SqlParameter("@Estado", estado));
                    

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


        public static List<Reparaciones> ObtenerTipos()
         {
             int retorno = 0;

             SqlConnection Conn = new SqlConnection();
             List<Reparaciones> reparacion = new List<Reparaciones>();
             try
             {

                 using (Conn = DBConn.obtenerConexion())
                 {
                     SqlCommand cmd = new SqlCommand("ConsultarReparacion", Conn)
                     {
                         CommandType = CommandType.StoredProcedure
                     };
                     retorno = cmd.ExecuteNonQuery();
                     using (SqlDataReader reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             Reparaciones reparaciones = new Reparaciones((reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)));  // instancia
                             reparacion.Add(reparaciones);
                         }

                     }
                 }
             }
             catch (System.Data.SqlClient.SqlException ex)
             {
                 return reparacion;
             }
             finally
             {
                 Conn.Close();
                 Conn.Dispose();
             }

             return reparacion;
         }
    }
}