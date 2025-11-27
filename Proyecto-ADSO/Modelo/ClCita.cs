using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_ADSO.Modelo
{
    public class ClCita
    {
        public int idCita { get; set; }
        public DateTime fecha{ get; set; }
        public TimeSpan hora  { get; set; }
        public int idCliente { get; set; }

    }
}