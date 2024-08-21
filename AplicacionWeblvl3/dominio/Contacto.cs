using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Contacto
    {
        public int id { get; set; }
        public string nombrecontacto { get; set; }

        public override string ToString()
        {
            return nombrecontacto;  
        }
    }
} 
