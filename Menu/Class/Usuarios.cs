using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto2_ProgramacionII.Class
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public Usuarios(int id, string nombre, string correo, string telefono)
        {
            UsuarioID = id;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
        }
        public Usuarios(string nombre, string correo, string telefono)
        {
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
        }
        public Usuarios(string correo, string telefono)
        {
            Correo = correo;
            Telefono = telefono;
        }
        public Usuarios(string telefono)
        {
            Telefono = telefono;
        }

        public Usuarios() { }

        public static int AgregarUser(string nombre, string correo, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));


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

        public static int BorraruUser(int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UID", usuarioID));


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
        public static List<Usuarios> consultaFiltroUser(int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Usuarios> usuario = new List<Usuarios>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UID", usuarioID));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios usuarios = new Usuarios(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(4));  // instancia
                            usuario.Add(usuarios);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuario;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuario;
        }

        public static int ModificarUser(int usuarioID, string nombre, string correo, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UID", usuarioID));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));


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
    }//fin clase
}//fin namespace

