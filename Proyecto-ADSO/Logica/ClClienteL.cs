using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Logica
{
    public class ClClienteL
    {
        public int MtRegistrarCliente(ClCliente c)
        {
            var d = new ClClienteD();
            return d.MtRegistrarCliente(c);
        }

        public bool MtVerificarDocumentoExistente(string documento)
        {
            var d = new ClClienteD();
            return d.MtVerificarDocumentoExistente(documento);
        }

        public bool MtVerificarLogin(string correo, string clave)
        {
            var d = new ClClienteD();
            return d.MtVerificarLogin(correo, clave);
        }

        public ClCliente ObtenerPorEmail(string email)
        {
            var d = new ClClienteD();
            return d.ObtenerPorEmail(email);
        }

        public bool ActualizarDatosPersonales(ClCliente c)
        {
            var d = new ClClienteD();
            return d.ActualizarDatosPersonales(c);
        }
    }
}
