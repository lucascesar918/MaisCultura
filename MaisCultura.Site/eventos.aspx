<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eventos.aspx.cs" Inherits="MaisCultura.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <script src="https://unpkg.com/scrollreveal@4"></script>

    <link rel="stylesheet" type="text/css" href="Styles/Index.css" />

    <title>+Cultura | Eventos</title>
</head>
<body>

    

    <form id="form1" runat="server">

        <div id="shade" class="shade"></div>
        <div id="shade2" class="shade"></div>

        <header class="header-primaria">
            <figure class="figure-header">
                <img src="Images/logoNomeMenor.png" class="logo-header"/>
            </figure>

            <article class="buttons">
                <asp:Button ID="btnLog" runat="server" Text="Entrar" class="button button-log" />
                <asp:Button ID="btnCad" runat="server" Text="Cadastrar" class="button button-cad" />
            </article>

            <article class="usuario">
                <div class="menuUsuario">
                    <asp:Button CssClass="dropbtn" ID="dropbtnUsuario" runat="server" Text="Nome" />
                    <div class="dropdown-content">
                    <asp:Literal ID="litDropDownHome" runat="server"></asp:Literal>  <%--Possível aplicar databinder--%>
                    <asp:Literal ID="litDropDownPerfil" runat="server"></asp:Literal>
                    <asp:Literal ID="litDropDownDenuncias" runat="server"></asp:Literal>
                    <a href="eventos.aspx">Sair</a>
                    </div>
                </div>
                <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                
            </article>
        </header>

        <header class="header header-secundaria">
            <article class="header-texto">
                <p class="p">
                    O
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
            <section id="localTags" class="section-tags">
            </section>

            <section class="section-limpar">
                <article ID="btnLimpar" class="button-clear">Limpar Filtros</article>
            </section>
        </div>

        <main class="principal">
            <div class="filtros">
                <h2 class="filtros-titulos">Categoria</h2>
                <article ID="CatPintura" class="filtros-subtitulos categoria">Pintura</article>
                <article ID="CatMusica" class="filtros-subtitulos categoria">Música</article>
                <article ID="CatEsporte" class="filtros-subtitulos categoria">Esporte</article>
                <article ID="CatCinema" class="filtros-subtitulos categoria">Cinema</article>
                <article ID="CatTeatro" class="filtros-subtitulos categoria">Teatro</article>
                <article ID="CatJogos" class="filtros-subtitulos categoria">Jogos</article>
                <article ID="CatRPG" class="filtros-subtitulos categoria">RPG</article>
                <asp:Button ID="btnVerMais" runat="server" Text="Ver mais categorias" class="filtros-subtitulos verMais"/>

                <br />

                <h2 class="filtros-titulos">Local</h2>
                <asp:TextBox ID="txtLocal" runat="server" CssClass="txtLocal" placeholder="Insira aqui a cidade..."></asp:TextBox>
                
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
                <section class="inputPesquisa">
                    <section class="txtIcon">
                        <asp:TextBox ID="txtPesquisa" runat="server" CssClass="txt txtPesquisa" placeHolder="O que você quer ver hoje?"></asp:TextBox>
                        <img src="Images/pesquisa.png" alt="Ícone pesquisa" class="icon" />
                    </section>
                </section>

                <hr />
                
                <div class="event-manager">
                    <div class="eventos">
                        <asp:Literal ID="litEventos" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </main>

        <div class="login pop" id="log">

            <section class="headerLogin">
                <h4 class="titleLogin">Entrar</h4>

            </section>

            <asp:TextBox ID="txtBoxUser" runat="server" placeholder="Seu nome de usuário" CssClass="txtLog"></asp:TextBox>

            <asp:TextBox ID="txtBoxSenha" runat="server" placeholder="Sua senha" CssClass="txtLog" type="password"></asp:TextBox>

            <asp:Button ID="btnLogar" runat="server" Text="Entrar" OnClick="btnLogar_Click" />
            <asp:Button ID="btnSairLogin" runat="server" Text="Fechar" />

        </div>

        <div class="cadastrar pop" id="cad">

            <section class="headerCad">
                <h4 class="titleCad">Cadastrar</h4>
            </section>

            <div class="nms">
                <asp:TextBox ID="txtBoxNome" runat="server" placeholder="Seu nome" CssClass="txtCadNm"></asp:TextBox>
                <asp:TextBox ID="txtBoxSobrenome" runat="server" placeholder="Seu sobrenome" CssClass="txtCadNm"></asp:TextBox>
            </div>

            <asp:TextBox ID="txtBoxEmail" runat="server" placeholder="Seu email" CssClass="txtCad"></asp:TextBox>

            <asp:TextBox ID="txtBoxNmUsuario" runat="server" placeholder="Seu nome de usuário" CssClass="txtCad"></asp:TextBox>

            <asp:TextBox ID="txtBoxSenhaCad" runat="server" placeholder="Sua senha" CssClass="txtCad"></asp:TextBox>

            <asp:DropDownList ID="ddlTipoUser" runat="server" CssClass="txtCad">
                <asp:ListItem runat="server" CssClass="listDdl" Value="Usuário Comum">
                    Usuário Comum
                </asp:ListItem>

                <asp:ListItem runat="server" CssClass="listDdl" Value="Criador de Eventos">
                    Criador de Eventos
                </asp:ListItem>

                <asp:ListItem runat="server" CssClass="listDdl" Value="Empresa">
                    Empresa
                </asp:ListItem> 
            </asp:DropDownList> 

            <div class="dtNasc">
                <asp:Label ID="lblNasc" runat="server" Text="Data de Nascimento"></asp:Label>

                <div class="ddlsDtNasc">

                    <asp:TextBox ID="txtData" runat="server" type="date"> CssClass="txtCadDt" ID="dia"</asp:TextBox>
                </div>          
            </div>
            
            <div class="sexo">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>

                <asp:DropDownList ID="ddlSexo" runat="server">
                    <asp:ListItem runat="server" CssClass="listDdl" Value="M">
                        Masculino
                    </asp:ListItem>

                    <asp:ListItem runat="server" CssClass="listDdl" Value="F">
                        Feminino
                    </asp:ListItem>

                    <asp:ListItem runat="server" CssClass="listDdl" Value="NO">
                        Desejo não informar
                    </asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click1"/>
            <asp:Button ID="btnSairCad" runat="server" Text="Fechar"/>
        </div>

        <div class="denuncia pop" id="denuncia">
            <div class="headerDenuncia">
                <h4>Relatar problema com o evento</h4>
            </div>

            <asp:Label ID="lblMotivo" runat="server" Text="Motivação"></asp:Label>

            <asp:DropDownList ID="ddlMotivos" runat="server">
                <asp:ListItem runat="server">Má organização</asp:ListItem>
                <asp:ListItem runat="server">Má localização</asp:ListItem>
                <asp:ListItem runat="server">Local inapropriado</asp:ListItem>
                <asp:ListItem runat="server">Promessa não cumprida</asp:ListItem>
                <asp:ListItem runat="server">Falta de segurança</asp:ListItem>
                <asp:ListItem runat="server">Fraude</asp:ListItem>
                <asp:ListItem runat="server">Outros</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="lblDesc" runat="server" Text="Descrição do problema"></asp:Label>

            <asp:TextBox ID="txtBoxDescProb" runat="server" mode="multiline" placeholder="Escreva aqui a descrição do problema que você encontrou."></asp:TextBox>

            <asp:Button ID="btnDenunciar" runat="server" Text="Enviar reclamação" />
            <asp:Button ID="btnSairDenuncia" runat="server" Text="Fechar" />
        </div>
    </form>
    
    <script type="text/javascript" src="js/eventos.js"></script>
    <script type="text/javascript" src="js/save.js"></script>
    <script type="text/javascript" src="js/CadastroLogin.js"></script>

    <script>

        ScrollReveal({
            distance: '60px',
            duration: 1000,
            delay: 400
        });

        ScrollReveal().reveal('.card', { reset: true,delay: 200 ,interval: 50 });
        ScrollReveal().reveal('.grafismo-header', { delay: 100, origin: 'right' })
        ScrollReveal().reveal('.p', { delay: 100, origin: 'right' });
</script>

</body>
</html>