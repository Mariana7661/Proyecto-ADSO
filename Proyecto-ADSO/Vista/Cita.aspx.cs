using System;
using Proyecto_ADSO.Logica;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class Cita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            var l = new ClCitaL();
            var c = new ClCita
            {
                fecha = DateTime.Parse(txtFecha.Text),
                hora = TimeSpan.Parse(txtHora.Text),
                idCliente = int.Parse(txtIdCliente.Text)
            };
            var id = l.Crear(c);
            lblCrear.Text = id > 0 ? "Cita creada ID: " + id : "No se pudo crear";
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            var l = new ClCitaL();
            gvCitasCliente.DataSource = l.ListarCliente(int.Parse(txtIdClienteList.Text));
            gvCitasCliente.DataBind();
        }

        protected void btnListarTodas_Click(object sender, EventArgs e)
        {
            var l = new ClCitaL();
            gvCitasTodas.DataSource = l.ListarTodas();
            gvCitasTodas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            var l = new ClCitaL();
            var ok = l.Cancelar(int.Parse(txtIdCitaDel.Text), int.Parse(txtIdClienteDel.Text));
            lblCancelar.Text = ok ? "Cita cancelada" : "No se pudo cancelar";
        }
    }
}
