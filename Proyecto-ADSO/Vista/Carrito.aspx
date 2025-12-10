<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Proyecto_ADSO.Vista.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .factura { margin-top:16px; padding:12px; border:1px dashed #999; border-radius:8px; background:#fff; }
        .actions { margin: 10px 0; }
        .actions button { margin-right:8px; }
        .qr-fixed { position: fixed; right: 16px; bottom: 16px; width:120px; height:120px; border:1px solid #ddd; border-radius:8px; background:#fff; padding:6px; }
    </style>
    <h2>Carrito</h2>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Producto" />
            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="{0:N2}" />
        </Columns>
    </asp:GridView>
    <div class="actions">
        <asp:Button ID="btnVolver" runat="server" Text="Volver al catálogo" OnClick="btnVolver_Click" />
        <asp:Button ID="btnVaciar" runat="server" Text="Vaciar carrito" OnClick="btnVaciar_Click" />
        <asp:Button ID="btnFactura" runat="server" Text="Pagar" OnClick="btnFactura_Click" />
        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar consignación" OnClick="btnConfirmar_Click" />
    </div>
    <div class="factura" id="factura">
        <asp:Literal ID="litFactura" runat="server"></asp:Literal>
    </div>
    <asp:Image ID="imgQR" runat="server" CssClass="qr-fixed" AlternateText="QR Pago Nequi" />
</asp:Content>
