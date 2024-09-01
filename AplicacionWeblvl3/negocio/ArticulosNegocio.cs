using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticulosNegocio
    {
        public List<Dom_Articulos> listar()
        {
            List<Dom_Articulos> lista = new List<Dom_Articulos>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, m.Id as MarcaId, m.descripcion as Marca, c.Id as CategoriaId, c.descripcion as Categoria, ImagenUrl, Precio, a.Activo FROM dbo.ARTICULOS a JOIN marcas m ON m.Id = a.IdMarca JOIN categorias c ON c.Id = a.IdCategoria");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Articulos aux = new Dom_Articulos();
                    aux.idProducto = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    aux.marca = new Dom_Marca();
                    aux.marca.idMarca = (int)datos.Lector["MarcaId"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];

                    aux.categoria = new Dom_Categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["CategoriaId"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];

                    aux.UrlImagen = datos.Lector["ImagenUrl"] == DBNull.Value ? null : (string)datos.Lector["ImagenUrl"];
                    aux.precio_compra = (decimal)datos.Lector["Precio"];
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());


                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public List<Dom_Articulos> listarActivos()
        {
            List<Dom_Articulos> lista = new List<Dom_Articulos>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, m.Id as MarcaId, m.descripcion as Marca, c.Id as CategoriaId, c.descripcion as Categoria, ImagenUrl, Precio, a.Activo FROM dbo.ARTICULOS a JOIN marcas m ON m.Id = a.IdMarca JOIN categorias c ON c.Id = a.IdCategoria WHERE Activo = 1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Articulos aux = new Dom_Articulos();
                    aux.idProducto = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    aux.marca = new Dom_Marca();
                    aux.marca.idMarca = (int)datos.Lector["MarcaId"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];

                    aux.categoria = new Dom_Categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["CategoriaId"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];

                    aux.UrlImagen = datos.Lector["ImagenUrl"] == DBNull.Value ? null : (string)datos.Lector["ImagenUrl"];
                    aux.precio_compra = (decimal)datos.Lector["Precio"];
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());


                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


        public List<Dom_Articulos> listarConId(string id)
        {
            List<Dom_Articulos> lista = new List<Dom_Articulos>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, m.Id as MarcaId, m.descripcion as Marca, c.Id as CategoriaId, c.descripcion as Categoria, ImagenUrl, Precio, a.Activo FROM dbo.ARTICULOS a JOIN marcas m ON m.Id = a.IdMarca JOIN categorias c ON c.Id = a.IdCategoria WHERE a.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Articulos aux = new Dom_Articulos();
                    aux.idProducto = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    aux.marca = new Dom_Marca();
                    aux.marca.idMarca = (int)datos.Lector["MarcaId"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];

                    aux.categoria = new Dom_Categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["CategoriaId"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = datos.Lector["ImagenUrl"] == DBNull.Value ? null : (string)datos.Lector["ImagenUrl"];
                    aux.precio_compra = (decimal)datos.Lector["Precio"];

                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());


                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }



        public List<Dom_Marca> listarMarcas()
        {
            List<Dom_Marca> lista = new List<Dom_Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from MARCAS");


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Marca marca = new Dom_Marca();
                    marca.idMarca = (int)datos.Lector["Id"];
                    marca.descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(marca);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public List<Dom_Categoria> listarCategorias()
        {
            List<Dom_Categoria> lista = new List<Dom_Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from CATEGORIAS");


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Categoria categoria = new Dom_Categoria();
                    categoria.idCategoria = (int)datos.Lector["Id"];
                    categoria.descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(categoria);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }




        public void agregar(Dom_Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @ImagenUrl, @Precio)");

                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@IdMarca", nuevo.marca.idMarca);
                datos.setearParametro("@IdCategoria", nuevo.categoria.idCategoria);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.precio_compra);





                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void modificar(Dom_Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @UrlImagen, Precio = @precio_compra where Id = @idProducto");

                datos.setearParametro("@idProducto", articulo.idProducto);
                datos.setearParametro("@codigo", articulo.codigo.ToUpper());
                datos.setearParametro("@nombre", articulo.nombre.ToUpper());
                datos.setearParametro("@descripcion", articulo.descripcion.ToUpper());
                datos.setearParametro("@idMarca", articulo.marca.idMarca);
                datos.setearParametro("@idCategoria", articulo.categoria.idCategoria);
                datos.setearParametro("@UrlImagen", articulo.UrlImagen);
                datos.setearParametro("@precio_compra", articulo.precio_compra);




                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE articulos where Id = @idProducto");
                datos.setearParametro("@idProducto", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update articulos set Activo = @activo where Id = @idProducto");
                datos.setearParametro("@idProducto", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //        public void actualizarPrecioCompra(int idProducto, decimal nuevoPrecioCompra)
        //        {
        //            AccesoDatos datos = new AccesoDatos();

        //            try
        //            {
        //                datos.setearConsulta("UPDATE productos SET precio_compra = @precio_compra WHERE id_producto = @id_producto");
        //                datos.setearParametro("@precio_compra", nuevoPrecioCompra);
        //                datos.setearParametro("@id_producto", idProducto);

        //                datos.ejecutarAccion();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                datos.cerrarConexion();
        //            }
        //        }

        //        public void actualizarPrecioVenta(int idProducto, decimal nuevoPrecioVenta)
        //        {
        //            AccesoDatos datos = new AccesoDatos();

        //            try
        //            {
        //                datos.setearConsulta("UPDATE productos SET precio_venta = @precio_venta WHERE id_producto = @id_producto");
        //                datos.setearParametro("@precio_venta", nuevoPrecioVenta);
        //                datos.setearParametro("@id_producto", idProducto);               

        //                datos.ejecutarAccion();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                datos.cerrarConexion();
        //            }
        //        }

        //        public void actualizarStock(int idProducto, int cantidad)
        //        {
        //            AccesoDatos datos = new AccesoDatos();

        //            try
        //            {
        //                datos.setearConsulta("UPDATE productos SET stock = stock + @cantidad WHERE id_producto = @id_producto");
        //                datos.setearParametro("@cantidad", cantidad);
        //                datos.setearParametro("@id_producto", idProducto);

        //                datos.ejecutarAccion();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                datos.cerrarConexion();
        //            }
        //        }



        public List<Dom_Articulos> filtrar(string campo, string criterio, string filtro, string estado)
        {
            List<Dom_Articulos> lista = new List<Dom_Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion AS MarcaDescripcion, c.Descripcion as CategoriaDescripcion, a.ImagenUrl, a.Precio, a.Activo FROM articulos a JOIN MARCAS m ON m.Id = a.IdMarca JOIN CATEGORIAS c ON c.Id = a.IdCategoria and ";


                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "m.Marca like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "m.Marca like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "m.Marca like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "c.Categoria like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "c.Categoria like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "c.Categoria like '%" + filtro + "%'";
                            break;
                    }
                }

                if(estado == "Activo")
                {
                    consulta += " and a.Activo = 1 ";
                }
                else if(estado == "Inactivo")
                {
                    consulta += " and a.Activo = 0";
                }

                    datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Articulos aux = new Dom_Articulos();

                    aux.idProducto = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.marca = new Dom_Marca();
                    aux.marca.descripcion = (string)datos.Lector["MarcaDescripcion"];
                    aux.categoria = new Dom_Categoria();
                    aux.categoria.descripcion = (string)datos.Lector["CategoriaDescripcion"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.precio_compra = (decimal)datos.Lector["Precio"];
                    

                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());
                    
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


            throw new NotImplementedException();
        }
    }

}

