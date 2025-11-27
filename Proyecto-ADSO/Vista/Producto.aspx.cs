using System;
using System.Collections.Generic;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();
            }
        }

        void CargarLista()
        {
            var d = new ClProductoD();
            gvProductos.DataSource = d.ListarProductos();
            gvProductos.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var d = new ClProductoD();
            var p = new ClProducto
            {
                nombre = txtNombre.Text,
                img = txtImg.Text,
                precio = decimal.Parse(txtPrecio.Text),
                idCliente = int.Parse(txtIdCliente.Text)
            };
            var id = d.CrearProducto(p);
            lblCrear.Text = id > 0 ? "Creado ID: " + id : "No se pudo crear";
            CargarLista();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        protected void btnObtener_Click(object sender, EventArgs e)
        {
            var d = new ClProductoD();
            var p = d.ObtenerProductoPorId(int.Parse(txtIdProductoGet.Text));
            gvProducto.DataSource = p != null ? new List<ClProducto> { p } : null;
            gvProducto.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var d = new ClProductoD();
            var p = new ClProducto
            {
                idProducto = int.Parse(txtIdProductoUp.Text),
                nombre = txtNombreUp.Text,
                img = txtImgUp.Text,
                precio = decimal.Parse(txtPrecioUp.Text),
                idCliente = int.Parse(txtIdClienteUp.Text)
            };
            var ok = d.ActualizarProducto(p);
            lblActualizar.Text = ok ? "Actualizado" : "No se pudo actualizar";
            CargarLista();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var d = new ClProductoD();
            var ok = d.EliminarProducto(int.Parse(txtIdProductoDel.Text));
            lblEliminar.Text = ok ? "Eliminado" : "No se pudo eliminar";
            CargarLista();
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            var d = new ClProductoD();
            gvBusquedaProductos.DataSource = d.BuscarProductosPorNombre(txtBuscarProducto.Text);
            gvBusquedaProductos.DataBind();
        }
    }
}
