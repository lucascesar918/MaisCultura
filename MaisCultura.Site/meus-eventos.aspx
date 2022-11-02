<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meus-eventos.aspx.cs" Inherits="MaisCultura.EventosdoCriador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/EventosdoCriador.css" />

    <title> +Cultura | Meus Eventos </title>
</head>
<body>
    <form id="form1" runat="server">
         <header class="header header-primaria">
            <figure class="figure-header">
                <img src="Images/logoNomeMenor.png" class="logo-header"/>
            </figure>

            <article class="usuario">
                <div class="menuUsuario">
                    <asp:Button CssClass="dropbtn" ID="dropbtnUsuario" runat="server" Text="Bárbara Pera" />
                    <div class="dropdown-content">
                     <a href="eventos.aspx">Eventos</a>
                     <%--<a href="perfil.aspx">Perfil</a>--%>
                     <a href="eventos.aspx">Sair</a>
                    </div>
                </div>
               
                    <img src="Images/perfil526ace.png" class="imgPerfil">
                
               </article>
        </header>

         <section class="sectionBack">
           <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClientClick="JavaScript:window.history.back(1); return false;"/>
       </section>

        <section class="meusEventos">
            <div class="btns">
            <h2>Meus Eventos</h2>
            <asp:Button ID="btnCriarEvento" runat="server" Text="+ Criar Evento" />
            </div>
        </section>

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
                <input type="datetime-local" id="dtStart" name="dtStart" class="dt dtStart" runat="server"/>
                <h2 class="filtros-subtitulos data">Fim</h2>
                <input type="datetime-local" id="dtEnd" name="dtEnd" class="dt dtEnd" runat="server"/>

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
                <div class="boxPesquisa">
                <section class="txtIcon">
                    <asp:TextBox ID="txtPesquisa" runat="server" CssClass="txt txtPesquisa" placeHolder="Pesquise por seus eventos..."></asp:TextBox>
                    <img src="Images/pesquisa.png" alt="Ícone pesquisa" class="icon"/>
                </section>
                </div>
                <hr />
                
                <div class="eventos">
                    <section class="card">
                        <article class="card-header">
                            <figure>
                                <img src="Images/perfil526ace.png" alt="imagem de perfil" class="perfil"/>
                            </figure>

                            <article class="card-header-nome">
                                <h2>Bárbara Pera</h2>
                                <h5>@barbara</h5>
                            </article>

                            <figure>
                                <img src="Images/save.png" alt="Salvar" class="save"/>
                            </figure>
                        </article>

                        <article class="card-tittle">
                            <h2>Interclasse EE Ablas Filho vs Etecaf</h2>
                        </article>
                            
                        <article class="card-tags">
                            <h2 class="tag">Esporte</h2>
                            <h2 class="tag">Futebol</h2>
                        </article>

                        <article class="card-image">
                            <figure>
                                <img src="Images/interclasse.jpg" alt="Interclasse de cria" class="foto-evento"/>
                            </figure>
                        </article>

                        <article class="card-dateTime dateTime">
                            <article class="card-dateTime date">
                                <figure>
                                    <img src="Images/calendar.png" alt="Calendar icon" class="calendar-icon"/>
                                </figure>
                                <h3>02/10 a 10/10</h3>
                            </article>

                            <article class="card-dateTime time">
                                <figure>
                                    <img src="Images/time.png" alt="Time icon" class="time-icon"/>
                                </figure>
                                <h3>15:10</h3>
                            </article>
                        </article>

                        <article class="card-local">
                            <figure>
                                <img src="Images/local.png" alt="Local icon" class="local-icon"/>
                            </figure>
                            <h3>Santos, SP</h3>
                        </article>
                    </section>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
