using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.SqlServer.Server;
using negocio;

namespace AplicacionWeblvl3
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string ruta = Server.MapPath("./Images/");
                Dom_Usuario usuario = (Dom_Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(ruta + "perfil-"+usuario.idUsuario+".jpg");

                usuario.urlImagenPerfil = "perfil-"+usuario.idUsuario+".jpg";
                usuario.nombre = txtNombre.Text;
                usuario.apellido = txtApellido.Text;

                negocio.actualizar(usuario);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/"+ usuario.urlImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}