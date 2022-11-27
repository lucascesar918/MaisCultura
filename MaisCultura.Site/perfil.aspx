<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="MaisCultura.Site.perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/PerfilOutroUsuario.css" />

    <title> +Cultura | <asp:Literal ID="litTittle" runat="server"></asp:Literal> </title>
</head>
<body>
    <form id="form1" runat="server">

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
                    <asp:Literal ID="litDropDownHome" runat="server"></asp:Literal>
                    <asp:Literal ID="litDropDownPerfil" runat="server"></asp:Literal>
                    <asp:Literal ID="litDropDownDenuncias" runat="server"></asp:Literal>
                    <a href="eventos.aspx">Sair</a>
                    </div>
                </div>
                <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                
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
                        <asp:Label ID="lblNmCompleto" runat="server" CssClass="nmCompleto"></asp:Label>

                        <div class="userTUsuario">
                            <asp:Label ID="lblArroba" runat="server" CssClass="arroba"></asp:Label>
                            <div class="tipoUsuario"> 
                                <asp:Label ID="lblTUser" runat="server"></asp:Label> 
                            </div>
                        </div>
                    </article>
                </section>

                <asp:Literal ID="litEventosCria" runat="server"></asp:Literal>

                <section class="avaliacaodoCriador">
                    <h2 class="h2"> Avaliações do Criador </h2>

                    <div class="nmrMedia">
                        <h3 style="font-size: 18px; margin: 10px;"> Média </h3>

                        <asp:Label ID="lblMedia" runat="server" Text="4,5" CssClass="lblMedia"></asp:Label>

                        <figure>
                            <img src="Images/star.png" class="imgEstrelaMedia"/>
                        </figure>
                    </div>

                    <section class="avaliacoes">
                        
                        <asp:Literal ID="litAvaliacoes" runat="server"></asp:Literal>
                        
                        <asp:Panel ID="pnlAval" runat="server">
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
                        </asp:Panel>
                        
                    </section>
                </section> 
            </main>
        </section>
    </form>
</body>
</html>
