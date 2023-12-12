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
    public partial class Usuarios : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT UsuarioID AS 'Codigo Usuario', Nombre AS 'Nombre del Usuario', Correo AS 'Dirección de Correo', Telefono AS 'Número de Teléfono'\r\nFROM Usuarios;"))
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
        protected void btnAgregarUser(object sender, EventArgs e)
        {
            int resultado = Class.Usuarios.AgregarUser(txtNombre.Text, txtCorreo.Text, txtTelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario ingresado con exito");
                txtNombre.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Usuario");

            }
        }

        protected void btnBorrarUser(object sender, EventArgs e)
        {
            int resultado = Class.Usuarios.BorraruUser(int.Parse(txtUsuarioID.Text));

            if (resultado > 0)
            {
                alertas("El Usuario ha sido eliminado con exito");
                txtUsuarioID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar usuario");

            }
        }

        protected void btnModificarUser(object sender, EventArgs e)
        {
            int resultado = Class.Usuarios.ModificarUser(int.Parse(txtUsuarioID.Text), txtNombre.Text, txtCorreo.Text, txtTelefono.Text);
            if (resultado > 0)
            {
                alertas("El Usuario se ha modificado con exito");
                txtUsuarioID.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Usuario");

            }
        }

        protected void btnConsultarUser(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtUsuarioID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioID ='" + codigo + "'"))


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