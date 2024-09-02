using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AplicacionWeblvl3
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(this.Page is Login) && !EsRegistrando() )
            if (!Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Login.aspx", false);
            } 
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