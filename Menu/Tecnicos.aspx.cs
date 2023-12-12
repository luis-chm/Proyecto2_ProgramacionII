using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;

namespace Proyecto2_ProgramacionII
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
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
                using (SqlCommand cmd = new SqlCommand("SELECT TecnicoID AS 'Codigo de Tecnico', Nombre, Especialidad FROM Tecnicos"))
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
        protected void btnAgregarTec(object sender, EventArgs e)
        {
            int resultado = Class.Tecnicos.AgregarTec(txtNombre.Text, txtEspecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico ingresado con exito");
                txtNombre.Text = string.Empty;
                txtEspecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Tecnico");

            }
        }

        protected void btnBorrarTec(object sender, EventArgs e)
        {
            int resultado = Class.Tecnicos.BorrarTec(int.Parse(txtTecnicoID.Text));

            if (resultado > 0)
            {
                alertas("El Tecnico ha sido eliminado con exito");
                txtTecnicoID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar Tecnico");

            }
        }

        protected void btnModificarTec(object sender, EventArgs e)
        {
            int resultado = Class.Tecnicos.ModificarTec(int.Parse(txtTecnicoID.Text), txtNombre.Text, txtEspecialidad.Text);
            if (resultado > 0)
            {
                alertas("El Tecnico se ha modificado con exito");
                txtTecnicoID.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtEspecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Tecnico");

            }
        }

        protected void btnConsultarTec(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtTecnicoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID ='" + codigo + "'"))


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
        }//FIN METODO CONSULT
    }//FIN CLASE
}// FIN NAMESPACE