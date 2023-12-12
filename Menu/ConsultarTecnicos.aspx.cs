using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace Proyecto2_ProgramacionII.Menu
{
    public partial class ConsultarTecnicos : System.Web.UI.Page
    {
        //protected int idtecnico;

        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();

            // Obtener el rol del usuario
            string rolename = ClassUsersAD.Getrolename();

            // Ocultar o mostrar botones según el rol
            if (rolename == "Tecnico")
            {
                // El usuario es un técnico, ocultar algunos botones
                miContenedor.Visible = false;
            }
            // Obtener el rol del usuario
            /*string rolename = ClassUsersAD.Getrolename();

             if (rolename == "admin")
             {

             }
             else if (rolename == "Tecnico")
             {
                 // Verificar si la solicitud de número está presente en la URL
                 if (!IsPostBack && Request.QueryString["idtecnico"] == null)
                 {
                     // Si no se ha proporcionado un número, mostrar el cuadro de diálogo
                     string script = "var idtecnico = prompt('Ingrese el ID del técnico:'); if(idtecnico !== null) { window.location.href = 'ConsultarTecnicos.aspx?idtecnico=' + idtecnico; }";
                     ClientScript.RegisterStartupScript(this.GetType(), "ShowDialogScript", script, true);
                 }
                 else
                 {
                     // El número se ha proporcionado, conviértelo a int y guárdalo en la variable de clase
                     if (int.TryParse(Request.QueryString["idtecnico"], out idtecnico))
                     {

                     }
                 }
             }*/
            LlenarGrid();
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
            string rol = ClassUsersAD.Getrolename();
            int idtecnico = 1;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("ConsultarTecnicos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ROl", rol));
                cmd.Parameters.Add(new SqlParameter("@TID", idtecnico));

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // Refrescar los datos
                    }
                }
            }
        }
        protected void btnConsultarTec(object sender, EventArgs e)
        {
            string rol = ClassUsersAD.Getrolename();
            int idtecnico = int.Parse(txtTecnicoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("ConsultarTecnicoEspecifico", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ROl", rol));
                cmd.Parameters.Add(new SqlParameter("@TID", idtecnico));

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // Refrescar los datos
                    }
                }
            }
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu/ConsultarTecnicos.aspx");
        }
    }//fin clase
}//fin namespace