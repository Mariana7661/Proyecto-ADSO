using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Logica
{
    public class ClServicioL
    {
        public int Crear(ClServicio s)
        {
            var d = new ClServicioD();
            return d.CrearServicio(s);
        }

        public List<ClServicio> Listar()
        {
            var d = new ClServicioD();
            return d.ListarServicios();
        }

        public ClServicio ObtenerPorId(int id)
        {
            var d = new ClServicioD();
            return d.ObtenerServicioPorId(id);
        }

        public bool Actualizar(ClServicio s)
        {
            var d = new ClServicioD();
            return d.ActualizarServicio(s);
        }

        public bool Eliminar(int id)
        {
            var d = new ClServicioD();
            return d.EliminarServicio(id);
        }

        public List<ClServicio> BuscarPorNombre(string nombre)
        {
            var d = new ClServicioD();
            return d.BuscarServiciosPorNombre(nombre);
        }
    }
}
