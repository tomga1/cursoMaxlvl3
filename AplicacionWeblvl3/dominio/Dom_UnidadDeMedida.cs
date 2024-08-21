using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_UnidadDeMedida
    {
        public int id_unidad_de_medida { get; set; }
        public string descripcion { get; set; }
        public override string ToString()
        {
            return descripcion;
        }
    }

}
