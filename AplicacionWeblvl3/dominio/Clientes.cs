using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Clientes
    {
        public int id { get; set; }
    
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string razonsocial { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string mail { get; set; }
        public string localidad { get; set; }
        public Contacto Tipo { get; set; }
        public string cuit { get; set; }
    }
}


