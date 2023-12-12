using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Proyecto2_ProgramacionII
{
    public partial class DetallesReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarReparacion();
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM DetallesReparacion"))
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

        protected void LlenarReparacion()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID, EquipoID  FROM Reparaciones", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Crear un nuevo DataTable para agregar el elemento "Clic" al inicio
                            DataTable dtModified = new DataTable();
                            dtModified.Columns.Add("ReparacionID");
                            dtModified.Columns.Add("EquipoID");

                            // Agregar el elemento "Clic" manualmente al inicio del nuevo DataTable
                            dtModified.Rows.Add("", "Clic ");

                            // Copiar los datos de la consulta SQL al nuevo DataTable
                            foreach (DataRow row in dt.Rows)
                            {
                                dtModified.ImportRow(row);
                            }

                            // Enlazar el DropDownList con el nuevo DataTable modificado
                            DropReparacion.DataSource = dtModified;
                            DropReparacion.DataTextField = "ReparacionID";
                            DropReparacion.DataValueField = "ReparacionID";
                            DropReparacion.DataBind();
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
            string fechaTexto = txtfechaI.Text;

            // Analizar la fecha en formato "dia/mes/año"
            if (DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                string hora = ddlHora.SelectedValue;

                // Combina la fecha y la hora en el formato deseado "yyyy-MM-dd HH:mm:ss"
                string fechaHoraSeleccionada = fecha.ToString("yyyy-MM-dd") + " " + hora;

                int resultado = Class.DetallesReparacion.Agregar(int.Parse(DropReparacion.Text), txtdes.Text, fechaHoraSeleccionada, DateTime.Parse(txtfechaF.Text));

                if (resultado > 0)
                {
                    alertas("Detalle ingresado con éxito");
                    DropReparacion.Text = string.Empty;
                    txtdes.Text = string.Empty;
                    txtfechaI.Text = string.Empty;
                    txtfechaF.Text = string.Empty;
                    LlenarGrid();
                }
                else
                {
                    alertas("Error al ingresar Detalle");
                }
            }
            else
            {
                // Manejar el escenario donde el usuario ingresó una fecha en un formato incorrecto
                alertas("Formato de fecha inválido. Por favor, ingrese la fecha en formato dd/MM/yyyy");
            }
        }

        protected void btnFechaInicio_Click(object sender, EventArgs e)
        {
            calFechaInicio.Visible = !calFechaInicio.Visible;
        }

        protected void calFechaInicio_SelectionChanged(object sender, EventArgs e)
        {
            txtfechaI.Text = calFechaInicio.SelectedDate.ToShortDateString(); // Actualizar el TextBox con la fecha seleccionada del calendario
            calFechaInicio.Visible = false; // Ocultar el calendario después de seleccionar una fecha
        }

        protected void btnBorrar(object sender, EventArgs e)
        {
            int resultado = Class.DetallesReparacion.Borrar(int.Parse(txtDID.Text));

            if (resultado > 0)
            {
                alertas("Detalle eliminado con exito");
                txtDID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar Detalle");

            }
        }

        protected void btnModificar(object sender, EventArgs e)
        {
            int resultado = Class.DetallesReparacion.Modificar(int.Parse(txtDID.Text), int.Parse(DropReparacion.Text), txtdes.Text, txtfechaI.Text, DateTime.Parse( txtfechaF.Text));
            if (resultado > 0)
            {
                alertas("Detalle modificado con exito");
                txtDID.Text = string.Empty;
                DropReparacion.Text = string.Empty;
                txtdes.Text = string.Empty;
                txtfechaI.Text = string.Empty;
                txtfechaF.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Detalle");

            }
        }

        protected void btnConsultar(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtDID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DetallesReparacion WHERE DetalleID ='" + codigo + "'"))


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