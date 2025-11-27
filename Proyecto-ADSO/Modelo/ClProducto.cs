using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_ADSO.Modelo
{
    public class ClProducto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }
        public decimal precio { get; set; }
        public int idCliente { get; set; }
    }
}