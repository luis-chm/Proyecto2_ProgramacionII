using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_ProgramacionII.Reset_Password
{
    public partial class ResetPassword : System.Web.UI.Page
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
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            Class.ResetPassword objemail = new Class.ResetPassword(tEmail.Text);
            if (Class.ResetPassword.ValidarEmailAD() > 0)
            {
                string tNewPasswordValue = tNewPassword.Text;
                string tre_NewPasswordValue = tre_NewPassword.Text;

                if (tNewPasswordValue != tre_NewPasswordValue)
                {
                    tNewPassword.Text = string.Empty;
                    tre_NewPassword.Text = string.Empty;
                    alertas("¡Error! Las contraseñas no coinciden. Por favor verificarlas.");
                    return;
                }
                int resultado = Class.ResetPassword2.ModificarPasswordUserAD(tEmail.Text, tNewPassword.Text);
                if (resultado > 0)
                {
                    alertas("Se ha cambiado la contraseña con éxito.");
                    tEmail.Text = string.Empty;
                    tNewPassword.Text = string.Empty;
                    tre_NewPassword.Text = string.Empty;
                }
                else
                {
                    alertas("Error, comuniquese con el administrador del sistema.");
                }
            }
            else
            {
                tEmail.Text = string.Empty;
                tNewPassword.Text = string.Empty;
                tre_NewPassword.Text = string.Empty;
                alertas("Correo no se encuentra en el sistema.");
            }
        }
    }//fin clase
}//fin namespace