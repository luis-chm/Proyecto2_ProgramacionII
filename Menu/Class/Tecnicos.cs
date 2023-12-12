using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto2_ProgramacionII.Class
{
    public class Tecnicos
    {
        public int TecnicoID { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public Tecnicos(int id, string nombre, string especialidad)
        {
            TecnicoID = id;
            Nombre = nombre;
            Especialidad = especialidad;
        }
        public Tecnicos(string nombre, string especialidad)
        {
            Nombre = nombre;
            Especialidad = especialidad;
        }
        public Tecnicos(string especialidad)
        {
            Especialidad = especialidad;
        }

        public Tecnicos() { }

        public static int AgregarTec(string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));

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

        public static int BorrarTec(int tecnicoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TID", tecnicoID));


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
        public static List<Tecnicos> consultaFiltroTec(int tecnicoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Tecnicos> tecnico = new List<Tecnicos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TID", tecnicoID));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tecnicos tecnicos = new Tecnicos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));  // instancia
                            tecnico.Add(tecnicos);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return tecnico;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return tecnico;
        }

        public static int ModificarTec(int tecnicoID, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TID", tecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));

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
    }
}