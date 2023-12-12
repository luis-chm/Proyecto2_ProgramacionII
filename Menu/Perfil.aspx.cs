using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_ProgramacionII.Menu
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lCodigo.Text = ClassUsersAD.GetIDUsuario().ToString();
            lNombre.Text = ClassUsersAD.Getnombre();
            lCorreo.Text = ClassUsersAD.Getcorreo();
            lRol.Text = ClassUsersAD.Getrolename();
        }
    }
}