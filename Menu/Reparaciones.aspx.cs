using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_ProgramacionII
{
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarEquipos();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID AS 'Codigo de Reparacion', EquipoID AS 'Codigo de Equipo', FechaSolicitud AS 'Fecha de Solicitud', Estado\r\nFROM Reparaciones;"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.AutoGenerateColumns = true; // Permitir que las columnas se generen automáticamente
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }

                }
            }
        }


        protected void LlenarEquipos()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT EquipoID, TipoEquipo, Modelo FROM Equipos", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Crear un nuevo DataTable para agregar el elemento "Clic" al inicio
                            DataTable dtModified = new DataTable();
                            dtModified.Columns.Add("EquipoID");
                            dtModified.Columns.Add("TipoYModelo", typeof(string)); // Columna combinada

                            // Agregar el elemento "Clic" manualmente al inicio del nuevo DataTable
                            dtModified.Rows.Add("", "Clic");

                            // Llenar el DataTable con datos combinados de TipoEquipo y Modelo
                            foreach (DataRow row in dt.Rows)
                            {
                                string EquipoID = row["EquipoID"].ToString();
                                string tipoEquipo = row["TipoEquipo"].ToString();
                                string modelo = row["Modelo"].ToString();
                                string tipoYModelo = $"Equipo Id {EquipoID}  -  Tipo:{tipoEquipo}  -  Modelo: {modelo}"; // Combinar los valores de TipoEquipo y Modelo
                                dtModified.Rows.Add(row["EquipoID"], tipoYModelo);
                            }

                            // Enlazar el DropDownList con el nuevo DataTable modificado y la nueva columna combinada
                            DropEquipos.DataSource = dtModified;
                            DropEquipos.DataTextField = "TipoYModelo"; // Usar la nueva columna combinada
                            DropEquipos.DataValueField = "EquipoID";
                            DropEquipos.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones si ocurre algún error al poblar el DropDownList
            }
        }



        protected void btnAgregar(object sender, EventArgs e)
        {
            string estadoSeleccionado = Request.Form["estado"]; // Obtener el valor seleccionado de los radio buttons

            if (!string.IsNullOrEmpty(estadoSeleccionado))
            {
                DateTime fechaHoraActual = DateTime.Now; // Obtiene la fecha y hora actual del sistema

                int resultado = Class.Reparaciones.Agregar(int.Parse(DropEquipos.Text), fechaHoraActual.ToString(), estadoSeleccionado);

                if (resultado > 0)
                {
                    alertas("Reparacion ingresada con exito");
                    DropEquipos.Text = string.Empty;
                    //txtfecha.Text = string.Empty;
                    //DropEstado.Text = string.Empty;
                    LlenarGrid();
                }
                else
                {
                    alertas("Error al ingresar Reparacion");
                }
            }
            else
            {
                // Mensaje de alerta para indicar que no se seleccionó ninguna opción
            }
        }

        protected void btnBorrar(object sender, EventArgs e)
        {
            int resultado = Class.Reparaciones.Borrar(int.Parse(txtRID.Text));

            if (resultado > 0)
            {
                alertas("eparacion eliminado con exito");
                txtRID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar Reparacion");

            }
        }

        protected void btnModificar(object sender, EventArgs e)
        {
            string estadoSeleccionado = Request.Form["estado"]; // Obtener el valor seleccionado de los radio buttons

            if (!string.IsNullOrEmpty(estadoSeleccionado))
            {
                DateTime fechaHoraActual = DateTime.Now; // Obtiene la fecha y hora actual del sistema
                int resultado = Class.Reparaciones.Modificar(int.Parse(txtRID.Text), int.Parse(DropEquipos.Text), fechaHoraActual.ToString(), estadoSeleccionado);
                if (resultado > 0)
                {
                    alertas("Reparacion modificado con exito");
                    txtRID.Text = string.Empty;
                    DropEquipos.Text = string.Empty;
                    //txtfecha.Text = string.Empty;
                    //DropEstado.Text = string.Empty;
                    LlenarGrid();
                }
                else
                {
                    alertas("Error al ingresar Reparacion");
                }
            }
            else
            {
                // Mensaje de alerta para indicar que no se seleccionó ninguna opción
            }
        }

        protected void btnConsultar(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtRID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Reparaciones WHERE ReparacionID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }
            }
        }
    }
}