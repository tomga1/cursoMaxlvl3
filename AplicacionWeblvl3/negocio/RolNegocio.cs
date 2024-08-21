using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class RolNegocio
    {
        public List<Rol> listar()
        {
            List<Rol> lista = new List<Rol>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id_rol, descripcion from rol");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Rol oRol = new Rol();
                    oRol.idRol = (int)datos.Lector["id_rol"];
                    oRol.descripcion = (string)datos.Lector["descripcion"];

                    lista.Add(oRol);
                }
            }
            catch (Exception ex)
            {

                lista = new List<Rol>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }

    }
}
