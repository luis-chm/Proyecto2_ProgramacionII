using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto2_ProgramacionII.Class
{
    public class Equipos
    {
        public int EquipoID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int UsuarioID { get; set; }

        public Equipos(int id, string tipo, string modelo, int userID)
        {
            EquipoID = id;
            TipoEquipo = tipo;
            Modelo = modelo;
            UsuarioID = userID;
        }
        public Equipos(string tipo, string modelo, int userID)
        {
            TipoEquipo = tipo;
            Modelo = modelo;
            UsuarioID = userID;
        }
        public Equipos(string tipo, string modelo)
        {
            TipoEquipo = tipo;
            Modelo = modelo;
        }
        public Equipos(string modelo)
        {
            Modelo = modelo;
        }

        public Equipos() { }

        public static int Agregar(string tipo, string modelo, int userID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UID", userID));


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

        public static int Borrar(int equipoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EID", equipoID));


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
        public static List<Equipos> consultaFiltro(int equipoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Equipos> equipo = new List<Equipos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EID", equipoID));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipos equipos = new Equipos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));  // instancia
                            equipo.Add(equipos);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return equipo;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return equipo;
        }

        public static int Modificar(int equipoID, string tipo, string modelo, int userID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UID", userID));


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


        public static List<Equipos> ObtenerTipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Equipos> equipo = new List<Equipos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipos equipos = new Equipos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));  // instancia
                            equipo.Add(equipos);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return equipo;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return equipo;
        }
    }
}