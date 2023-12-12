using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_ProgramacionII.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClassUsersAD objusuario = new ClassUsersAD(tclave.Text, tcorreo.Text);

            int resultadoValidacion = ClassUsersAD.ValidarLogin();

            if (resultadoValidacion > 0)
            {
                string rolename = ClassUsersAD.Getrolename();
                if (rolename == "admin")
                {
                    Response.Redirect("~/Menu/Inicio.aspx");
                }
                else if (rolename == "Tecnico")
                {
                    Response.Redirect("~/Menu/Inicio.aspx");
                }
            }
            else
            {
                alertas("Correo o contraseña incorrectos");
            }
        }//fin metodo 
    }//fin clase
}//fin namespace