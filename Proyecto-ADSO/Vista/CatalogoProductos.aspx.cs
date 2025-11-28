using System;
using Proyecto_ADSO.Datos;

namespace Proyecto_ADSO.Vista
{
    public partial class CatalogoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var d = new ClProductoD();
                rpCatalogo.DataSource = d.ListarProductos();
                rpCatalogo.DataBind();
                ActualizarCarritoCount();
            }
        }

        void ActualizarCarritoCount()
        {
            var carrito = Session["Carrito"] as System.Collections.Generic.List<int>;
            lblCarrito.Text = "Carrito (" + (carrito?.Count ?? 0) + ")";
        }

        protected void rpCatalogo_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                var carrito = Session["Carrito"] as System.Collections.Generic.List<int> ?? new System.Collections.Generic.List<int>();
                int id = int.Parse(e.CommandArgument.ToString());
                if (!carrito.Contains(id)) carrito.Add(id);
                Session["Carrito"] = carrito;
                lblMsg.Text = "Producto agregado";
                ActualizarCarritoCount();
            }
        }
    }
}
