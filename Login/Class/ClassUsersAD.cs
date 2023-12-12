using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace Proyecto2_ProgramacionII
{
    public class ClassUsersAD
    {
        private static string clave;
        private static string usuario;
        private static string nombre;
        private static int IDUsuario;
        private static string correo;
        private static int idrol;
        private static string rolename;
        private static int TecnicoID;
        public ClassUsersAD(string Clave, string Usuario)// constructor sirve para inicializar las variables
        {
            clave = Clave;
            usuario = Usuario;
        }

        //getter: muestra los atributos (variables de la clase). Es una funcion--> devuelve algo
        //setter: Asigna un valor a los atributos. ------------- Es u void-------> no devuelve nada, solo asigna.

        public static string Getclave()
        {
            return clave;

        }

        public static string Getusuario()
        {
            return usuario;

        }
        public static string Getnombre()
        {
            return nombre;

        }
        public static int GetIDUsuario()
        {
            return IDUsuario;
        }
        public static string Getcorreo()
        {
            return correo;
        }
        public static int Getidrol()
        {
            return idrol;
        }
        public static string Getrolename()
        {
            return rolename;
        }
        public static int GetTecnicoID()
        {
            return TecnicoID;
        }
        public void Setclave(string contraeña)
        {
            clave = contraeña;

        }
        public void Setusuario(string Usuario)
        {
            usuario = Usuario;

        }
        public void Setnombre(string Nombre)
        {
            nombre = Nombre;

        }
        public void SetIDUsuario(int idusuario)
        {
            IDUsuario = idusuario;
        }
        public void Setcorreo(string Correo)
        {
            correo = Correo;
        }
        public void Setidrol(int IDRol)
        {
            idrol = IDRol;
        }
        public void Setrolename(string RoleName)
        {
            rolename = RoleName;
        }
        public void SetTecnicoID(int tecnicoid)
        {
            TecnicoID = tecnicoid;
        }
        public static int ValidarLogin()
        {
            int retorno = 0;
            //int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Validarusuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@correo", usuario));
                    cmd.Parameters.Add(new SqlParameter("@clave", clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;

                            IDUsuario = rdr.GetInt32(0);
                            nombre = rdr[1].ToString();
                            correo = rdr[2].ToString();
                            idrol = rdr.GetInt32(3);
                            rolename = rdr[4].ToString();
                        }
                        else
                        {
                            retorno = -1;
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;

        }

    }//fin clase
}//fin namespace