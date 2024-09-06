using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AplicacionWeblvl3
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            imgAvatar.ImageUrl = "https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk=";

            if (!(Page is Login || Page is Default))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Dom_Usuario usuario = (Dom_Usuario)Session["usuario"];
                    lblUser.Text = usuario.email;
                    imgAvatar.ImageUrl = usuario.urlImagenPerfil; 
                    if (!string.IsNullOrEmpty(usuario.urlImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + usuario.urlImagenPerfil;
                }
            }




            //if (!(this.Page is Login) && !EsRegistrando() )
            //if (!Seguridad.sesionActiva(Session["usuario"]))
            //{
            //    Response.Redirect("Login.aspx", false);
            //}

            //if (Seguridad.sesionActiva(Session["usuario"]))
            //{
            //    imgAvatar.ImageUrl = "~/Images/" + ((Dom_Usuario)Session["usuario"]).urlImagenPerfil;
            //}
            //else
            //    imgAvatar.ImageUrl = "https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk=";
        }


        private bool EsRegistrando()
        {
            string url = Request.Url.AbsolutePath.ToLower();

            bool paginaRegistro = url.Contains("registrar.aspx");

            bool BtnRegistrando = Request.Form["btnRegistrar"] != null;

            return paginaRegistro || BtnRegistrando;
        }

        protected void botonSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false); 
        } 
    }
}