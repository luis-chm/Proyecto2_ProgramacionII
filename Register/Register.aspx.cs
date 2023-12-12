using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_ProgramacionII.Sign_Up
{
    public partial class Register : System.Web.UI.Page
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
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int CodigoRol = 0;

            if (rbAdmin.Checked)
            {
                //Si el usuario selecciona "Admin" se le asigna código #1
                CodigoRol = 1;
            }
            else if (rbTecnico.Checked)
            {
                //Si el usuario selecciona "Técnico" se le asigna código #2 
                CodigoRol = 2;
            }
            //validar contraseñas
            string tPasswordValue = tpassword.Text;
            string tre_PasswordValue = tre_password.Text;

            if (tPasswordValue != tre_PasswordValue)
            {
                tNombre.Text = string.Empty;
                tEmail.Text = string.Empty;
                tpassword.Text = string.Empty;
                tre_password.Text = string.Empty;
                alertas("¡Error! Las contraseñas no coinciden. Por favor verificarlas.");
                return;
            }
            int resultado = Class.Register.RegistrarUsuarioYRol(tNombre.Text, tEmail.Text, tpassword.Text, CodigoRol);
            if (resultado > 0)
            {
                tNombre.Text = string.Empty;
                tEmail.Text = string.Empty;
                tpassword.Text = string.Empty;
                alertas("Se ha registrado su cuenta con éxito");
            }
            else
            {
                tNombre.Text = string.Empty;
                tEmail.Text = string.Empty;
                tpassword.Text = string.Empty;
                alertas("¡Error! Seleccione un rol.");
            }
        }
    }//fin clase
}//fin namespace