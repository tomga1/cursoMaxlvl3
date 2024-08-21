using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ventas_cab
    {
        public int idVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public Tipo_Documento oTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public Clientes oCliente { get; set; }
        public  Dom_MediosDePago oMedioDePago { get; set; }
        public decimal montoPago { get; set; }
        public decimal montoCambio { get; set; }
        public decimal montoTotal { get; set; }
        public DateTime fecha_venta { get; set; }
        public Ventas_cab()
        {
            fecha_venta = DateTime.Now;
        }
        public Dom_EstadosVenta oEstadoVenta { get; set; }
        public string observaciones { get; set; }
        public List<Ventas_det> oDetalle_Venta { get; set; }
    }
}
