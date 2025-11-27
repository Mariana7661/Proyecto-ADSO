using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Logica
{
    public class ClProductoL
    {
        public int Crear(ClProducto p)
        {
            var d = new ClProductoD();
            return d.CrearProducto(p);
        }

        public List<ClProducto> Listar()
        {
            var d = new ClProductoD();
            return d.ListarProductos();
        }

        public ClProducto ObtenerPorId(int id)
        {
            var d = new ClProductoD();
            return d.ObtenerProductoPorId(id);
        }

        public bool Actualizar(ClProducto p)
        {
            var d = new ClProductoD();
            return d.ActualizarProducto(p);
        }

        public bool Eliminar(int id)
        {
            var d = new ClProductoD();
            return d.EliminarProducto(id);
        }

        public List<ClProducto> BuscarPorNombre(string nombre)
        {
            var d = new ClProductoD();
            return d.BuscarProductosPorNombre(nombre);
        }
    }
}
