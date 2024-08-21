using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class IngresosNegocio
    {

        //public List<Dom_Producto> listar()
        //{
        //    List<Dom_Producto> lista = new List<Dom_Producto>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("SELECT id_producto, codigo, codigo_barra, nombre,p.descripcion,r.descripcion Rubro, stock, precio_compra, precio_venta, u.descripcion Umedida, fecha_vencimiento, p.estado,fecha_registro, pro.razon_social Proveedor, mar.descripcion_marca Marca FROM productos p join rubros r on  r.id_rubro = p.id_rubro join unidades_medida u on u.id_unidad_medida = p.id_unidad_medida join proveedor pro on pro.id_proveedor = p.id_proveedor join marcas mar on mar.id_marca = p.id_marca ;\r\n");
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            Dom_Producto aux = new Dom_Producto();

        //            aux.idProducto = (int)datos.Lector["id_producto"];
        //            aux.codigo = (string)datos.Lector["codigo"];
        //            aux.codigo_de_barra = (string)datos.Lector["codigo_barra"];
        //            aux.nombre = (string)datos.Lector["nombre"];
        //            aux.descripcion = (string)datos.Lector["descripcion"];
        //            aux.Rubro = new Dom_Rubro();
        //            aux.Rubro.idRubro = (int)datos.Lector["id_rubro"];
        //            aux.Rubro.descripcion = (string)datos.Lector["rubro_descripcion"];
        //            aux.descripcion = (string)datos.Lector["descripcion"];
        //            aux.stock = (int)datos.Lector["stock"];
        //            aux.precio_venta = (decimal)datos.Lector["precio_venta"];
        //            aux.UnidadMedida = new Dom_UnidadDeMedida();
        //            aux.UnidadMedida.id_unidad_de_medida = (int)datos.Lector["id_unidad_medida"];
        //            aux.UnidadMedida.descripcion = (string)datos.Lector["unidad_medida_descripcion"];
        //            aux.fecha_vencimiento = (DateTime)datos.Lector["fecha_vencimiento"];
        //            aux.estado = (bool)datos.Lector["estado"];
        //            aux.fecha_registro = (DateTime)datos.Lector["fecha_registro"];
        //            aux.Proveedor = new Dom_Proveedor();
        //            aux.Proveedor.idProveedor = (int)datos.Lector["id_proveedor"];
        //            aux.Proveedor.razon_social = (string)datos.Lector["razon_social"];
        //            aux.Marca = new Dom_Marca();
        //            aux.Marca.idMarca = (int)datos.Lector["id_marca"];
        //            aux.Marca.descripcion = (string)datos.Lector["descripcion_marca"];


        //            lista.Add(aux);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("Error al listar productos: " + ex.Message);
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //    return lista;
        //}

        public void agregar(IngresoCab nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ingreso_cab ( id_usuario, id_proveedor, numero_remito, monto_total, fecha_registro, observaciones) " + "VALUES (@id_usuario, @id_proveedor, @numero_remito, @monto_total, @fecha_registro, @observaciones); " + "SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@id_usuario", nuevo.oUsuario.idUsuario);
                datos.setearParametro("@id_proveedor", nuevo.Proveedor.idProveedor);
                datos.setearParametro("@numero_remito", nuevo.numeroRemito);
                datos.setearParametro("@monto_total", nuevo.montoTotal);
                datos.setearParametro("@fecha_registro", nuevo.fecha_registro);
                datos.setearParametro("@observaciones", nuevo.observaciones);


                int idIngresoCab = datos.ejecutarAccionEscalar();

                foreach (IngresoDet detalle in nuevo.oDetalleIngreso)
                {
                    
                    datos.setearConsulta("INSERT INTO ingreso_det (id_producto, id_ingreso_cab, precio_compra, precio_venta, cantidad) " +
                                 "VALUES (@id_producto, @id_ingreso_cab, @precioCompra, @precioVenta, @cantidad)");

                    datos.limpiarParametros();
                    datos.setearParametro("@id_producto", detalle.idProducto);
                    datos.setearParametro("@id_ingreso_cab", idIngresoCab);
                    datos.setearParametro("@precioCompra", detalle.precioCompra);
                    datos.setearParametro("@precioVenta", detalle.precioVenta);
                    datos.setearParametro("@cantidad", detalle.cantidad);
                    //datos.setearParametro("@fecha_registro", detalle.fecha_registro);

                    datos.ejecutarAccion();

                }

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



        //public void modificar(IngresoDet IngresoDet)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("update IngresoDet set documento = @documento, nombre_completo = @nombreCompleto, correo = @correo, clave = @clave, id_rol = @idRol, estado = @estado where id_IngresoDet = @idIngresoDet");
        //        datos.setearParametro("@documento", IngresoDet.documento);
        //        datos.setearParametro("@nombreCompleto", IngresoDet.nombreCompleto.ToUpper());
        //        datos.setearParametro("@correo", IngresoDet.correo.ToUpper());
        //        datos.setearParametro("@clave", IngresoDet.clave);
        //        datos.setearParametro("@idRol", IngresoDet.oRol.idRol);
        //        datos.setearParametro("@estado", IngresoDet.estado);
        //        datos.setearParametro("@idIngresoDet", IngresoDet.idIngresoDet);

        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        //public void eliminar(int id)
        //{
        //    try
        //    {
        //        AccesoDatos datos = new AccesoDatos();
        //        datos.setearConsulta("DELETE IngresoDet where id_IngresoDet = @id_IngresoDet");
        //        datos.setearParametro("@id_IngresoDet", id);
        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<Dom_Producto> filtrar(string campo, string criterio, string filtro)
        {
            List<Dom_Producto> lista = new List<Dom_Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select p.codigo_barra, p.codigo, p.nombre, p.descripcion, r.id_rubro from productos p inner join rubros r on p.id_rol = r.id_rol and ";


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
                    aux.UnidadMedida = new Dom_UnidadDeMedida();
                    aux.Proveedor = new Dom_Proveedor();
                    aux.Marca = new Dom_Marca();
                    IngresoDet det = new IngresoDet();
                    


                    aux.idProducto = (int)datos.Lector["id_producto"];
                    aux.codigo = (string)datos.Lector["codigo"];
                    aux.codigo_de_barra = (string)datos.Lector["codigo_barra"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.Rubro.idRubro = (int)datos.Lector["id_rol"];
                    aux.stock = (int)datos.Lector["stock"];
                    det.precioCompra = (decimal)datos.Lector["precio_compra"];
                    aux.precio_venta = (decimal)datos.Lector["precio_venta"];
                    aux.UnidadMedida.id_unidad_de_medida = (int)datos.Lector["id_unidad_medida"];
                    aux.fecha_vencimiento = (DateTime)datos.Lector["fecha_vencimiento"];
                    aux.estado = (bool)datos.Lector["estado"];
                    aux.fecha_registro = (DateTime)datos.Lector["fecha_registro"];
                    aux.Proveedor.idProveedor = (int)datos.Lector["id_proveedor"];
                    aux.Marca.idMarca = (int)datos.Lector["id_marca"];

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
        //}

    }
}
