<%@ Page Title="Registrar Cliente" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Proyecto_ADSO.Vista.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            .form { max-width: 460px; margin: 30px auto; background:#fff; border:1px solid #bdb7ad; border-radius:8px; padding:20px; }
            .form h2 { text-align:center; font-size:32px; letter-spacing:2px; color:#7a7469; margin:10px 0 20px; }
            .form label { display:none; }
            .form input { width:100%; padding:12px; border:2px solid #bdb7ad; margin:10px 0; }
            .form .row { display:grid; grid-template-columns: 1fr 1fr; gap:10px; }
            .form .submit { width:100%; background:#6b7d5c; color:#fff; padding:14px; border:none; font-weight:bold; letter-spacing:1px; }
            @media (max-width:768px){ .form .row { grid-template-columns: 1fr; } }
        </style>
        <div class="form">
            <h2>CREAR CUENTA</h2>
            <asp:Label ID="Label1" runat="server" Text="Documento"></asp:Label>
            <asp:TextBox ID="txtDocumento" runat="server" Placeholder="Documento"></asp:TextBox>
            
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox>
          
            <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" Placeholder="Apellido"></asp:TextBox>
            
            <div class="row">
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Celular"></asp:Label>
                    <asp:TextBox ID="txtCelular" runat="server" Placeholder="Celular"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
                </div>
            </div>
           
            <asp:Label ID="Label6" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
            
            <asp:Label ID="Label7" runat="server" Text="Dirección"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" Placeholder="Dirección"></asp:TextBox>
            
            <asp:Button ID="btnRegistrar" runat="server" CssClass="submit" Text="CREAR" OnClick="btnRegistrar_Click" CausesValidation="true" />
            
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="lnkVolverLogin" runat="server" NavigateUrl="LoginCliente.aspx">Volver a Iniciar sesión</asp:HyperLink>
        </div>
</asp:Content>
