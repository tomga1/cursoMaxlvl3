using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio; 

namespace negocio
{
    public class UbicacionesNegocio
    {
        public List<Dom_Ubicaciones> listar()
        {
            List<Dom_Ubicaciones> lista = new List<Dom_Ubicaciones>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT * from ubicaciones");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_Ubicaciones aux = new Dom_Ubicaciones();
                    aux.idUbicacion = (int)datos.Lector["id_ubicacion"];
                    aux.codigo = (string)datos.Lector["codigo_ubicacion"];
                    aux.comentarios = (string)datos.Lector["comentarios"];
                    aux.fecha_registro = (DateTime)datos.Lector["fecha_registro"];
                    


                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al listar Ubicaciones: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


        public void agregar(Dom_Ubicaciones nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ubicaciones (codigo_ubicacion,comentarios) values (@codigo, @comentarios)");
                datos.setearParametro("@codigo", nuevo.codigo.ToUpper());
                datos.setearParametro("@comentarios", nuevo.comentarios.ToUpper());

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificar(Dom_Ubicaciones ubicacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ubicaciones set codigo_ubicacion = @codigo_ubicacion, comentarios = @comentarios where id_ubicacion = @id_ubicacion");
                datos.setearParametro("@id_ubicacion", ubicacion.idUbicacion);
                datos.setearParametro("@codigo_ubicacion", ubicacion.codigo.ToUpper());
                datos.setearParametro("@comentarios", ubicacion.comentarios.ToUpper());


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
                datos.setearConsulta("DELETE ubicaciones where id_ubicacion = @id_ubicacion");
                datos.setearParametro("@id_ubicacion", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
