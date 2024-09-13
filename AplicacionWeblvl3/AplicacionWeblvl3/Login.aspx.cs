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

            //Page.Validate();
            //if (!Page.IsValid)
            //{
            //    return;
            //}

            Dom_Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();  

            if(Validacion.ValidaTextoVacio(txtEmail) || Validacion.ValidaTextoVacio(txtPassword))
            {
                Session.Add("error", "Debes completar ambos campos...");
                Response.Redirect("Error.aspx", false);
            }
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
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);

            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx", false);
        }

        protected void btnOlvido_Click(object sender, EventArgs e)
        {

        }
    }
}