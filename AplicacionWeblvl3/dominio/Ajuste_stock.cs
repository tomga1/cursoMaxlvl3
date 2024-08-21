using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ajuste_stock
    {
        public int idBaja { get; set; }
        public List<Dom_Producto> oProducto { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal cantidad { get; set; }
        public string motivo { get; set; }
        public DateTime fecha_registro { get; set; }
        public Ajuste_stock()
        {
            fecha_registro = DateTime.Now;
        }
        public Usuario oUsuario { get; set; }
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string observaciones { get; set; }
        public string tipoAjuste{ get; set; }

    }
}
