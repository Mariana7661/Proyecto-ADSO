using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Logica
{
    public class ClCitaL
    {
        public int Crear(ClCita c)
        {
            var d = new ClCitaD();
            return d.CrearCita(c);
        }

        public List<ClCita> ListarCliente(int idCliente)
        {
            var d = new ClCitaD();
            return d.ListarCitasCliente(idCliente);
        }

        public List<ClCita> ListarTodas()
        {
            var d = new ClCitaD();
            return d.ListarTodasCitas();
        }

        public bool Cancelar(int idCita, int idCliente)
        {
            var d = new ClCitaD();
            return d.CancelarCita(idCita, idCliente);
        }
    }
}
