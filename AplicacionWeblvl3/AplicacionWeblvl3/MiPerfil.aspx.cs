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
            try
            {

                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Dom_Usuario usuario = (Dom_Usuario)Session["usuario"];

                        txtEmail.Text = usuario.email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.nombre;
                        txtApellido.Text = usuario.apellido;
                        if (!string.IsNullOrEmpty(usuario.urlImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.urlImagenPerfil;
                        txtFecha.Text = usuario.fecha_nacimiento.HasValue
                            ? usuario.fecha_nacimiento.Value.ToString("yyyy-MM-dd")
                            : string.Empty;
                        //imgNuevoPerfil = usuario.urlImagenPerfil;

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }


        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();
                Dom_Usuario usuario = (Dom_Usuario)Session["usuario"];

                if (txtImagen.PostedFile.FileName != "")
                {

                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.idUsuario + ".jpg");
                    usuario.urlImagenPerfil = "perfil-" + usuario.idUsuario + ".jpg";
                }

                usuario.nombre = txtNombre.Text;
                usuario.apellido = txtApellido.Text;
                usuario.fecha_nacimiento = DateTime.Parse(txtFecha.Text);

                negocio.actualizar(usuario);



                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + usuario.urlImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}