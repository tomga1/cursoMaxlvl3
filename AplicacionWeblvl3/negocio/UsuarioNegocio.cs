using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {

        public bool Loguear(Dom_Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
                datos.setearConsulta("select Id,nombre, apellido, urlImagenPerfil, admin from users where email = @email and pass = @pass");
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@pass", usuario.password);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.idUsuario = (int)datos.Lector["Id"];
                    usuario.nombre = datos.Lector["nombre"] != DBNull.Value ? (string)datos.Lector["nombre"] : null;
                    usuario.apellido = datos.Lector["apellido"] != DBNull.Value ? (string)datos.Lector["apellido"] : null;

                    // Manejo de posibles valores DBNull
                    usuario.urlImagenPerfil = datos.Lector["urlImagenPerfil"] == DBNull.Value
                        ? null
                        : (string)datos.Lector["urlImagenPerfil"];

                    usuario.TipoUsuario = (bool)datos.Lector["admin"] ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
            }
			catch (Exception ex)
			{

                throw new Exception("Error al intentar loguear el usuario: " + ex.Message);
            }
        }

        public void AgregarUsuario(Dom_Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into USERS (email,pass,admin) values (@email, @pass, 0);");

                datos.setearParametro("@email", nuevo.email);
                datos.setearParametro("@pass", nuevo.password);
                datos.setearParametro("@admin", nuevo.TipoUsuario);
                





                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
