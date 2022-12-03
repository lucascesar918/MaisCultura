<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="MaisCultura.Site.perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <link rel="stylesheet" type="text/css" href="Styles/PerfilOutroUsuario.css" />

    <title> +Cultura | <asp:Literal ID="litTittle" runat="server"></asp:Literal> </title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="shade" class="shade"></div>
        <div id="shade2" class="shade"></div>

        <header class="header-primaria">
            <figure class="figure-header">
                <asp:Literal ID="litLogo" runat="server"></asp:Literal>
                    <img src="Images/logoNomeMenor.png" class="logo-header" />
                </a>
            </figure>

            <article class="buttons">
                <asp:Button ID="btnLog" runat="server" Text="Entrar" class="button button-log" />
                <asp:Button ID="btnCad" runat="server" Text="Cadastrar" class="button button-cad" />
            </article>

            <article class="usuario">
                <div class="menuUsuario">
                    <asp:Literal ID="litUsuario" runat="server"></asp:Literal>

                    <div class="dropdown-content">
                        <asp:Literal ID="litHome" runat="server"></asp:Literal>
                        <asp:Literal ID="litPerfil" runat="server"></asp:Literal>
                        <asp:Literal ID="litAdicionais" runat="server"></asp:Literal>
                        <asp:Literal ID="litSair" runat="server"></asp:Literal>
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
                        
                    </section>
                </section> 

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
            </main>
        </section>
    </form>

    <script type="text/javascript" src="js/CadastroLogin.js"></script>
</body>
</html>
