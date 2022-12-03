<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meus-eventos.aspx.cs" Inherits="MaisCultura.EventosdoCriador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/EventosdoCriador.css" />
    <link rel="icon" type="image/x-icon" href="../images/favicon.ico">

    <title>+Cultura | Meus Eventos </title>
</head>
<body>
    <form id="form1" runat="server">
         <header class="header header-primaria">
            <figure class="figure-header">
                <asp:Literal ID="litLogo" runat="server"></asp:Literal>
                    <img src="Images/logoNomeMenor.png" class="logo-header" />
                </a>
            </figure>

            <article class="usuario">
                <div class="menuUsuario">
                    <asp:Literal ID="litUsuario" runat="server"></asp:Literal>

                    <div class="dropdown-content">
                        <asp:Literal ID="litHome" runat="server"></asp:Literal>
                        <asp:Literal ID="litPerfil" runat="server"></asp:Literal>
                        <asp:Literal ID="litAdicionais" runat="server"></asp:Literal>
                        <a href="eventos.aspx">Sair</a>
                    </div>
                </div>
                <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                
            </article>
        </header>

        <section class="sectionBack">
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClientClick="JavaScript:window.history.back(1); return false;" />
        </section>

        <section class="meusEventos">
            <div class="btns">
                <h2>Meus Eventos</h2>
                <asp:Button ID="btnCriarEvento" runat="server" Text="+ Criar Evento" OnClick="btnCriarEvento_Click" />
            </div>
        </section>

        <main class="principal">

            <div class="corpo">
                <div class="event-manager">
                    <div class="eventos">
                        
                        <asp:Literal ID="litEventos" runat="server"></asp:Literal>
                            
                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
