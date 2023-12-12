using Proyecto2_ProgramacionII.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2_ProgramacionII.Menu
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = ClassUsersAD.Getnombre();
            // Obtener el rol del usuario
            string rolename = ClassUsersAD.Getrolename();

            // Ocultar o mostrar elementos del menú según el rol
            if (rolename == "admin")
            {
                // El usuario es un administrador, todos los elementos son visibles
                // No es necesario hacer cambios en la visibilidad
            }
            else if (rolename == "Tecnico")
            {
                // El usuario es un técnico, ocultar algunos elementos
                OcultarElementosParaTecnico();
            }

        }//fin metodo 
        private void OcultarElementosParaTecnico()
        {
            // Ocultar elementos que no son necesarios para técnicos
            // Puedes ajustar esto según tus necesidades
            liTecnicos.Visible = false;
            liUsuarios.Visible = false;
            liEquipos.Visible = false;
        }
    }
}