using System;
using Proyecto_ADSO.Datos;

namespace Proyecto_ADSO.Vista
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var logout = Request.QueryString["logout"];
                if (string.Equals(logout, "1", StringComparison.OrdinalIgnoreCase))
                {
                    lblMsg.Text = "Has cerrado sesión correctamente";
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var rol = ddlRol.SelectedValue;
            bool ok = false;
            if (rol == "Cliente")
            {
                var d = new ClClienteD();
                ok = d.MtVerificarLogin(txtCorreo.Text, txtClave.Text);
                if (ok) {
                    var c = d.ObtenerPorEmail(txtCorreo.Text);
                    if (c != null)
                    {
                        Session["Rol"] = "Cliente";
                        Session["ClienteId"] = c.idUsuario;
                    }
                    Response.Redirect("Cita.aspx"); return; }
            }
            else if (rol == "Administrador")
            {
                var d = new ClUsuarioD();
                ok = d.VerificarLoginAdmin(txtCorreo.Text, txtClave.Text);
                if (ok) { Session["Rol"] = "Administrador"; Response.Redirect("Servicio.aspx"); return; }
            }
            lblMsg.Text = "Correo o clave incorrectos";
        }
    }
}
