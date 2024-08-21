using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class IngresoCab
    {
        public int idIngreso_cab { get; set; }
        public Usuario oUsuario { get; set; }
        public Dom_Proveedor Proveedor { get; set; }
        public string numeroRemito { get; set; }
        public decimal montoTotal { get; set; }
        public List<IngresoDet> oDetalleIngreso  { get; set; }
        public DateTime fecha_registro { get; set; }
        public IngresoCab() 
        {
            fecha_registro = DateTime.Now;
        }
        public string observaciones { get; set; }
    }
}
