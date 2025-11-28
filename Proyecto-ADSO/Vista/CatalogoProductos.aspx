<%@ Page Title="Catálogo de Productos" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoProductos.aspx.cs" Inherits="Proyecto_ADSO.Vista.CatalogoProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .catalog { display:grid; grid-template-columns: repeat(auto-fill, minmax(220px, 1fr)); gap:16px; }
        .card { background:#fff; border:1px solid #ddd; border-radius:10px; overflow:hidden; box-shadow:0 2px 8px rgba(0,0,0,.06); }
        .card img { width:100%; height:140px; object-fit:cover; }
        .card .body { padding:12px; }
        .card .title { font-weight:bold; margin-bottom:6px; }
        .price { color:#e91e63; font-weight:bold; }
    </style>
    <h2>Catalogo </h2>
    <asp:Label ID="lblCarrito" runat="server" Text="Carrito (0)"></asp:Label>
    <asp:Repeater ID="rpCatalogo" runat="server" OnItemCommand="rpCatalogo_ItemCommand">
        <HeaderTemplate><div class="catalog"></HeaderTemplate>
        <ItemTemplate>
            <div class="card">
                <img src="<%# string.IsNullOrEmpty(Eval("img") as string) ? "https://via.placeholder.com/300x140?text=Producto" : Eval("img") %>" alt="<%# Eval("nombre") %>" />
                <div class="body">
                    <div class="title"><%# Eval("nombre") %></div>
                    <div class="price">$ <%# string.Format("{0:N2}", Eval("precio")) %></div>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar al carrito" CommandName="Agregar" CommandArgument='<%# Eval("idProducto") %>' />
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate></div></FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</asp:Content>
