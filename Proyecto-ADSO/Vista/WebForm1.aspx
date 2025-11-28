﻿﻿﻿﻿﻿﻿﻿﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Proyecto_ADSO.Vista.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Fashion Colors</title>
    <style>
        body { margin:0; font-family: Arial, sans-serif; background: #fdeef5; }
        .navbar { display:flex; justify-content:space-between; align-items:center; padding:12px 20px; background:#111; color:#fff; position:sticky; top:0; }
        .navbar a { color:#fff; text-decoration:none; margin:0 10px; }
        .hero { height: 100vh; display:flex; align-items:center; justify-content:center; text-align:center; color:#fff; background-image: url('img/fashion colors.jpg'); background-position: center; background-size: contain; background-repeat: no-repeat; }
        .hero h1 { font-size: 48px; letter-spacing: 1px; background: rgba(0,0,0,.35); padding: 8px 16px; border-radius: 8px; }
        .container { max-width: 1000px; margin: 0 auto; padding: 20px; }
        .card { display:flex; gap:20px; border:1px solid #ddd; border-radius:12px; padding:20px; background:#fff; box-shadow:0 2px 10px rgba(0,0,0,.08); }
        .card img { width:160px; height:160px; object-fit:cover; border-radius:10px; }
        .section { padding: 20px 0; }
        .btn { display:inline-block; background:#25D366; color:#fff; padding:8px 12px; border-radius:6px; text-decoration:none; }
        .section h2 { margin-top:0; }
        @media (max-width: 768px) { .hero h1 { font-size: 32px; } .card { flex-direction:column; align-items:center; text-align:center; } }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <div><strong>Fashion Colors</strong></div>
            <div>
                <a href="#acerca">Acerca de nosotros</a>
                <a href="#contactos">Contactos</a>
                <a href="CatalogoProductos.aspx">Productos</a>
                <a href="LoginCliente.aspx">Citas</a>
                <a href="LoginCliente.aspx">Iniciar sesión</a>
            </div>
        </div>

        <div class="hero">
            <h1>Fashion Colors</h1>
        </div>

        <div class="container">
            <div id="acerca" class="section">
                <h2>Acerca de nosotros</h2>
                <div class="card">
                    <div>
                        <p>En Fashion Colors creemos que cada estilo cuenta una historia. Ofrecemos servicios profesionales de peluquería y estética con productos de calidad y técnicas modernas.</p>
                        <p>Cuidamos cada detalle para ofrecerte una experiencia única, desde colorimetría avanzada hasta cortes y tratamientos personalizados.</p>
                    </div>
                </div>
            </div>

            <div class="card">
                <asp:Image ID="imgAdmin" runat="server" ImageUrl="img/Peluquera.png" AlternateText="Peluquera" />
                <div>
                    <h3>Administradora - Peluquera</h3>
                    <p><asp:Label ID="lblAdminNombre" runat="server" Text="Nombre:" /></p>
                    <p><asp:Label ID="lblAdminApellido" runat="server" Text="Apellido:" /></p>
                    <p><asp:Label ID="lblAdminCelular" runat="server" Text="Celular:" /></p>
                    <p>Experta en colorimetría y estilismo. Atención personalizada para cada cliente.</p>
                    <asp:HyperLink ID="lnkContactar" runat="server" CssClass="btn" Text="Contactar por WhatsApp" Target="_blank" />
                </div>
            </div>

            <div id="contactos" class="section">
                <h2>Contactos</h2>
                <div class="card">
                    <div>
                        <p>Teléfono: 300 000 0000</p>
                        <p>Correo: contacto@fashioncolors.com</p>
                        <p>Dirección: Calle 123 # 45-67</p>
                        <p>Horario: Lunes a Sábado, 9:00 am - 7:00 pm</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
