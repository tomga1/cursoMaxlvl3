using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace dominio
{

    public enum TipoUsuario
    {
        NORMAL = 0,
        ADMIN = 1
    }
    public class Dom_Usuario
    {
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }  
        public string apellido { get; set; }
        public string urlImagenPerfil { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Dom_Usuario(string user, string pass, bool admin)
        { 
            email = user;
            password = pass; 
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;   
        }   
    }
}
    