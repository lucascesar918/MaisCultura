<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilOutroUsuario.aspx.cs" Inherits="MenosCultura.PerfilOutroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/PerfilOutroUsuario.css" />

    <title> +Cultura | Perfil de Outro Uusário </title>
</head>
<body>
    <form id="form1" runat="server">
          <header class="header header-primaria">
            <figure class="figure-header">
                <img src="Images/logoNomeMenor.png" class="logo-header"/>
            </figure>

            <article class="usuario">
                <div class="menuUsuario">
                  <button class="dropbtn">João Carlos</button>
                    <div class="dropdown-content">
                     <a href="eventos.aspx">Início</a>
                     <a href="PerfildoUsuario.aspx">Perfil</a>
                     <a href="EventosCriador.aspx">Meus Eventos</a>
                     <a href="eventos.aspx">Sair</a>
                    </div>
                </div>
               
                    <img src="Images/perfil526ace.png" class="imgPerfil">
                
               </article>
        </header>
       <section class="sectionBack">
           <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClientClick="JavaScript:window.history.back(1); return false;"/>
       </section>
<section class="all">
        <main>

            <section class="perfilUsuario">
                    <figure>
                        <img src="Images/perfil526ace.png" class="imgperfilUser"/>
                    </figure>
                    <article class="nmUser">
                        <h1 class="nmCompleto">Bárbara Pera</h1>
                        <div class="userTUsuario">
                            <p class="arroba">@barbara</p>
                            <div class="tipoUsuario"> <p>CRIADOR DE EVENTOS</p> </div>
                        </div>
                    </article>
                </section>
            <section class="eventosCriador">
                <h2 class="h2"> Eventos do Criador </h2>
                <section class="feedEventos">
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
                    </section>
                </section>
                <section class="avaliacaoCriador">
                    <h2 class="h2"> Avaliações do Criador </h2>
                    <div class="nmrMedia">
                        <h3 style="font-size: 2.6vh; margin: 10px;"> Média </h3>
                        <h3 style="font-size: 2.6vh; margin: 10px;"> 4,5 </h3>
                        <figure>
                            <img src="Images/star.png" class="imgEstrelaMedia"/>
                        </figure>
                    </div>
                    <section class="avaliacoes">
                        <div class="umaAvaliacao">
                            <div class="infosAvaliador">
                                <section class="infosNmAtDtAv">
                                     <figure>
                                    <img src="Images/perfil526ace.png" class="imgPerfilAvaliacao"/>
                                 </figure>
                                    <h4> Arthur Gomes </h4>
                                    <h5> @artoss </h5>
                                    <h6> 11 de janeiro </h6>
                                </section>
                                <div class="notaAvaliacao">
                                    <h4> 5 </h4>
                                    <h4> Estrelas </h4>
                                </div>
                            </div>
                            <div class="textoAvaliacao">
                                <p>A aula foi incrível e o professor é obviamente um homem muito sábio e inteligente. Aprendi muito e vou levar esses conhecimentos para a vida.</p>
                            </div>
                        </div>
                        <section class="suaAvaliacao">
                            <div class="suaNota">
                                <h4> Deixe uma nota sobre esse criador... </h4>
                                <asp:DropDownList ID="ddlEstrelas" runat="server">
                                    <asp:ListItem Text="Uma estrela" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Duas estrelas" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Três estrelas" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Quatro estrelas" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Cinco estrelas" Value="5"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="seuTexto">
                                <asp:TextBox ID="txtBoxAvaliacao" runat="server" mode="multiline" placeholder="Deixe aqui sua avaliação sobre esse criador..."></asp:TextBox>
                            </div>
                            <asp:Button ID="btnAvaliar" runat="server" Text="Enviar Avaliação" />
                        </section>
                    </section>
                </section>
            
        </main>
    </section>
    </form>
</body>
</html>
