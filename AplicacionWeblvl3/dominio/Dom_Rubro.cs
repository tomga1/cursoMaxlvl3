using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_Rubro
    {
        public int idRubro { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }

        public Dom_Rubro() 
        {
            fechaCreacion = DateTime.Now;
        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
