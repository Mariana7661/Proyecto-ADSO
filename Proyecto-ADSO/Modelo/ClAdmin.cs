using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_ADSO.Modelo
{
    public class ClAdmin
    {
        public int idAdmin { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string img { get; set; }
    }
}
