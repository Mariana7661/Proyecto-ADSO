<%@ Page Title="Administrar Fichas" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Ficha.aspx.cs" Inherits="Proyecto_ADSO.Vista.Ficha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .grid { margin-top: 10px; }
        input, button { padding: 8px; margin: 6px 4px; }
        .two { display:grid; grid-template-columns: 1fr 1fr; gap: 16px; }
    </style>
    <h2>Administrar Fichas</h2>
    <div class="two">
        <div>
            <h3>Listado</h3>
            <asp:Button ID="btnListar" runat="server" Text="Refrescar" OnClick="btnListar_Click" />
            <asp:GridView ID="gvFichas" runat="server" CssClass="grid" AutoGenerateColumns="False" DataKeyNames="idFicha" OnRowEditing="gvFichas_RowEditing" OnRowCancelingEdit="gvFichas_RowCancelingEdit" OnRowUpdating="gvFichas_RowUpdating" OnRowDeleting="gvFichas_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="idFicha" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="titulo" HeaderText="Título" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="idUsuario" HeaderText="Id Usuario" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <h3>Crear</h3>
            <asp:TextBox ID="txtTitulo" runat="server" Placeholder="Título"></asp:TextBox>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Placeholder="Descripción"></asp:TextBox>
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
            <asp:TextBox ID="txtIdUsuario" runat="server" Placeholder="Id Usuario"></asp:TextBox>
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            <asp:Label ID="lblCrear" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
