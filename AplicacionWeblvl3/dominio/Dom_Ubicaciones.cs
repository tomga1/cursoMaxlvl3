using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_Ubicaciones
    {
        public int idUbicacion { get; set; }
        public string codigo { get; set; }
        public string comentarios { get; set; }
        public DateTime fecha_registro { get; set; }
        public Dom_Ubicaciones()
        {
            fecha_registro = DateTime.Now;
        }

        public override string ToString()
        {
            return codigo; 
        }

    }

}


