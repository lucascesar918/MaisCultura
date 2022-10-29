<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="MaisCultura.perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/PerfildoUsuario.css" />

    <title> +Cultura | Perfil </title>
</head>
<body>
    <form id="form1" runat="server">
       <header class="header header-primaria">
            <figure class="figure-header">
                <img src="Images/logoNomeMenor.png" class="logo-header"/>
            </figure>

            <article class="usuario">
                <div class="menuUsuario">
                    <asp:Button CssClass="dropbtn" ID="dropbtnUsuario" runat="server" Text="Nome" />
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
        <section class="all">
        <main>
            <section class="user">
                <div class="perfilUsuario">
                    <figure>
                        <img src="Images/perfil526ace.png" class="imgperfilUser"/>
                    </figure>
                    <article class="nmUser">
                        <asp:Label CssClass="nmCompleto" ID="lblNomeUsuario" runat="server" Text="Nome Completo"></asp:Label>
                        <div class="userTUsuario">
                            <asp:Label CssClass="arroba" ID="lblArroba" runat="server" Text="@arroba"></asp:Label>
                            <div class="tipoUsuario"> <asp:Label ID="lblTipo" runat="server" Text="Tipo Usuário"></asp:Label> </div>
                        </div>
                    </article>
                </div>
                
                <div class="infosUsuario">
                    <h3 class="tituloDados">DADOS PESSOAIS</h3>
                   <section class="informacoes">
                       <%--<div class="divInfo">
                           <h3 class="title">NOME</h3>
                           <p class="item"> João Carlos Tavares Szegh Ferreira</p>
                       </div>
                       <div class="divInfo">
                           <h3 class="title">USUÁRIO</h3>
                           <p class="item"> @jcarlos</p>
                       </div>--%>
                       <div class="divInfo">
                           <h3 class="title">EMAIL</h3>
                           <asp:Label CssClass="item" ID="lblEmail" runat="server" Text="email@email.com"></asp:Label>
                       </div>
                       <div class="divInfo">
                           <h3 class="title">NASCIMENTO</h3>
                           <asp:Label CssClass="item" ID="lblNascimento" runat="server" Text="00/00/0000"></asp:Label>
                       </div>
                       <div class="divInfo">
                           <h3 class="title">SEXO</h3>
                           <asp:Label CssClass="item" ID="lblSexo" runat="server" Text="Não Informado"></asp:Label>
                       </div>
                       <div class="divInfo">
                           <h3 class="title">SENHA</h3>
                           <button id="alteraSenha" class="item"> Alterar senha </button>
                       </div>
                   </section>
                </div>
                <div class="interessesEsalvos">
                    <div class="botoes">
                    <asp:Button ID="btnInteresse" runat="server" Text="Interesses" CssClass="titleInteresse"/>
                       
                    <asp:Button ID="btnSalvos" runat="server" Text="Salvos" CssClass="titleSalvos"/>
                    </div>
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
                
            </section>

            <section class="preferencias">
                <div class="prefs">
                <h3> Preferências </h3>
                <nav>
                    <ul>
                        <asp:Literal ID="litPrefs" runat="server"></asp:Literal>
                    </ul>
                </nav>
                <button id="btnEditarPreferencias" onclick="abrirEditPref()"> Editar preferências </button>
                <!-- <asp:Button ID="btnEditarPreferencias" runat="server" Text="Editar Preferências" /> -->
               </div>
               <button id="btnExcluirConta"> Excluir conta </button>
                <!-- <asp:Button ID="btnExcluirConta" runat="server" Text="Excluir conta" /> -->
            </section>
            
        </main>
            </section>

    <div id="boxExcluir" style="display: none; box-shadow: 5px 5px 8px black; position: fixed">

        <h3 class="h3"> Você tem certeza que deseja excluir sua conta? </h3>
        <div class="boxBtn">
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir Conta" CssClass="btnBox"/>
            <asp:Button ID="cancelarExcluir" runat="server" Text="Cancelar" CssClass="btnBox"/>
        </div>

    </div>

    <div id="box" class="hidden">

        <h3 class="h3"> Editar Preferências </h3>
        <!-- depois eu penso nessa merda -->
            <h3 class="h3Edit"> Preferências </h3>
            <nav>
                <ul class="ulEdit">
                    <li> Pintura  X</li>
                    <li> Jogos  X</li>
                    <li> RPG  X</li>
                    <li> Underground  X</li>
                    <li> Muay Thai  X</li>
                    <li> Teatro  X</li>
                </ul>
            </nav>
            <button id="editar" class="editar"> Editar </button>
       

    </div>

    <div id="boxSenha" style="display: none; box-shadow: 5px 5px 8px black; position: fixed;">

        <button id="sumirPopupSenha" style="position: relative; top: 0px; right: 0px; align-self: flex-end; width: 20px; height: 30px;">X</button>

        <h3 class="h3"> Alterar Senha</h3>

        <asp:TextBox CssClass="inputSenha" ID="txtSenhaAntiga" placeholder="Senha antiga" runat="server"></asp:TextBox>
        <asp:TextBox CssClass="inputSenha" ID="txtSenhaNova" placeholder="Senha nova" runat="server"></asp:TextBox>
        <asp:Button CssClass="btnSenha" ID="btnSenha" runat="server" Text="Alterar" OnClick="btnSenha_Click" />
    </div>
      
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <script>

        $("#alteraSenha").click(function (e) {
            e.preventDefault();
            $("#boxSenha").toggle();
        });

        $("#sumirPopupSenha").click(function (e) {
            e.preventDefault();
            $("#boxSenha").toggle();
        });

        $("#btnExcluirConta").click(function (e) {
            e.preventDefault();
            $("#boxExcluir").toggle();
        });

        $("#cancelarExcluir").click(function (e) {
            e.preventDefault();
            $("#boxExcluir").toggle();
        });



        //const divExcluir = document.getElementById("boxExcluir")

        //const btnExcluir = document.getElementById("btnExcluirConta")

        //const btnCancelar = document.getElementById("cancelarExcluir")

        //const btnEditPref = document.getElementById("btnEditarPreferencias")

        //const divEditPref = document.getElementById("box")

        //const divalteraSenha = document.getElementById("boxSenha")

        //const btnAlteraSenha = document.getElementById("alteraSenha")

        //function abrirExcluirConta(e)
        // {
        //    e.preventDefault()
        //    divExcluir.classList.toggle("hidden")

        //    // divExcluir.classList.remove("hidden")
        //}

        //function abrirEditPref(e)
        //{
        //    // divEditPref.classList.toggle("hidden")
        //    // e.preventDefault()

        //    e.preventDefault()
        //    divEditPref.classList.remove("hidden")
        //}

        //function boxalterarSenha(e)
        //{
        ////  divalteraSenha.classList.toggle("hidden")
        ////  e.preventDefault();

        //    e.preventDefault()
        //    divalteraSenha.classList.remove("hidden")
        //}



    </script>
</body>
</html>
