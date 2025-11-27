using System;
using Proyecto_ADSO.Datos;

namespace Proyecto_ADSO.Vista
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            var d = new ClAdminD();
            var ok = d.MtVerificarLogin(txtCorreo.Text, txtClave.Text);
            lblMsg.Text = ok ? "Ingreso exitoso" : "Correo o clave incorrectos";
        }
    }
}
