using System;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblResultado.Text = "Complete todos los campos obligatorios";
                return;
            }

            var cliente = new ClCliente
            {
                documento = txtDocumento.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                celular = txtCelular.Text,
                email = txtEmail.Text,
                clave = txtClave.Text,
                direccion = txtDireccion.Text
            };
            var d = new ClClienteD();
            var id = d.MtRegistrarCliente(cliente);
            lblResultado.Text = id > 0 ? "Cliente registrado con ID: " + id : "No se pudo registrar";
        }
    }
}
