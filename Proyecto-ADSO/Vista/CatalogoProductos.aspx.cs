using System;
using Proyecto_ADSO.Datos;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;

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
            }
        }

        protected string GetImgUrl(object value)
        {
            var s = value as string;
            if (string.IsNullOrWhiteSpace(s)) return "https://via.placeholder.com/300x140?text=Producto";
            s = s.Trim();
            s = s.Replace("\\", "/");
            // Si viene absoluta o relativa correcta, resolver y devolver
            if (s.StartsWith("http", StringComparison.OrdinalIgnoreCase) || s.StartsWith("data:") || s.StartsWith("~/") || s.StartsWith("/"))
                return ResolveUrl(s);
            // Si ya incluye carpeta img, anteponer la carpeta Vista
            if (s.StartsWith("img/", StringComparison.OrdinalIgnoreCase))
                return ResolveUrl("~/Vista/" + s);
            // Si solo es nombre de archivo, apuntar a Vista/img
            return ResolveUrl("~/Vista/img/" + s);
        }

        Dictionary<int, int> GetCart()
        {
            var cart = Session["Carrito"] as Dictionary<int, int>;
            if (cart == null)
            {
                cart = new Dictionary<int, int>();
                Session["Carrito"] = cart;
            }
            return cart;
        }

        // El carrito ahora se gestiona en Carrito.aspx

        protected void rpCatalogo_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                var qtyBox = e.Item.FindControl("txtQty") as TextBox;
                int qty = 1;
                if (qtyBox != null) int.TryParse(qtyBox.Text, out qty);
                qty = Math.Max(1, qty);
                var cart = GetCart();
                if (cart.ContainsKey(id)) cart[id] += qty; else cart[id] = qty;
                lblMsg.Text = "";
            }
            else if (e.CommandName == "Sumar")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                var qtyBox = e.Item.FindControl("txtQty") as TextBox;
                int qty = 1;
                if (qtyBox != null) int.TryParse(qtyBox.Text, out qty);
                qty = Math.Max(1, qty + 1);
                if (qtyBox != null) qtyBox.Text = qty.ToString();
                lblMsg.Text = "";
            }
            else if (e.CommandName == "Restar")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                var qtyBox = e.Item.FindControl("txtQty") as TextBox;
                int qty = 1;
                if (qtyBox != null) int.TryParse(qtyBox.Text, out qty);
                qty = Math.Max(1, qty - 1);
                if (qtyBox != null) qtyBox.Text = qty.ToString();
                lblMsg.Text = "";
            }
        }

    }
}
