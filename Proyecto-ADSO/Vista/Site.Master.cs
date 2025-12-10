using System;

namespace Proyecto_ADSO.Vista
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            var loggedIn = !string.IsNullOrEmpty(rol);

            var lnkLogin = FindControl("lnkLogin") as System.Web.UI.WebControls.HyperLink;
            var lnkCitas = FindControl("lnkCitas") as System.Web.UI.WebControls.HyperLink;
            var lnkAdminProductos = FindControl("lnkAdminProductos") as System.Web.UI.WebControls.HyperLink;
            var lnkAdminServicios = FindControl("lnkAdminServicios") as System.Web.UI.WebControls.HyperLink;
            var lnkAdminUsuarios = FindControl("lnkAdminUsuarios") as System.Web.UI.WebControls.HyperLink;
            var pnlAdminMenu = FindControl("pnlAdminMenu") as System.Web.UI.WebControls.Panel;
            var btnLogout = FindControl("btnLogout") as System.Web.UI.WebControls.LinkButton;

            if (lnkLogin != null) lnkLogin.Visible = !loggedIn;
            if (lnkCitas != null) lnkCitas.Visible = true;
            var isAdmin = string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase);
            if (pnlAdminMenu != null) pnlAdminMenu.Visible = isAdmin;
            if (btnLogout != null) btnLogout.Visible = loggedIn;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session["Carrito"] = null;
            Response.Redirect("Login.aspx?logout=1");
        }
    }
}
