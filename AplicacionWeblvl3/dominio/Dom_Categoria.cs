﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Dom_Categoria
    {
        public int idCategoria { get; set; }
        public string descripcion { get; set; }


        public override string ToString()
        {
            return descripcion; 
        }
    }
    
}
