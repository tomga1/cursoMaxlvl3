using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_Proveedor
    {
        public int idProveedor { get; set; }
        public string documento { get; set; }
        public string razon_social { get; set; }
        public string correo { get; set; }
        public string telefono{ get; set; }
        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }

        public Dom_Proveedor()
        {
            fechaCreacion = DateTime.Now;
        }

        public override string ToString()
        {
            return razon_social;
        }
    }
}
