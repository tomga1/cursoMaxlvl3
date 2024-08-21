using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_MediosDePago
    {
        public int id_metodo_pago { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}
