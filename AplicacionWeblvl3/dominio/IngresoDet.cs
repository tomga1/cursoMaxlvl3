using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class IngresoDet
    {
        public int id_ingreso_det { get; set; }
        public int id_ingreso_cab { get; set; }
        public int idProducto { get; set; }
        public Dom_Producto producto { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidad { get; set; }
        public decimal montoTotal { get; set; }
        public DateTime fecha_registro { get; set; }
        public IngresoDet()
        {
            fecha_registro = DateTime.Now;
        }
    }
}
