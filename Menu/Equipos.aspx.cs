using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Timers;
using System.Security.Claims;

namespace Proyecto2_ProgramacionII
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarUsuarios();
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
                using (SqlCommand cmd = new SqlCommand("SELECT EquipoID AS 'Codigo de Equipo', TipoEquipo AS 'Tipo de Equipo', Modelo, UsuarioID AS ' Codigo de Usuario'\r\nFROM Equipos;"))
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
        // Para de DropDownList Usuarios


        protected void LlenarUsuarios()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT UsuarioID, Nombre FROM Usuarios", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Crear un nuevo DataTable para agregar el elemento "Clic" al inicio
                            DataTable dtModified = new DataTable();
                            dtModified.Columns.Add("UsuarioID");
                            dtModified.Columns.Add("Nombre");

                            // Agregar el elemento "Clic" manualmente al inicio del nuevo DataTable
                            dtModified.Rows.Add("", "Clic ");

                            // Copiar los datos de la consulta SQL al nuevo DataTable
                            foreach (DataRow row in dt.Rows)
                            {
                                dtModified.ImportRow(row);
                            }

                            // Enlazar el DropDownList con el nuevo DataTable modificado
                            DropUsuarios.DataSource = dtModified;
                            DropUsuarios.DataTextField = "Nombre";
                            DropUsuarios.DataValueField = "UsuarioID";
                            DropUsuarios.DataBind();
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
            int resultado = Class.Equipos.Agregar(txtTipoEquipo.Text, txtModelo.Text, int.Parse(DropUsuarios.Text));

            if (resultado > 0)
            {
                alertas("Equipo ingresado con exito");
                txtTipoEquipo.Text = string.Empty;
                txtModelo.Text = string.Empty;
                DropUsuarios.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Equipo");

            }
        }

        protected void btnBorrar(object sender, EventArgs e)
        {
            int resultado = Class.Equipos.Borrar(int.Parse(txtEquipoID.Text));

            if (resultado > 0)
            {
                alertas("El Equipo ha sido eliminado con exito");
                txtEquipoID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar Equipo");

            }
        }

        protected void btnModificar(object sender, EventArgs e)
        {
            int resultado = Class.Equipos.Modificar(int.Parse(txtEquipoID.Text), txtTipoEquipo.Text, txtModelo.Text, int.Parse(DropUsuarios.Text));
            if (resultado > 0)
            {
                alertas("Equipo modificado con exito");
                txtEquipoID.Text = string.Empty;
                txtTipoEquipo.Text = string.Empty;
                txtModelo.Text = string.Empty;
                DropUsuarios.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar Equipo");

            }
        }

        protected void btnConsultar(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtEquipoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EQUIPOS WHERE EquipoID ='" + codigo + "'"))


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
}// FIN NAMESPACEusing System;

