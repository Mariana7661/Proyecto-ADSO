using System;
using Proyecto_ADSO.Logica;
using Proyecto_ADSO.Modelo;
using System.Web.UI;
using Proyecto_ADSO.Datos;

namespace Proyecto_ADSO.Vista
{
    public partial class Cita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (string.IsNullOrEmpty(rol)) { Response.Redirect("Login.aspx"); return; }
            var pnlClienteAgenda = FindControl("pnlClienteAgenda") as System.Web.UI.WebControls.Panel;
            var pnlClienteMis = FindControl("pnlClienteMis") as System.Web.UI.WebControls.Panel;
            var pnlClienteCancelar = FindControl("pnlClienteCancelar") as System.Web.UI.WebControls.Panel;
            var pnlAdminTodas = FindControl("pnlAdminTodas") as System.Web.UI.WebControls.Panel;

            var isCliente = string.Equals(rol, "Cliente", StringComparison.OrdinalIgnoreCase);
            var isAdmin = string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase);

            if (pnlClienteAgenda != null) pnlClienteAgenda.Visible = isCliente;
            if (pnlClienteMis != null) pnlClienteMis.Visible = isCliente;
            if (pnlClienteCancelar != null) pnlClienteCancelar.Visible = isCliente;
            if (pnlAdminTodas != null) pnlAdminTodas.Visible = isAdmin;
            if (!IsPostBack && isCliente)
            {
                var d = new ClServicioD();
                ddlServicio.DataSource = d.ListarServicios();
                ddlServicio.DataTextField = "servicio";
                ddlServicio.DataValueField = "idServicio";
                ddlServicio.DataBind();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Cliente", StringComparison.OrdinalIgnoreCase)) { lblCrear.Text = "Solo clientes pueden agendar"; return; }
            if (!Page.IsValid) return;
            var l = new ClCitaL();
            var id = Session["ClienteId"] != null ? Convert.ToInt32(Session["ClienteId"]) : 0;
            var c = new ClCita
            {
                fecha = DateTime.Parse(txtFecha.Text),
                hora = TimeSpan.Parse(txtHora.Text),
                idUsuario = id,
                idServicio = int.Parse(ddlServicio.SelectedValue)
            };
            var newId = l.Crear(c);
            if (newId > 0)
            {
                lblCrear.Text = "Su cita ha sido creada correctamente";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "citaOk", "alert('Su cita ha sido creada correctamente');", true);
                try
                {
                    var d = new ClServicioD();
                    var s = d.ObtenerServicioPorId(c.idServicio);
                    if (s != null)
                    {
                        var url = BuildQrUrl(s.precio);
                        imgQRServicio.ImageUrl = url;
                        imgQRServicio.Visible = true;
                    }
                }
                catch { }
            }
            else
            {
                lblCrear.Text = "No se pudo crear";
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Cliente", StringComparison.OrdinalIgnoreCase)) return;
            var l = new ClCitaL();
            var id = Session["ClienteId"] != null ? Convert.ToInt32(Session["ClienteId"]) : 0;
            gvCitasCliente.DataSource = l.ListarCliente(id);
            gvCitasCliente.DataBind();
        }

        protected void btnListarTodas_Click(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase)) return;
            var l = new ClCitaL();
            gvCitasTodas.DataSource = l.ListarTodas();
            gvCitasTodas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Cliente", StringComparison.OrdinalIgnoreCase)) { lblCancelar.Text = "Solo clientes pueden cancelar"; return; }
            var l = new ClCitaL();
            var id = Session["ClienteId"] != null ? Convert.ToInt32(Session["ClienteId"]) : 0;
            var ok = l.Cancelar(int.Parse(txtIdCitaDel.Text), id);
            lblCancelar.Text = ok ? "Cita cancelada" : "No se pudo cancelar";
        }

        protected void gvCitasTodas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase)) return;
            gvCitasTodas.EditIndex = e.NewEditIndex;
            btnListarTodas_Click(sender, EventArgs.Empty);
        }

        protected void gvCitasTodas_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase)) return;
            gvCitasTodas.EditIndex = -1;
            btnListarTodas_Click(sender, EventArgs.Empty);
        }

        protected void gvCitasTodas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase)) return;
            var idCita = (int)e.Keys[0];
            var row = gvCitasTodas.Rows[e.RowIndex];
            var fecha = DateTime.Parse((row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            var hora = TimeSpan.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            var idCliente = int.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            var l = new ClCitaL();
            var ok = l.Actualizar(new ClCita { idCita = idCita, fecha = fecha, hora = hora, idUsuario = idCliente });
            gvCitasTodas.EditIndex = -1;
            btnListarTodas_Click(sender, EventArgs.Empty);
        }

        protected void gvCitasTodas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var rol = Session["Rol"] as string;
            if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase)) return;
            var idCita = (int)e.Keys[0];
            var l = new ClCitaL();
            var ok = l.CancelarAdmin(idCita);
            btnListarTodas_Click(sender, EventArgs.Empty);
        }

        string BuildQrUrl(decimal amount)
        {
            var data = Uri.EscapeDataString($"Nequi pago servicio por $ {amount:N2}");
            return $"https://api.qrserver.com/v1/create-qr-code/?size=120x120&data={data}";
        }
    }
}
