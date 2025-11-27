using System;
using Proyecto_ADSO.Logica;

namespace Proyecto_ADSO.Vista
{
    public partial class LoginCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            var l = new ClClienteL();
            var ok = l.MtVerificarLogin(txtCorreo.Text, txtClave.Text);
            lblMsg.Text = ok ? "Ingreso exitoso" : "Correo o clave incorrectos";
        }
    }
}
