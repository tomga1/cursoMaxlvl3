using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class BajaStockNegocio
    {

        public List<Ajuste_stock> listar()
        {
            List<Ajuste_stock> lista = new List<Ajuste_stock>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select a.id_baja, p.nombre as producto, a.cantidad, m.descripcion as motivo, a.fecha_registro, u.nombre_completo as usuario, a.observaciones, a.tipo_ajuste from ajuste_stock a JOIN productos p ON p.id_producto = a.id_producto JOIN motivos_baja_stock m ON m.id_motivo = a.motivo JOIN usuario u ON u.id_usuario= a.id_usuario");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Ajuste_stock aux = new Ajuste_stock();
                    aux.idBaja = (int)datos.Lector["id_baja"];
                    aux.nombreProducto = (string)datos.Lector["producto"];
                    aux.cantidad = (decimal)datos.Lector["cantidad"];
                    aux.motivo = (string)datos.Lector["motivo"];
                    aux.fecha_registro = (DateTime)datos.Lector["fecha_registro"];
                    aux.nombreUsuario = (string)datos.Lector["usuario"];
                    aux.observaciones = (string)datos.Lector["observaciones"];
                    aux.tipoAjuste = (string)datos.Lector["tipo_ajuste"];

                   

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }






        public void agregar(Ajuste_stock nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into ajuste_stock (id_producto, cantidad, motivo, fecha_registro, id_usuario, observaciones, tipo_ajuste) values (@id_producto, @cantidad, @motivo, @fecha_registro, @id_usuario, @observaciones, @tipo_ajuste)");
                datos.setearParametro("@id_producto", nuevo.idProducto);
                datos.setearParametro("@cantidad", nuevo.cantidad);
                datos.setearParametro("@motivo", nuevo.motivo.ToUpper());
                datos.setearParametro("@fecha_registro", nuevo.fecha_registro);
                datos.setearParametro("@id_usuario", nuevo.idUsuario);
                datos.setearParametro("@observaciones", nuevo.observaciones.ToUpper());
                datos.setearParametro("@tipo_ajuste", nuevo.tipoAjuste.ToUpper());



                datos.ejecutarAccion();

                string consultaStock; 

                if(nuevo.tipoAjuste.ToUpper() == "AGREGADO")
                {
                    consultaStock = "update productos set stock = stock + @cantidad where id_producto = @id_producto";
                }
                else if(nuevo.tipoAjuste.ToUpper() == "DESCONTADO")
                {
                    consultaStock = "update productos set stock = stock - @cantidad where id_producto = @id_producto";
                }
                else
                {
                    throw new Exception("Tipo de ajuste no reconocido.");
                }

                datos.limpiarParametros();
                datos.setearConsulta(consultaStock);
                datos.setearParametro("@id_producto", nuevo.idProducto);
                datos.setearParametro("@cantidad", nuevo.cantidad);

                datos.ejecutarAccion();


            }
            catch (Exception)
            {

                throw ;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
