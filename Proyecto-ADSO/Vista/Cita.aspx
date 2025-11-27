<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cita.aspx.cs" Inherits="Proyecto_ADSO.Vista.Cita" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Citas</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 20px; }
        .grid { margin-top: 10px; }
        input, button { padding: 8px; margin: 6px 4px; }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Agendar Cita</h2>
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="Fecha requerida" Display="Dynamic" />
            <asp:TextBox ID="txtHora" runat="server" TextMode="Time"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvHora" runat="server" ControlToValidate="txtHora" ErrorMessage="Hora requerida" Display="Dynamic" />
            <asp:TextBox ID="txtIdCliente" runat="server" Placeholder="Id Cliente"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIdCliente" runat="server" ControlToValidate="txtIdCliente" ErrorMessage="Cliente requerido" Display="Dynamic" />
            <asp:ValidationSummary ID="vs" runat="server" />
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            <asp:Label ID="lblCrear" runat="server"></asp:Label>
            <hr />
            <h2>Mis Citas</h2>
            <asp:TextBox ID="txtIdClienteList" runat="server" Placeholder="Id Cliente"></asp:TextBox>
            <asp:Button ID="btnListar" runat="server" Text="Ver" OnClick="btnListar_Click" />
            <asp:GridView ID="gvCitasCliente" runat="server" CssClass="grid"></asp:GridView>
            <hr />
            <h2>Todas las Citas (Admin)</h2>
            <asp:Button ID="btnListarTodas" runat="server" Text="Actualizar" OnClick="btnListarTodas_Click" />
            <asp:GridView ID="gvCitasTodas" runat="server" CssClass="grid"></asp:GridView>
            <hr />
            <h2>Cancelar Cita</h2>
            <asp:TextBox ID="txtIdCitaDel" runat="server" Placeholder="Id Cita"></asp:TextBox>
            <asp:TextBox ID="txtIdClienteDel" runat="server" Placeholder="Id Cliente"></asp:TextBox>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            <asp:Label ID="lblCancelar" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
