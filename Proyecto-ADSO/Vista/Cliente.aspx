<%@ Page Title="Registrar Cliente" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Proyecto_ADSO.Vista.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            .form { max-width: 460px; margin: 30px auto; background:#fff; border:1px solid #bdb7ad; border-radius:8px; padding:18px; }
            .form h2 { text-align:center; font-size:28px; letter-spacing:1px; color:#7a7469; margin:8px 0 16px; }
            .label { display:block; font-weight:600; color:#6b6b6b; margin-top:6px; }
            .input { width: 100%; max-width: 240px; padding:8px; border:2px solid #bdb7ad; margin:6px 0 10px; }
            .row { display:grid; grid-template-columns: 1fr 1fr; gap:12px; }
            .group { display:flex; flex-direction:column; }
            .submit { width:100%; background:#6b7d5c; color:#fff; padding:12px; border:none; font-weight:bold; letter-spacing:1px; }
            @media (max-width:768px){ .row { grid-template-columns: 1fr; } }
        </style>
        <div class="form">
            <h2>CREAR CUENTA</h2>
            <div class="group">
                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Documento"></asp:Label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="input" Placeholder="Documento"></asp:TextBox>
            </div>
            
            <div class="group">
                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="input" Placeholder="Nombre"></asp:TextBox>
            </div>
          
            <div class="group">
                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="input" Placeholder="Apellido"></asp:TextBox>
            </div>
            
            <div class="group">
                <asp:Label ID="Label4" runat="server" CssClass="label" Text="Celular"></asp:Label>
                <asp:TextBox ID="txtCelular" runat="server" CssClass="input" Placeholder="Celular"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="Label5" runat="server" CssClass="label" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input" Placeholder="Email"></asp:TextBox>
            </div>
           
            <div class="group">
                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Clave"></asp:Label>
                <asp:TextBox ID="txtClave" runat="server" CssClass="input" TextMode="Password" Placeholder="Password"></asp:TextBox>
            </div>
            
            
            <asp:Button ID="btnRegistrar" runat="server" CssClass="submit" Text="CREAR" OnClick="btnRegistrar_Click" CausesValidation="true" />
            
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="lnkVolverLogin" runat="server" NavigateUrl="Login.aspx">Volver a Iniciar sesión</asp:HyperLink>
        </div>
</asp:Content>
