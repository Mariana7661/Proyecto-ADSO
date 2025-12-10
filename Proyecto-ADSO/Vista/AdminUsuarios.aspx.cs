using System;
using System.Collections.Generic;
using System.Web.UI;
using Proyecto_ADSO.Datos;
using Proyecto_ADSO.Modelo;

namespace Proyecto_ADSO.Vista
{
    public partial class AdminUsuarios : System.Web.UI.Page
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
            var d = new ClUsuarioD();
            gvAdmins.DataSource = d.ListarAdministradores();
            gvAdmins.DataBind();
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarLista();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var d = new ClUsuarioD();
            var u = new ClUsuario
            {
                documento = txtDocumento.Text,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                celular = txtCelular.Text,
                email = txtEmail.Text,
                clave = txtClave.Text
            };
            var id = d.CrearAdministrador(u);
            lblCrear.Text = id > 0 ? ("Creado ID: " + id) : "No se pudo crear";
            CargarLista();
        }

        protected void gvAdmins_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvAdmins.EditIndex = e.NewEditIndex;
            CargarLista();
        }

        protected void gvAdmins_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvAdmins.EditIndex = -1;
            CargarLista();
        }

        protected void gvAdmins_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            var idUsuario = (int)e.Keys[0];
            var row = gvAdmins.Rows[e.RowIndex];
            var documento = (row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var nombre = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var apellido = (row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var celular = (row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var email = (row.Cells[5].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            var d = new ClUsuarioD();
            var ok = d.ActualizarAdministrador(new ClUsuario
            {
                idUsuario = idUsuario,
                documento = documento,
                nombre = nombre,
                apellido = apellido,
                celular = celular,
                email = email
            });
            gvAdmins.EditIndex = -1;
            CargarLista();
        }

        protected void gvAdmins_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            var idUsuario = (int)e.Keys[0];
            var d = new ClUsuarioD();
            var ok = d.EliminarAdministrador(idUsuario);
            CargarLista();
        }
    }
}
