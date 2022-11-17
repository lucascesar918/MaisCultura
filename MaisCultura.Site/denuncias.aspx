<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="denuncias.aspx.cs" Inherits="MaisCultura.PainelDenuncias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/PainelDenuncias.css" />
    <title>+Cultura | Painel de Denúncias</title>
</head>

<body>
    <form id="form1" runat="server">
        <header class="header header-primaria">
            <figure class="figure-header">
                <img src="Images/logoNomeMenor.png" class="logo-header" />
            </figure>

            <article class="usuario">
                <div class="menuUsuario">
                    <asp:Button CssClass="dropbtn" ID="dropbtnUsuario" runat="server" Text="" />
                    <div class="dropdown-content">
                        <asp:Literal ID="litEventos" runat="server"></asp:Literal>
                        <a href="denuncias.aspx">Denúncias</a>
                        <asp:Literal ID="litPerfil" runat="server"></asp:Literal>
                        <a href="eventos.aspx">Sair</a>
                    </div>
                </div>
                <img src="Images/perfil526ace.png" class="imgPerfil">
            </article>
        </header>

        <section class="sectionBack">
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar"
                OnClientClick="JavaScript:window.history.back(1); return false;" />
        </section>

        <section class="sectionTitle">
            <h2>Denúncias</h2>
        </section>

        <section class="all">

            <asp:Literal ID="litDenuncias" runat="server"></asp:Literal>

        </section>

    </form>
</body>

</html>
