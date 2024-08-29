using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeblvl3
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {

        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            ConfirmaEliminacion = false;

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

                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    //ArticulosNegocio negocio = new ArticulosNegocio();
                    Dom_Articulos seleccionado = (negocio.listarConId(id))[0];

                    txtCodigo.Text = seleccionado.codigo.ToString();
                    txtNombre.Text = seleccionado.nombre.ToString();
                    txtPrecio.Text = seleccionado.precio_compra.ToString();
                    ddlMarcas.SelectedValue = seleccionado.marca.idMarca.ToString();
                    ddlCategorias.SelectedValue = seleccionado.categoria.idCategoria.ToString();
                    txtDescripcion.Text = seleccionado.descripcion.ToString();
                    txtImg.Text = seleccionado.UrlImagen.ToString();

                    txtImg_TextChanged(sender, e);

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
            ArticulosNegocio negocio = new ArticulosNegocio();


            articulo.codigo = txtCodigo.Text;
            articulo.nombre = txtNombre.Text;
            articulo.descripcion = txtDescripcion.Text;
            articulo.precio_compra = decimal.Parse(txtPrecio.Text);
            articulo.UrlImagen = txtImg.Text;
            articulo.marca = new Dom_Marca();
            articulo.marca.idMarca = int.Parse(ddlMarcas.SelectedValue);
            articulo.categoria = new Dom_Categoria();
            articulo.categoria.idCategoria = int.Parse(ddlCategorias.SelectedValue);


            if (Request.QueryString["Id"] != null)
            {
                articulo.idProducto = int.Parse(Request.QueryString["Id"]);
                negocio.modificar(articulo);
            }
            else
            {

                negocio.agregar(articulo);
            }


            //((List<Dom_Articulos>)Session["listaArticulos"]).Add(articulo);
            List<Dom_Articulos> listaArticulosActualizada = negocio.listar();
            Session["listaArticulos"] = listaArticulosActualizada;

            Response.Redirect("GridArticulos.aspx");
        }

        protected void txtImg_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImg.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true; 

        }



        protected void ConfirmaEliminar_Click(object sender, EventArgs e)
        {

            ArticulosNegocio negocio = new ArticulosNegocio();  
            string id = Request.QueryString["Id"] ?? string.Empty;

            try
            {

                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out  int idProducto))
                {
                    negocio.eliminar(idProducto);

                    List<Dom_Articulos> listaArticulosActualizada = negocio.listar();
                    Session["listaArticulos"] = listaArticulosActualizada;

                    Response.Redirect("GridArticulos.aspx?mensaje=Eliminado con éxito!");


                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex); 
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
                ArticulosNegocio negocio = new ArticulosNegocio();
                string id = Request.QueryString["Id"] ?? string.Empty;
            try
            {

                if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int idProducto))
                {
                    negocio.eliminarLogico(idProducto);

                    List<Dom_Articulos> listaArticulosActualizada = negocio.listar();
                    Session["listaArticulos"] = listaArticulosActualizada;

                    Response.Redirect("GridArticulos.aspx?mensaje=Eliminado con éxito!");
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex); 
            }
        }
    }
}