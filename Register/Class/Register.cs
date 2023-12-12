using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto2_ProgramacionII.Sign_Up.Class
{
    public class Register
    {
        public string nombre { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public int idrol { get; set; }
        public Register(string Nombre, string Correo, string Clave, int IDrol)
        {
            nombre = Nombre;
            correo = Correo;
            clave = Clave;
            idrol = IDrol;
        }
        public Register(string Correo, string Clave, int IDrol)
        {
            correo = Correo;
            clave = Clave;
            idrol = IDrol;
        }
        public Register(string Clave, int IDrol)
        {
            clave = Clave;
            idrol = IDrol;
        }
        public Register(int IDrol)
        {
            idrol = IDrol;
        }
        public Register() { }

        public static int RegistrarUsuarioYRol(string nombre, string correo, string clave, int IDrol)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("RegistrarUsuarioYRol", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@clave", clave));
                    cmd.Parameters.Add(new SqlParameter("@idrol", IDrol));


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
        }// fin metdodo
    }//fin clase
}// fin namespace