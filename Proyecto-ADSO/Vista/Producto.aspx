<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Proyecto_ADSO.Vista.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Crear Producto</h2>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Imagen"></asp:Label>
            <asp:TextBox ID="txtImg" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Id Cliente"></asp:Label>
            <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            <asp:Label ID="lblCrear" runat="server"></asp:Label>
            <hr />
            <h2>Listado</h2>
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvProductos_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="idProducto" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="img" HeaderText="Imagen" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="idCliente" HeaderText="Id Cliente" />
                </Columns>
            </asp:GridView>
            <h3>Buscar por nombre</h3>
            <asp:TextBox ID="txtBuscarProducto" runat="server" Placeholder="Nombre"></asp:TextBox>
            <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar" OnClick="btnBuscarProducto_Click" />
            <asp:GridView ID="gvBusquedaProductos" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvBusquedaProductos_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="idProducto" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="img" HeaderText="Imagen" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="idCliente" HeaderText="Id Cliente" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnListar" runat="server" Text="Actualizar Lista" OnClick="btnListar_Click" />
            <hr />
            <h2>Obtener por ID</h2>
            <asp:TextBox ID="txtIdProductoGet" runat="server" Placeholder="Id Producto"></asp:TextBox>
            <asp:Button ID="btnObtener" runat="server" Text="Obtener" OnClick="btnObtener_Click" />
            <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="idProducto" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="img" HeaderText="Imagen" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="idCliente" HeaderText="Id Cliente" />
                </Columns>
            </asp:GridView>
            <hr />
            <h2>Actualizar</h2>
            <asp:TextBox ID="txtIdProductoUp" runat="server" Placeholder="Id Producto"></asp:TextBox>
            <asp:TextBox ID="txtNombreUp" runat="server" Placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtImgUp" runat="server" Placeholder="Imagen"></asp:TextBox>
            <asp:TextBox ID="txtPrecioUp" runat="server" Placeholder="Precio"></asp:TextBox>
            <asp:TextBox ID="txtIdClienteUp" runat="server" Placeholder="Id Cliente"></asp:TextBox>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <asp:Label ID="lblActualizar" runat="server"></asp:Label>
            <hr />
            <h2>Eliminar</h2>
            <asp:TextBox ID="txtIdProductoDel" runat="server" Placeholder="Id Producto"></asp:TextBox>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Label ID="lblEliminar" runat="server"></asp:Label>
        </div>
</asp:Content>
