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
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, m.Id as MarcaId, m.descripcion as Marca, c.Id as CategoriaId, c.descripcion as Categoria, ImagenUrl, Precio FROM dbo.ARTICULOS a JOIN marcas m ON m.Id = a.IdMarca JOIN categorias c ON c.Id = a.IdCategoria");
                
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
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, m.Id as MarcaId, m.descripcion as Marca, c.Id as CategoriaId, c.descripcion as Categoria, ImagenUrl, Precio FROM dbo.ARTICULOS a JOIN marcas m ON m.Id = a.IdMarca JOIN categorias c ON c.Id = a.IdCategoria WHERE a.Id = @id");
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

        //        public List<Dom_Articulos> filtrar(string campo, string criterio, string filtro)
        //        {
        //            List<Dom_Articulos> lista = new List<Dom_Articulos>();
        //            AccesoDatos datos = new AccesoDatos();
        //            try
        //            {
        //                string consulta = "SELECT id_producto, codigo, codigo_barra, nombre, p.descripcion, r.descripcion AS rubro_descripcion, stock,precio_compra, precio_venta, u.descripcion AS unidad_medida_descripcion, fecha_vencimiento, p.estado, fecha_registro, pro.razon_social AS razon_social, mar.descripcion_marca AS descripcion_marca FROM productos p JOIN rubros r ON r.id_rubro = p.id_rubro JOIN unidades_medida u ON u.id_unidad_medida = p.id_unidad_medida JOIN proveedor pro ON pro.id_proveedor = p.id_proveedor JOIN marcas mar ON mar.id_marca = p.id_marca and ";


        //                switch (campo)
        //                {
        //                    case "Codigo":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "codigo like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;

        //                    case "Codigo Barra":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "codigo_barra like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;

        //                    case "Nombre":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "nombre like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;

        //                    case "Rubro":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "id_rubro like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;

        //                    case "Unidad Medida":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "id_unidad_medida like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;

        //                    case "Proveedor":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "id_proveedor like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;
        //                    case "Marca":
        //                        switch (criterio)
        //                        {
        //                            default:
        //                                consulta += "id_marca like '%" + filtro + "%'";
        //                                break;
        //                        }
        //                        break;

        //                }

        //                datos.setearConsulta(consulta);
        //                datos.ejecutarLectura();

        //                while (datos.Lector.Read())
        //                {
        //                    Dom_Articulos aux = new Dom_Articulos();
        //                    aux.Rubro = new Dom_Rubro();

        //                    aux.codigo = (string)datos.Lector["codigo"];
        //                    aux.codigo_de_barra = (string)datos.Lector["codigo_barra"];
        //                    aux.nombre = (string)datos.Lector["nombre"];
        //                    aux.descripcion = (string)datos.Lector["descripcion"];
        //                    aux.Rubro = new Dom_Rubro();
        //                    aux.Rubro.descripcion = (string)datos.Lector["descripcion"];
        //                    aux.UnidadMedida = new Dom_UnidadDeMedida();
        //                    aux.UnidadMedida.descripcion = (string)datos.Lector["descripcion"];
        //                    aux.fecha_vencimiento = (DateTime)datos.Lector["fecha_vencimiento"];
        //                    aux.Proveedor = new Dom_Proveedor();
        //                    aux.Proveedor.razon_social = (string)datos.Lector["razon_social"];
        //                    aux.Marca = new Dom_Marca();
        //                    aux.Marca.descripcion = (string)datos.Lector["descripcion"];

        //                    lista.Add(aux);
        //                }

        //                return lista;
        //            }
        //            catch (Exception ex)
        //            {

        //                throw ex;
        //            }


        //            throw new NotImplementedException();
        //        }
    }

}

