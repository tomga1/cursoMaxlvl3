using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ventas_det
    {
        public int idDetalleVenta { get; set; }
        public Ventas_cab oIdVenta { get; set; }
        public Dom_Producto oProducto { get; set; }
        public int cantidad { get; set; }
        public decimal  porcentajeDescuento { get; set; }
        public decimal descuento { get; set; }
        public decimal subTotal { get; set; }
        public DateTime fecha_registro { get; set; }
        public Ventas_det()
        {
            fecha_registro = DateTime.Now;
        }
    }
}
