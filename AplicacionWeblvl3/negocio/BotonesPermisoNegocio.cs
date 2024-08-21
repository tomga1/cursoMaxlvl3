using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dominio;

namespace negocio
{

    public class BotonesPermisoNegocio
    {
        public List<BotonesPermiso> listar(int idRol, string nombreBoton = "")
        {
            List<BotonesPermiso> lista = new List<BotonesPermiso>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id_permiso, id_rol,nombre_menu,agregar, modificar, eliminar from botones_permiso where id_rol = @id_rol");
                datos.setearParametro("@id_rol", idRol);
                if(nombreBoton != "")
                {
                    datos.setearConsulta("select id_permiso, id_rol,nombre_menu,agregar, modificar, eliminar from botones_permiso where id_rol = @id_rol and nombre_menu = @nombre");
                    datos.setearParametro("@nombre", nombreBoton);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Rol oRol = new Rol();
                    BotonesPermiso aux = new BotonesPermiso();
                    aux.idPermiso = (int)datos.Lector["id_permiso"];
                    oRol.idRol = (int)datos.Lector["id_rol"];
                    aux.nombreMenu = (string)datos.Lector["nombre_menu"];
                    aux.agregar = (bool)datos.Lector["agregar"];
                    aux.modificar = (bool)datos.Lector["modificar"];
                    aux.eliminar = (bool)datos.Lector["eliminar"];


                    lista.Add(aux);
                }

            }
            catch (Exception ex)
            {

                lista = new List<BotonesPermiso>();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;

        }
    }




}