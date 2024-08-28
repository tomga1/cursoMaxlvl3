using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_Articulos
    {
        public int idProducto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Dom_Marca marca { get; set; }
        public Dom_Categoria categoria { get; set; }
        public string UrlImagen{ get; set; }
        public decimal precio_compra { get; set; }

    }
}
