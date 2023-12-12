using Proyecto2_ProgramacionII.Menu.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Proyecto2_ProgramacionII.Reset_Password.Class
{
    public class ResetPassword
    {
        private static string correo;
        public ResetPassword(string Correo)
        {
            correo = Correo;
        }
        public static string Getcorreo()
        {
            return correo;

        }
        public void Setcorreo(string Correo)
        {
            correo = Correo;
        }
        public static int ValidarEmailAD()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ValidarUserEmailAD", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
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
        }// validar email
    }//fin clase
    //INCIIO SEGUNDA CLASE
    public class ResetPassword2
    {
        public string correo { get; set; }
        public string clave { get; set; }

        public ResetPassword2(string Correo, string Clave)
        {
            correo = Correo;
            clave = Clave;
        }
        public ResetPassword2(string Clave)
        {
            clave = Clave;
        }
        public static int ModificarPasswordUserAD(string Correo, string Clave)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarPasswordUserAD", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@clave", Clave));

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
    }// fion clase 2 reset
}//fin namespace