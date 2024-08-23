using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeblvl3
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        ArticulosNegocio negocio = new ArticulosNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlMarcas.DataSource = negocio.listarMarcas();
                    ddlMarcas.DataBind();

                    ddlCategorias.DataSource = negocio.listarCategorias();
                    ddlCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Dom_Articulos articulo = new Dom_Articulos();
            articulo.codigo = txtCodigo.Text;
            articulo.nombre = txtNombre.Text;
            articulo.descripcion = txtDescripcion.Text;
            articulo.precio_compra = decimal.Parse(txtPrecio.Text);
            articulo.UrlImagen = txtImg.Text;
            articulo.marca = new Dom_Marca();
            articulo.categoria = new Dom_Categoria();
            articulo.marca.descripcion = ddlMarcas.SelectedValue;
            articulo.categoria.descripcion = ddlCategorias.SelectedValue;


            ((List<Dom_Articulos>)Session["listaArticulos"]).Add(articulo);

            Response.Redirect("GridArticulos.aspx");
        }
    }
}