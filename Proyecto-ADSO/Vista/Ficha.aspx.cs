using System;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class Ficha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var rol = Session["Rol"] as string;
                if (!string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                CargarLista();
            }
        }

        void CargarLista()
        {
            var d = new ClFichaD();
            gvFichas.DataSource = d.ListarFichas();
            gvFichas.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var d = new ClFichaD();
            var f = new ClFicha
            {
                titulo = txtTitulo.Text,
                descripcion = txtDescripcion.Text,
                fecha = DateTime.Parse(txtFecha.Text),
                idUsuario = int.Parse(txtIdUsuario.Text)
            };
            var id = d.CrearFicha(f);
            lblCrear.Text = id > 0 ? ("Creado ID: " + id) : "No se pudo crear";
            CargarLista();
        }

        protected void gvFichas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvFichas.EditIndex = e.NewEditIndex;
            CargarLista();
        }

        protected void gvFichas_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvFichas.EditIndex = -1;
            CargarLista();
        }

        protected void gvFichas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            var idFicha = (int)e.Keys[0];
            var row = gvFichas.Rows[e.RowIndex];
            var titulo = (row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var descripcion = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var fecha = DateTime.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            var idUsuario = int.Parse((row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            var d = new ClFichaD();
            var ok = d.ActualizarFicha(new ClFicha { idFicha = idFicha, titulo = titulo, descripcion = descripcion, fecha = fecha, idUsuario = idUsuario });
            gvFichas.EditIndex = -1;
            CargarLista();
        }

        protected void gvFichas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var idFicha = (int)e.Keys[0];
            var d = new ClFichaD();
            var ok = d.EliminarFicha(idFicha);
            CargarLista();
        }
    }
}
