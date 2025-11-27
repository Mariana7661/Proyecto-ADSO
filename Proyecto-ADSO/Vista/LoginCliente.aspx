<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginCliente.aspx.cs" Inherits="Proyecto_ADSO.Vista.LoginCliente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de sesión Cliente</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 20px; }
        .card { max-width: 420px; margin: 0 auto; border: 1px solid #ddd; padding: 20px; border-radius: 8px; }
        input, button { width: 100%; padding: 10px; margin: 6px 0; }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <h2>Cliente - Iniciar sesión</h2>
            <asp:TextBox ID="txtCorreo" runat="server" Placeholder="Correo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Correo requerido" Display="Dynamic" />
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Placeholder="Clave"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave" ErrorMessage="Clave requerida" Display="Dynamic" />
            <asp:ValidationSummary ID="vs" runat="server" />
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
