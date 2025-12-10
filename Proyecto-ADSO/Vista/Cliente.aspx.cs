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

            var cliente = new ClUsuario
            {
                documento = txtDocumento.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                celular = txtCelular.Text,
                email = txtEmail.Text,
                clave = txtClave.Text
            };
            var dc = new ClClienteD();
            var id = dc.MtRegistrarCliente(cliente);
            if (id > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "ok", "alert('Usuario correctamente registrado'); window.location='Login.aspx';", true);
            }
            else
            {
                lblResultado.Text = "No se pudo registrar";
            }
        }
    }
}
