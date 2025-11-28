<%@ Page Title="Iniciar Sesion" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="LoginCliente.aspx.cs" Inherits="Proyecto_ADSO.Vista.LoginCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .login-wrap { display:flex; gap:20px; align-items:flex-start; }
        .logo { max-width:140px; border-radius:8px; }
        .card { flex:1; max-width: 380px; margin: 10px auto; border: 1px solid #ddd; padding: 16px; border-radius: 8px; background:#fff; }
        .card h2 { text-align:center; margin-top:0; }
        .card input, .card button, .card a { width: 90%; padding: 8px; margin: 6px auto; display:block; }
    </style>
    <div class="login-wrap">
        <img class="logo" src="img/fashion colors.jpg" alt="Logo Fashion Colors" />
        <div class="card">
            <h2>Iniciar Sesion</h2>
            <asp:TextBox ID="txtCorreo" runat="server" Placeholder="Correo"></asp:TextBox>
            
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Placeholder="Clave"></asp:TextBox>
            <asp:ValidationSummary ID="vs" runat="server" />
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
            <asp:HyperLink ID="lnkRegistrar" runat="server" NavigateUrl="Cliente.aspx">Registrar</asp:HyperLink>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
