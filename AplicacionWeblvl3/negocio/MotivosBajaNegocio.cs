using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MotivosBajaNegocio
    {
        public List<Dom_MotivoBajaStock> listar()
        {
            List<Dom_MotivoBajaStock> lista = new List<Dom_MotivoBajaStock>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from motivos_baja_stock");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dom_MotivoBajaStock aux = new Dom_MotivoBajaStock();

                    aux.idMotivo = (int)datos.Lector["id_motivo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];

                    lista.Add(aux);
                }


            }
            catch (Exception ex)
            {

                lista = new List<Dom_MotivoBajaStock>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }
    }
}
