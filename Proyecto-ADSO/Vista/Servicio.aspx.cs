using System;
using System.Collections.Generic;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class Servicio : System.Web.UI.Page
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
            var d = new ClServicioD();
            gvServicios.DataSource = d.ListarServicios();
            gvServicios.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var d = new ClServicioD();
            var s = new ClServicio
            {
                servicio = txtServicio.Text,
                img = txtImg.Text,
                precio = decimal.Parse(txtPrecio.Text),
                idCliente = int.Parse(txtIdCliente.Text)
            };
            var id = d.CrearServicio(s);
            lblCrear.Text = id > 0 ? "Creado ID: " + id : "No se pudo crear";
            CargarLista();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        protected void btnObtener_Click(object sender, EventArgs e)
        {
            var d = new ClServicioD();
            var s = d.ObtenerServicioPorId(int.Parse(txtIdServicioGet.Text));
            gvServicio.DataSource = s != null ? new List<ClServicio> { s } : null;
            gvServicio.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var d = new ClServicioD();
            var s = new ClServicio
            {
                idServicio = int.Parse(txtIdServicioUp.Text),
                servicio = txtServicioUp.Text,
                img = txtImgUp.Text,
                precio = decimal.Parse(txtPrecioUp.Text),
                idCliente = int.Parse(txtIdClienteUp.Text)
            };
            var ok = d.ActualizarServicio(s);
            lblActualizar.Text = ok ? "Actualizado" : "No se pudo actualizar";
            CargarLista();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var d = new ClServicioD();
            var ok = d.EliminarServicio(int.Parse(txtIdServicioDel.Text));
            lblEliminar.Text = ok ? "Eliminado" : "No se pudo eliminar";
            CargarLista();
        }

        protected void btnBuscarServicio_Click(object sender, EventArgs e)
        {
            var d = new ClServicioD();
            gvBusquedaServicios.DataSource = d.BuscarServiciosPorNombre(txtBuscarServicio.Text);
            gvBusquedaServicios.DataBind();
        }
    }
}
