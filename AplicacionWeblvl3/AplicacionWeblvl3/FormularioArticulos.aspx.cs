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
                    ddlMarcas.DataValueField = "idMarca";
                    ddlMarcas.DataTextField = "descripcion";
                    ddlMarcas.DataBind();

                    ddlCategorias.DataSource = negocio.listarCategorias();
                    ddlCategorias.DataValueField = "idCategoria";
                    ddlCategorias.DataTextField = "descripcion";
                    ddlCategorias.DataBind();
                }

                if (Request.QueryString["id"] != null)
                {

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
            articulo.marca.idMarca = int.Parse(ddlMarcas.SelectedValue);
            articulo.categoria = new Dom_Categoria();
            articulo.categoria.idCategoria = int.Parse(ddlCategorias.SelectedValue);


            negocio.agregar(articulo);


            //((List<Dom_Articulos>)Session["listaArticulos"]).Add(articulo);
            List<Dom_Articulos> listaArticulosActualizada = negocio.listar();
            Session["listaArticulos"] = listaArticulosActualizada;

            Response.Redirect("GridArticulos.aspx");
        }

        protected void txtImg_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImg.Text; 
        }
    }
}