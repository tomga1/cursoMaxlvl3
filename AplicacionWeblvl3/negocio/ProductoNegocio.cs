using dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Dom_Producto> listar()
        {
            List<Dom_Producto> lista = new List<Dom_Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_producto, p.codigo, codigo_barra, nombre, p.descripcion, r.descripcion AS rubro_descripcion, stock,precio_compra, precio_venta, u.descripcion AS unidad_medida_descripcion, fecha_vencimiento, p.estado, p.fecha_registro, pro.razon_social AS razon_social, mar.descripcion_marca AS descripcion_marca, ubi.codigo_ubicacion AS ubicacion_codigo, p.url_imagen FROM productos p JOIN rubros r ON r.id_rubro = p.id_rubro JOIN unidades_medida u ON u.id_unidad_medida = p.id_unidad_medida JOIN proveedor pro ON pro.id_proveedor = p.id_proveedor JOIN marcas mar ON mar.id_marca = p.id_marca JOIN ubicaciones ubi ON ubi.id_ubicacion = p.id_ubicacion");


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Producto aux = new Dom_Producto();
                    aux.idProducto = (int)datos.Lector["id_producto"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.codigo_de_barra = (string)datos.Lector["codigo_barra"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.Rubro = new Dom_Rubro();
                    aux.Rubro.descripcion = (string)datos.Lector["rubro_descripcion"];
                    aux.stock = (int)datos.Lector["stock"];
                    aux.precio_venta = (decimal)datos.Lector["precio_venta"];
                    aux.UnidadMedida = new Dom_UnidadDeMedida();
                    aux.UnidadMedida.descripcion = (string)datos.Lector["unidad_medida_descripcion"];
                    aux.fecha_vencimiento = (DateTime)datos.Lector["fecha_vencimiento"];
                    aux.estado = (bool)datos.Lector["estado"];
                    aux.fecha_registro = (DateTime)datos.Lector["fecha_registro"];
                    aux.Proveedor = new Dom_Proveedor();
                    aux.Proveedor.razon_social = (string)datos.Lector["razon_social"];
                    aux.Marca = new Dom_Marca();
                    aux.Marca.descripcion = (string)datos.Lector["descripcion_marca"];
                    aux.Ubicacion = new Dom_Ubicaciones();
                    aux.Ubicacion.codigo = (string)datos.Lector["ubicacion_codigo"];
                    aux.UrlImagen = datos.Lector["url_imagen"] == DBNull.Value ? null : (string)datos.Lector["url_imagen"];




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


        public void agregar(Dom_Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into productos (codigo, codigo_barra, nombre, id_rubro, descripcion, stock, precio_venta, id_unidad_medida, fecha_vencimiento, estado, fecha_registro, id_proveedor, id_marca, id_ubicacion, url_imagen) values (@codigo, @codigo_barra, @nombre, @id_rubro, @descripcion, @stock, @precio_venta, @id_unidad_medida, @fecha_vencimiento, @estado, @fecha_registro, @id_proveedor, @id_marca, @id_ubicacion, @url_imagen)");

                datos.setearParametro("@codigo", nuevo.codigo.ToUpper());
                datos.setearParametro("@codigo_barra", nuevo.codigo_de_barra);
                datos.setearParametro("@nombre", nuevo.nombre.ToUpper());
                datos.setearParametro("@id_rubro", nuevo.Rubro.idRubro);
                datos.setearParametro("@descripcion", nuevo.descripcion.ToUpper());
                datos.setearParametro("@stock", nuevo.stock);
                datos.setearParametro("@precio_venta", nuevo.precio_venta);
                datos.setearParametro("@id_unidad_medida", nuevo.UnidadMedida.id_unidad_de_medida);
                datos.setearParametro("@fecha_vencimiento", nuevo.fecha_vencimiento);  
                datos.setearParametro("@estado", nuevo.estado);  
                datos.setearParametro("@fecha_registro", nuevo.fecha_registro);  
                datos.setearParametro("@id_proveedor", nuevo.Proveedor.idProveedor);
                datos.setearParametro("@id_marca", nuevo.Marca.idMarca);
                datos.setearParametro("@id_ubicacion", nuevo.Ubicacion.idUbicacion);
                datos.setearParametro("@url_imagen", nuevo.UrlImagen);




                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void modificar(Dom_Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update productos set codigo = @codigo, codigo_barra = @codigo_barra, nombre = @nombre, id_rubro = @idRubro, descripcion = @descripcion, precio_venta = @precio_venta, id_unidad_medida = @id_unidad_de_medida, fecha_vencimiento = @fecha_vencimiento, estado = @estado, id_proveedor = @idProveedor, id_marca = @id_marca where id_producto = @idProducto");
                datos.setearParametro("@codigo", producto.codigo.ToUpper());
                datos.setearParametro("@codigo_barra", producto.codigo_de_barra);
                datos.setearParametro("@nombre", producto.nombre.ToUpper());
                datos.setearParametro("@idRubro", producto.Rubro.idRubro);
                datos.setearParametro("@descripcion", producto.descripcion.ToUpper());
                datos.setearParametro("@precio_venta", producto.precio_venta);
                datos.setearParametro("@id_unidad_de_medida", producto.UnidadMedida.id_unidad_de_medida);
                datos.setearParametro("@fecha_vencimiento", producto.fecha_vencimiento);
                datos.setearParametro("@estado", producto.estado);
                datos.setearParametro("@idProveedor", producto.Proveedor.idProveedor);
                datos.setearParametro("@idProducto", producto.idProducto);
                datos.setearParametro("@id_marca", producto.Marca.idMarca);



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

        public void actualizarPrecioCompra(int idProducto, decimal nuevoPrecioCompra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE productos SET precio_compra = @precio_compra WHERE id_producto = @id_producto");
                datos.setearParametro("@precio_compra", nuevoPrecioCompra);
                datos.setearParametro("@id_producto", idProducto);

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

        public void actualizarPrecioVenta(int idProducto, decimal nuevoPrecioVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE productos SET precio_venta = @precio_venta WHERE id_producto = @id_producto");
                datos.setearParametro("@precio_venta", nuevoPrecioVenta);
                datos.setearParametro("@id_producto", idProducto);               

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

        public void actualizarStock(int idProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE productos SET stock = stock + @cantidad WHERE id_producto = @id_producto");
                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@id_producto", idProducto);

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
                datos.setearConsulta("DELETE productos where id_producto = @id_producto");
                datos.setearParametro("@id_producto", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dom_Producto> filtrar(string campo, string criterio, string filtro)
        {
            List<Dom_Producto> lista = new List<Dom_Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT id_producto, codigo, codigo_barra, nombre, p.descripcion, r.descripcion AS rubro_descripcion, stock,precio_compra, precio_venta, u.descripcion AS unidad_medida_descripcion, fecha_vencimiento, p.estado, fecha_registro, pro.razon_social AS razon_social, mar.descripcion_marca AS descripcion_marca FROM productos p JOIN rubros r ON r.id_rubro = p.id_rubro JOIN unidades_medida u ON u.id_unidad_medida = p.id_unidad_medida JOIN proveedor pro ON pro.id_proveedor = p.id_proveedor JOIN marcas mar ON mar.id_marca = p.id_marca and ";


                switch (campo)
                {
                    case "Codigo":
                        switch (criterio)
                        {
                            default:
                                consulta += "codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Codigo Barra":
                        switch (criterio)
                        {
                            default:
                                consulta += "codigo_barra like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            default:
                                consulta += "nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Rubro":
                        switch (criterio)
                        {
                            default:
                                consulta += "id_rubro like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Unidad Medida":
                        switch (criterio)
                        {
                            default:
                                consulta += "id_unidad_medida like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Proveedor":
                        switch (criterio)
                        {
                            default:
                                consulta += "id_proveedor like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            default:
                                consulta += "id_marca like '%" + filtro + "%'";
                                break;
                        }
                        break;

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Producto aux = new Dom_Producto();
                    aux.Rubro = new Dom_Rubro();

                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.codigo_de_barra = (string)datos.Lector["codigo_barra"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.Rubro = new Dom_Rubro();
                    aux.Rubro.descripcion = (string)datos.Lector["descripcion"];
                    aux.UnidadMedida = new Dom_UnidadDeMedida();
                    aux.UnidadMedida.descripcion = (string)datos.Lector["descripcion"];
                    aux.fecha_vencimiento = (DateTime)datos.Lector["fecha_vencimiento"];
                    aux.Proveedor = new Dom_Proveedor();
                    aux.Proveedor.razon_social = (string)datos.Lector["razon_social"];
                    aux.Marca = new Dom_Marca();
                    aux.Marca.descripcion = (string)datos.Lector["descripcion"];

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

