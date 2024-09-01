using dominio;
using negocio;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeblvl3
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Dom_Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            ListaArticulos = negocio.listarActivos();

            repRepetidor.DataSource = ListaArticulos;
            repRepetidor.DataBind();    
        }
    }
}