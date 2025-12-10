using System.Collections.Generic;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Logica
{
    public class ClFichaL
    {
        public int Crear(ClFicha f)
        {
            var d = new ClFichaD();
            return d.CrearFicha(f);
        }

        public List<ClFicha> Listar()
        {
            var d = new ClFichaD();
            return d.ListarFichas();
        }

        public ClFicha ObtenerPorId(int id)
        {
            var d = new ClFichaD();
            return d.ObtenerFichaPorId(id);
        }

        public bool Actualizar(ClFicha f)
        {
            var d = new ClFichaD();
            return d.ActualizarFicha(f);
        }

        public bool Eliminar(int id)
        {
            var d = new ClFichaD();
            return d.EliminarFicha(id);
        }
    }
}
