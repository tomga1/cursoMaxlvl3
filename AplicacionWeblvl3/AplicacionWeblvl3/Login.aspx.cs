using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio; 

namespace AplicacionWeblvl3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Dom_Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();  
            try
            {
                usuario = new Dom_Usuario(txtEmail.Text, txtPassword.Text, false);
                if (negocio.Loguear(usuario))   
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrectos! ");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);

            }
        }
    }
}