<%@ Page Title="Citas" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Cita.aspx.cs" Inherits="Proyecto_ADSO.Vista.Cita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            .grid { margin-top: 10px; }
            input, button { padding: 8px; margin: 6px 4px; }
        </style>
        <div>
            <asp:Panel ID="pnlClienteAgenda" runat="server">
                <h2>Agendar Cita</h2>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="Fecha requerida" Display="Dynamic" />
                <asp:TextBox ID="txtHora" runat="server" TextMode="Time"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHora" runat="server" ControlToValidate="txtHora" ErrorMessage="Hora requerida" Display="Dynamic" />
                <asp:Label ID="lblServicio" runat="server" Text="Servicio"></asp:Label>
                <asp:DropDownList ID="ddlServicio" runat="server"></asp:DropDownList>
                <asp:Label ID="lblCliente" runat="server" Text="" Visible="false" />
                <asp:ValidationSummary ID="vs" runat="server" />
                <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                <asp:Label ID="lblCrear" runat="server"></asp:Label>
                <div id="pago" style="margin-top:8px;">
                    <asp:Image ID="imgQRServicio" runat="server" Visible="false" />
                </div>
            </asp:Panel>
            <hr />
            <asp:Panel ID="pnlClienteMis" runat="server">
                <h2>Mis Citas</h2>
                <asp:Button ID="btnListar" runat="server" Text="Ver" OnClick="btnListar_Click" />
                <asp:GridView ID="gvCitasCliente" runat="server" CssClass="grid"></asp:GridView>
            </asp:Panel>
            <hr />
            <asp:Panel ID="pnlAdminTodas" runat="server">
                <h2>Todas las Citas (Admin)</h2>
                <asp:Button ID="btnListarTodas" runat="server" Text="Actualizar" OnClick="btnListarTodas_Click" />
                <asp:GridView ID="gvCitasTodas" runat="server" CssClass="grid" AutoGenerateColumns="False" DataKeyNames="idCita" OnRowEditing="gvCitasTodas_RowEditing" OnRowCancelingEdit="gvCitasTodas_RowCancelingEdit" OnRowUpdating="gvCitasTodas_RowUpdating" OnRowDeleting="gvCitasTodas_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="idCita" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="hora" HeaderText="Hora" />
                        <asp:BoundField DataField="idUsuario" HeaderText="Id Usuario" />
                        <asp:BoundField DataField="idServicio" HeaderText="Id Servicio" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <hr />
            <asp:Panel ID="pnlClienteCancelar" runat="server">
                <h2>Cancelar Cita</h2>
                <asp:TextBox ID="txtIdCitaDel" runat="server" Placeholder="Id Cita"></asp:TextBox>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Label ID="lblCancelar" runat="server"></asp:Label>
            </asp:Panel>
        </div>
</asp:Content>
