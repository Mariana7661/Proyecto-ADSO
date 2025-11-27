<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Proyecto_ADSO.Vista.Cliente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrar Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registrar Cliente</h2>
            <asp:Label ID="Label1" runat="server" Text="Documento"></asp:Label>
            <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento" ErrorMessage="Documento es obligatorio" Display="Dynamic" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre es obligatorio" Display="Dynamic" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Apellido es obligatorio" Display="Dynamic" />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Celular"></asp:Label>
            <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCelular" runat="server" ControlToValidate="txtCelular" ErrorMessage="Celular es obligatorio" Display="Dynamic" />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email es obligatorio" Display="Dynamic" />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave" ErrorMessage="Clave es obligatoria" Display="Dynamic" />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Dirección"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Dirección es obligatoria" Display="Dynamic" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Complete los campos obligatorios" DisplayMode="BulletList" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CausesValidation="true" />
            <br />
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
