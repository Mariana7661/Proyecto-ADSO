<%@ Page Title="Catálogo de Productos" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoProductos.aspx.cs" Inherits="Proyecto_ADSO.Vista.CatalogoProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .catalog { display:grid; grid-template-columns: repeat(auto-fill, minmax(220px, 1fr)); gap:16px; }
        .card { background:#fff; border:1px solid #ddd; border-radius:10px; overflow:hidden; box-shadow:0 2px 8px rgba(0,0,0,.06); }
        .card img { width:100%; height:140px; object-fit:cover; }
        .card .body { padding:12px; }
        .card .title { font-weight:bold; margin-bottom:6px; }
        .price { color:#e91e63; font-weight:bold; }
        .desc { color:#555; margin:4px 0; white-space:normal; }
        .qr-fixed { position: fixed; right: 16px; bottom: 16px; width:120px; height:120px; border:1px solid #ddd; border-radius:8px; background:#fff; padding:6px; }
        .factura { margin-top:16px; padding:12px; border:1px dashed #999; border-radius:8px; background:#fff; }
    </style>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <style>
        .cart-fixed { position: fixed; right: 16px; top: 72px; background:#e91e63; color:#fff; padding:8px 12px; border-radius:20px; text-decoration:none; box-shadow:0 2px 8px rgba(0,0,0,.2); }
    </style>
    <a class="cart-fixed" href="Carrito.aspx">🛒 Carrito</a>
    <h2>Cat&aacute;logo</h2>
    <asp:Repeater ID="rpCatalogo" runat="server" OnItemCommand="rpCatalogo_ItemCommand">
        <HeaderTemplate><div class="catalog"></HeaderTemplate>
        <ItemTemplate>
            <div class="card">
                <img src="<%# GetImgUrl(Eval("img")) %>" alt="<%# Eval("nombre") %>" />
                <div class="body">
                    <div class="title"><%# Eval("nombre") %></div>
                    <div class="desc"><asp:Literal ID="litDesc" runat="server" Text='<%# Eval("descripcion") %>'></asp:Literal></div>
                    <div class="price">$ <%# string.Format("{0:N2}", Eval("precio")) %></div>
                    <asp:TextBox ID="txtQty" runat="server" Text="1" Width="40"></asp:TextBox>
                    <asp:Button ID="btnMinus" runat="server" Text="-" CommandName="Restar" CommandArgument='<%# Eval("idProducto") %>' />
                    <asp:Button ID="btnPlus" runat="server" Text="+" CommandName="Sumar" CommandArgument='<%# Eval("idProducto") %>' />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CommandName="Agregar" CommandArgument='<%# Eval("idProducto") %>' />
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate></div></FooterTemplate>
    </asp:Repeater>
    
</asp:Content>
