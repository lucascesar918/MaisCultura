<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eventos.aspx.cs" Inherits="MaisCultura.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/Index.css" />

    <title>+Cultura</title>
</head>
<body>
    <form id="form1" runat="server">

        <header class="header header-primaria">
            <figure class="figure-header">
                <img src="Images/logoNomeMenor.png" class="logo-header"/>
            </figure>

            <article class="buttons">
                <asp:Button ID="btnLog" runat="server" Text="Entrar" class="button button-log"/>
                <asp:Button ID="btnCad" runat="server" Text="Criar conta" class="button button-cad"/>
            </article>
        </header>

        <header class="header header-secundaria">
            <article class="header-texto">
                <p>O 
                    <p2 class="highlight">
                        +Cultura
                    </p2> 
                    é uma plataforma para todos
                </p>
            </article>

            <figure class="figure-header">
                <img src="Images/Background_Grafismo_Hexagono.png" class="grafismo-header"/>
            </figure>
        </header>

        <div class="header nav">
            <section class="section-tags">
                <article class="tag">
                    Pintura 
                    <asp:Button ID="btnExcludePintura" runat="server" Text="X" class="button button-exclude"/>
                </article>
            </section>

            <section class="section-limpar">
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar Filtros" class="button button-clear"/>
            </section>
        </div>

        <main class="principal">
            <div class="filtros">
                <h2 class="filtros-titulos">Categoria</h2>
                <asp:Button ID="btnCatPintura" runat="server" Text="Pintura" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnCatMusica" runat="server" Text="Música" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnCatEsporte" runat="server" Text="Esporte" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnCatCinema" runat="server" Text="Cinema" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnCatTeatro" runat="server" Text="Teatro" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnCatJogos" runat="server" Text="Jogos" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnCatRPG" runat="server" Text="RPG" class="button filtros-subtitulos categoria"/>
                <asp:Button ID="btnVerMais" runat="server" Text="Ver mais categorias" class="button filtros-subtitulos verMais"/>
                <br />
                <h2 class="filtros-titulos">Local</h2>
                <asp:TextBox ID="txtLocal" runat="server" CssClass="txt txtLocal"></asp:TextBox>
                
                <h2 class="filtros-titulos">Datas e horários</h2>
                <h2 class="filtros-subtitulos data">Início</h2>
                <asp:TextBox type="datetime-local" ID="dtStart" name="dtStart" class="dt dtStart" runat="server"></asp:TextBox>
                <h2 class="filtros-subtitulos data">Fim</h2>
                <asp:TextBox type="datetime-local" ID="dtEnd" name="dtEnd" class="dt dtEnd" runat="server"></asp:TextBox>

                <h2 class="filtros-titulos aval">Avaliação</h2>
                <asp:DropDownList ID="dpdAval" runat="server" CssClass="dpdAval">
                    <asp:ListItem selected>Todos</asp:ListItem>
                    <asp:ListItem>Uma estrela</asp:ListItem>
                    <asp:ListItem>Duas estrelas</asp:ListItem>
                    <asp:ListItem>Três estrelas</asp:ListItem>
                    <asp:ListItem>Quatro estrelas</asp:ListItem>
                    <asp:ListItem>Cinco estrelas</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="corpo">
                <section class="txtIcon">
                    <asp:TextBox ID="txtPesquisa" runat="server" CssClass="txt txtPesquisa" placeHolder="O que você quer ver hoje?"></asp:TextBox>
                    <img src="Images/pesquisa.png" alt="Ícone pesquisa" class="icon"/>
                </section>
                
                <hr />
                
                <div class="eventos">
                    <asp:Literal ID="litEventos" runat="server"></asp:Literal>
                </div>
            </div>
        </main>
    </form>
    
    <script type="text/javascript" src="js/eventos.js"></script>
</body>
</html>