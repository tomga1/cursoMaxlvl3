using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class BotonesPermiso
    {
        public int idPermiso { get; set; }
        public Rol oRol { get; set; }
        public string nombreMenu { get; set; }
        public string fechaCreacion { get; set; }
        public bool agregar { get; set; }
        public bool modificar { get; set; }
        public bool eliminar { get; set; }
    }
}
