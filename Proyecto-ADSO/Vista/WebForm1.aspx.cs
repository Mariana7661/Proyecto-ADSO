using System;
using System.Linq;
using System.Web.UI;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblAdminNombre.Text = "Nombre: Claudia";
                lblAdminApellido.Text = "Apellido: Garcia";
                lblAdminCelular.Text = "Celular: 3134561272";
                lnkContactar.NavigateUrl = "https://wa.me/573134561272?text=Hola%20Fashion%20Colors";
                lnkContactar.Visible = true;
            }
        }
    }
}
