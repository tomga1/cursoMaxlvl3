using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeblvl3
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((dominio.Dom_Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "No tienes permiso para ingresar a esta pantalla. Necesitas nivel ADMINISTRADOR");
                Response.Redirect("Error.aspx", false);
            }

                if (!IsPostBack)
            {
                if (Session["listaArticulos"] == null)
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    Session.Add("listaArticulos", negocio.listar());
                }
            }
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltroAvanzado.Enabled = FiltroAvanzado;

            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();


            string mensaje = Request.QueryString["mensaje"];
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulos.aspx");
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Dom_Articulos> lista = (List<Dom_Articulos>)Session["listaArticulos"];
            List<Dom_Articulos> listaFiltrada = lista.FindAll(x => x.nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()) || x.codigo.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltroAvanzado.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            ddlCriterio.Items.Add("Contiene");
            ddlCriterio.Items.Add("Comienza");
            ddlCriterio.Items.Add("Termina");


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString());


                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}