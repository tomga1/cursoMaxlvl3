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
            if (Session["listaArticulos"] == null)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Session.Add("listaArticulos", negocio.listar());
            }

            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();


           

        }
    }
}