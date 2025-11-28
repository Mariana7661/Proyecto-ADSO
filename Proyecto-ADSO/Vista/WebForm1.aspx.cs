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
                var d = new ClAdminD();
                var a = d.ObtenerAdminPrincipal();
                if (a != null)
                {
                    lblAdminNombre.Text = "Nombre: " + (a.nombre ?? "");
                    lblAdminApellido.Text = "Apellido: " + (a.apellido ?? "");
                    lblAdminCelular.Text = "Celular: " + (a.celular ?? "");
                    if (!string.IsNullOrWhiteSpace(a.img))
                    {
                        imgAdmin.ImageUrl = a.img;
                    }
                    if (!string.IsNullOrWhiteSpace(a.celular))
                    {
                        var digits = new string((a.celular ?? "").Where(char.IsDigit).ToArray());
                        if (digits.StartsWith("3")) digits = "57" + digits;
                        lnkContactar.NavigateUrl = "https://wa.me/" + digits + "?text=Hola%20Fashion%20Colors";
                        lnkContactar.Visible = true;
                    }
                }
            }
        }
    }
}
