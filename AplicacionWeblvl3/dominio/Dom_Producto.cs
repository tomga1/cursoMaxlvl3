using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_Producto
    {
        public int idProducto { get; set; }
        public string codigo { get; set; }
        public string codigo_de_barra { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Dom_Rubro Rubro { get; set; }
        public int stock { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
        public Dom_UnidadDeMedida UnidadMedida{ get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public bool estado { get; set; }
        public DateTime fecha_registro { get; set; }
        public Dom_Producto()
        {
            fecha_registro = DateTime.Now;
        }
        public Dom_Proveedor Proveedor { get; set; }
        public Dom_Marca Marca { get; set; }

        public Dom_Ubicaciones Ubicacion { get; set; }
        public string UrlImagen{ get; set; }


        public override string ToString()
        {
            if(estado == true)
            {
                return "ACTIVO"; 
            }
            else
            {
                return "INACTIVO";
            }
        }

        
    }
}
