using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto2_ProgramacionII.Menu.Class
{
    public class ConsultarTecnicos
    {
        public int TecnicoID { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public ConsultarTecnicos(int id, string nombre, string especialidad)
        {
            TecnicoID = id;
            Nombre = nombre;
            Especialidad = especialidad;
        }
        public ConsultarTecnicos(string nombre, string especialidad)
        {
            Nombre = nombre;
            Especialidad = especialidad;
        }
        public ConsultarTecnicos(string especialidad)
        {
            Especialidad = especialidad;
        }

        public ConsultarTecnicos() { }

        public static List<ConsultarTecnicos> consultaFiltroTec(int tecnicoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<ConsultarTecnicos> consultartecnicos = new List<ConsultarTecnicos>();
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
                            ConsultarTecnicos consultarTecnico = new ConsultarTecnicos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));  // instancia
                            consultartecnicos.Add(consultarTecnico);

                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return consultartecnicos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return consultartecnicos;
        }
    }//fin clase
}