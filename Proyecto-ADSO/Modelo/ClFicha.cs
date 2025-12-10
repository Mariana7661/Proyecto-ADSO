using System;

namespace Proyecto_ADSO.Modelo
{
    public class ClFicha
    {
        public int idFicha { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }
    }
}
