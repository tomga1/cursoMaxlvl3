using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Dom_Usuario usuario = user != null ? (Dom_Usuario)user : null;

            if (usuario != null && usuario.idUsuario != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esAdmin(object user)
        {
            Dom_Usuario usuario = user != null ? (Dom_Usuario)user : null;

            if (usuario != null)
            {
                return usuario.TipoUsuario == TipoUsuario.ADMIN;
            }

            return false;
        }
    }
}
