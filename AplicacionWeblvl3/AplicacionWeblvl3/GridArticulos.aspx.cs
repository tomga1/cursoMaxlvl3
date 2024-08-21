using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeblvl3
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                var listaArticulos = negocio.listar();
                Session.Add("listaArticulos", listaArticulos);
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.DataBind();

            }

        }
    }
}