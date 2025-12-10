<%@ Page Title="Servicios" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="Proyecto_ADSO.Vista.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            <asp:Label ID="lblCrear" runat="server"></asp:Label>
            <hr />
            <h2>Listado</h2>
            <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvServicios_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="idServicio" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="servicio" HeaderText="Servicio" />
                    <asp:BoundField DataField="img" HeaderText="Imagen" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="idUsuario" HeaderText="Id Usuario" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnListar" runat="server" Text="Actualizar Lista" OnClick="btnListar_Click" />
            
            
            <hr />
            <h2>Actualizar</h2>
            <asp:TextBox ID="txtIdServicioUp" runat="server" Placeholder="Id Servicio"></asp:TextBox>
            <asp:TextBox ID="txtServicioUp" runat="server" Placeholder="Servicio"></asp:TextBox>
            <asp:TextBox ID="txtImgUp" runat="server" Placeholder="Imagen"></asp:TextBox>
            <asp:TextBox ID="txtPrecioUp" runat="server" Placeholder="Precio"></asp:TextBox>
            <asp:TextBox ID="txtIdUsuarioUp" runat="server" Placeholder="Id Usuario"></asp:TextBox>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <asp:Label ID="lblActualizar" runat="server"></asp:Label>
            <hr />
            <h2>Eliminar</h2>
            <asp:TextBox ID="txtNombreServicioDel" runat="server" Placeholder="Nombre del Servicio"></asp:TextBox>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Label ID="lblEliminar" runat="server"></asp:Label>
        </div>
</asp:Content>
