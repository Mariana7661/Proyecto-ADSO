<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="Proyecto_ADSO.Vista.Servicio" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRUD Servicios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Crear Servicio</h2>
            <asp:Label ID="Label1" runat="server" Text="Servicio"></asp:Label>
            <asp:TextBox ID="txtServicio" runat="server"></asp:TextBox>
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
            <asp:GridView ID="gvServicios" runat="server"></asp:GridView>
            <asp:Button ID="btnListar" runat="server" Text="Actualizar Lista" OnClick="btnListar_Click" />
            <h3>Buscar por nombre</h3>
            <asp:TextBox ID="txtBuscarServicio" runat="server" Placeholder="Servicio"></asp:TextBox>
            <asp:Button ID="btnBuscarServicio" runat="server" Text="Buscar" OnClick="btnBuscarServicio_Click" />
            <asp:GridView ID="gvBusquedaServicios" runat="server"></asp:GridView>
            <hr />
            <h2>Obtener por ID</h2>
            <asp:TextBox ID="txtIdServicioGet" runat="server" Placeholder="Id Servicio"></asp:TextBox>
            <asp:Button ID="btnObtener" runat="server" Text="Obtener" OnClick="btnObtener_Click" />
            <asp:GridView ID="gvServicio" runat="server"></asp:GridView>
            <hr />
            <h2>Actualizar</h2>
            <asp:TextBox ID="txtIdServicioUp" runat="server" Placeholder="Id Servicio"></asp:TextBox>
            <asp:TextBox ID="txtServicioUp" runat="server" Placeholder="Servicio"></asp:TextBox>
            <asp:TextBox ID="txtImgUp" runat="server" Placeholder="Imagen"></asp:TextBox>
            <asp:TextBox ID="txtPrecioUp" runat="server" Placeholder="Precio"></asp:TextBox>
            <asp:TextBox ID="txtIdClienteUp" runat="server" Placeholder="Id Cliente"></asp:TextBox>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <asp:Label ID="lblActualizar" runat="server"></asp:Label>
            <hr />
            <h2>Eliminar</h2>
            <asp:TextBox ID="txtIdServicioDel" runat="server" Placeholder="Id Servicio"></asp:TextBox>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Label ID="lblEliminar" runat="server"></asp:Label>
        </div>
    </form>
    </body>
    </html>
