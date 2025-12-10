using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_ADSO.Datos;

namespace Proyecto_ADSO.Vista
{
    public partial class Carrito : System.Web.UI.Page
    {
        const string NEQUI_NUMBER = "3XXXXXXXXX";

        protected void Page_Load(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (string.IsNullOrEmpty(rol))
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                BindCart();
            }
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

        void BindCart()
        {
            var cart = GetCart();
            var d = new ClProductoD();
            var items = new List<dynamic>();
            decimal total = 0;
            foreach (var kv in cart)
            {
                var p = d.ObtenerProductoPorId(kv.Key);
                if (p == null) continue;
                var subtotal = p.precio * kv.Value;
                total += subtotal;
                items.Add(new { nombre = p.nombre, cantidad = kv.Value, precio = p.precio, subtotal });
            }
            gvCarrito.DataSource = items;
            gvCarrito.DataBind();
            lblMsg.Text = items.Count > 0 ? ("Total: $ " + total.ToString("N2")) : "Carrito vacío";
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            Session["Carrito"] = new Dictionary<int, int>();
            BindCart();
        }

        string BuildQrUrl(decimal amount)
        {
            var data = Uri.EscapeDataString($"Nequi pago a {NEQUI_NUMBER} por $ {amount:N2}");
            return $"https://api.qrserver.com/v1/create-qr-code/?size=120x120&data={data}";
        }

        protected void btnFactura_Click(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (string.IsNullOrEmpty(rol)) { Response.Redirect("Login.aspx"); return; }
            var cart = GetCart();
            if (cart.Count == 0)
            {
                lblMsg.Text = "Carrito vacío";
                return;
            }
            var d = new ClProductoD();
            decimal total = 0;
            var factura = "Factura - Fashion Colors" + "<br/>";
            foreach (var kv in cart)
            {
                var p = d.ObtenerProductoPorId(kv.Key);
                if (p == null) continue;
                var subtotal = p.precio * kv.Value;
                total += subtotal;
                factura += $"{p.nombre} x {kv.Value} — $ {subtotal:N2}<br/>";
            }
            factura += $"<strong>Total: $ {total:N2}</strong><br/>" +
                       "Estado: En proceso de pago (Nequi)";
            litFactura.Text = factura;
            imgQR.ImageUrl = BuildQrUrl(total);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "gotoFactura", "location.hash='factura';", true);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (string.IsNullOrEmpty(rol)) { Response.Redirect("Login.aspx"); return; }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "okCompra", "alert('Su compra ha sido exitosa');", true);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalogoProductos.aspx");
        }
    }
}
