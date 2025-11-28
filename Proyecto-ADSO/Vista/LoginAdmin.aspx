<%@ Page Title="Inicio de sesión Administrador" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="Proyecto_ADSO.Vista.LoginAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card { max-width: 420px; margin: 20px auto; border: 1px solid #ddd; padding: 20px; border-radius: 8px; background:#fff; }
        .card input, .card button { width: 100%; padding: 10px; margin: 6px 0; }
    </style>
    <div class="card">
        <h2>Administrador - Iniciar sesión</h2>
        <asp:TextBox ID="txtCorreo" runat="server" Placeholder="Correo"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Correo requerido" Display="Dynamic" />
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Placeholder="Clave"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave" ErrorMessage="Clave requerida" Display="Dynamic" />
        <asp:ValidationSummary ID="vs" runat="server" />
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
</asp:Content>
