<%@ Page Title="Administrar Administradores" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="Proyecto_ADSO.Vista.AdminUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .grid { margin-top: 10px; }
        input, button { padding: 8px; margin: 6px 4px; }
        .two { display:grid; grid-template-columns: 1fr 1fr; gap: 16px; }
    </style>
    <h2>Administrar Administradores</h2>
    <div class="two">
        <div>
            <h3>Listado</h3>
            <asp:Button ID="btnRefrescar" runat="server" Text="Refrescar" OnClick="btnRefrescar_Click" />
            <asp:GridView ID="gvAdmins" runat="server" CssClass="grid" AutoGenerateColumns="False" DataKeyNames="idUsuario" OnRowEditing="gvAdmins_RowEditing" OnRowCancelingEdit="gvAdmins_RowCancelingEdit" OnRowUpdating="gvAdmins_RowUpdating" OnRowDeleting="gvAdmins_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="idUsuario" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="documento" HeaderText="Documento" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="celular" HeaderText="Celular" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <h3>Crear</h3>
            <asp:TextBox ID="txtDocumento" runat="server" Placeholder="Documento"></asp:TextBox>
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtApellido" runat="server" Placeholder="Apellido"></asp:TextBox>
            <asp:TextBox ID="txtCelular" runat="server" Placeholder="Celular"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Placeholder="Clave"></asp:TextBox>
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            <asp:Label ID="lblCrear" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
