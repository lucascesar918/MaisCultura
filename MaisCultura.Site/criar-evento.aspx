<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criar-evento.aspx.cs" Inherits="MaisCultura.Site.CriarEvento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="Styles/CriarEvento.css" />
    <title>+Cultura | Criar Evento </title>
</head>

<body>
    <form id="form1" runat="server">
        <header class="header header-primaria">
            <figure class="figure-header">
                <a href="eventos.aspx">
                <img src="Images/logoNomeMenor.png" class="logo-header" />
                    </a>
            </figure>

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
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar"
                OnClientClick="JavaScript:window.history.back(1); return false;" />
        </section>

        <section class="all">
            <main>
                <section class="divTitle">
                    <h2 class="h2">Criar Evento </h2>
                </section>

                <section class="infos">
                    <div class="txts">
                        <div class="tituloEvento">
                            <asp:Label ID="Label5" runat="server" Text="Título:" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtTituloEvento" runat="server"
                                placeholder="Insira aqui o título do evento" CssClass="txtBox"></asp:TextBox>
                        </div>

                        <div class="local">
                            <asp:Label ID="Label4" runat="server" Text="UF:" CssClass="label"></asp:Label>

                            <asp:DropDownList ID="ddlUF" runat="server" CssClass="txtBox">
                                <asp:ListItem id="ListItem12" runat="server" Text="AC"></asp:ListItem>
                                <asp:ListItem id="ListItem13" runat="server" Text="AL"></asp:ListItem>
                                <asp:ListItem id="ListItem14" runat="server" Text="AP"></asp:ListItem>
                                <asp:ListItem id="ListItem15" runat="server" Text="AM"></asp:ListItem>
                                <asp:ListItem id="ListItem16" runat="server" Text="BA"></asp:ListItem>
                                <asp:ListItem id="ListItem17" runat="server" Text="CE"></asp:ListItem>
                                <asp:ListItem id="ListItem18" runat="server" Text="DF"></asp:ListItem>
                                <asp:ListItem id="ListItem19" runat="server" Text="ES"></asp:ListItem>
                                <asp:ListItem id="ListItem20" runat="server" Text="GO"></asp:ListItem>
                                <asp:ListItem id="ListItem21" runat="server" Text="MA"></asp:ListItem>
                                <asp:ListItem id="ListItem22" runat="server" Text="MT"></asp:ListItem>
                                <asp:ListItem id="ListItem23" runat="server" Text="MS"></asp:ListItem>
                                <asp:ListItem id="ListItem24" runat="server" Text="MG"></asp:ListItem>
                                <asp:ListItem id="ListItem25" runat="server" Text="PA"></asp:ListItem>
                                <asp:ListItem id="ListItem26" runat="server" Text="PB"></asp:ListItem>
                                <asp:ListItem id="ListItem27" runat="server" Text="PR"></asp:ListItem>
                                <asp:ListItem id="ListItem28" runat="server" Text="PB"></asp:ListItem>
                                <asp:ListItem id="ListItem29" runat="server" Text="PI"></asp:ListItem>
                                <asp:ListItem id="ListItem30" runat="server" Text="RJ"></asp:ListItem>
                                <asp:ListItem id="ListItem31" runat="server" Text="RN"></asp:ListItem>
                                <asp:ListItem id="ListItem32" runat="server" Text="RS"></asp:ListItem>
                                <asp:ListItem id="ListItem33" runat="server" Text="RO"></asp:ListItem>
                                <asp:ListItem id="ListItem34" runat="server" Text="RR"></asp:ListItem>
                                <asp:ListItem id="ListItem35" runat="server" Text="SC"></asp:ListItem>
                                <asp:ListItem id="ListItem36" runat="server" Text="SP"></asp:ListItem>
                                <asp:ListItem id="ListItem37" runat="server" Text="SE"></asp:ListItem>
                                <asp:ListItem id="ListItem38" runat="server" Text="TO"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:Label ID="Label3" runat="server" Text="Local:" CssClass="label"></asp:Label>

                            <asp:TextBox ID="txtCidade" runat="server" CssClass="txtBox"
                                placeholder="Insira aqui o nome da cidade"></asp:TextBox>

                            <asp:TextBox ID="txtEndereco" runat="server"
                                placeholder="Insira aqui o endereço do evento" CssClass="txtBox"></asp:TextBox>


                        </div>
                        <div class="divDts">
                            <div class="divDtHr">
                                <asp:Label ID="Label1" runat="server" Text="Data:" CssClass="label"></asp:Label>
                                <asp:TextBox ID="txtDtInicio" type="date" runat="server" CssClass="txtBoxDtHr"></asp:TextBox>

                                <asp:Label ID="Label6" runat="server" Text="Início:" CssClass="label"></asp:Label>
                                <asp:TextBox ID="txtHrInicio" type="time" runat="server" CssClass="txtBoxDtHr"></asp:TextBox>

                                <asp:Label ID="Label2" runat="server" Text="Fim:" CssClass="label"></asp:Label>
                                <asp:TextBox ID="txtHrFim" type="time" runat="server" CssClass="txtBoxDtHr"></asp:TextBox>

                                <asp:Button ID="btnAdicionarDtHr" runat="server" Text="+" OnClick="btnAdicionarDtHr_Click" />
                                <asp:Button ID="btnRemoverDtHr" runat="server" Text="-" OnClick="btnRemoverDtHr_Click" />

                            </div>

                            <asp:ListBox ID="listBoxDtHr" runat="server" CssClass="listBox"></asp:ListBox>
                        </div>

                        <div class="outrosInfoEvento">
                            <asp:TextBox ID="txtLinkImg" runat="server" CssClass="txtBox"
                                placeholder="Insira aqui o link da imagem do evento"></asp:TextBox>

                            <asp:TextBox ID="txtBoxDescricao" runat="server" mode="multiline"
                                placeholder="Insira aqui a descrição do evento"></asp:TextBox>

                            <asp:Button ID="btnAddEvento" runat="server" Text="Finalizar Criação" OnClick="btnAddEvento_Click" />
                        </div>
                    </div>

                    <div class="addCategs">
                        <div class="categs">
                            <asp:DropDownList ID="ddlCategs" runat="server"></asp:DropDownList>

                            <asp:Button ID="btnAddCateg" runat="server" Text="+" OnClick="btnAddCateg_Click" />
                            <asp:Button ID="btnRmCateg" runat="server" Text="-" OnClick="btnRmCateg_Click"/>
                        </div>

                        <asp:ListBox ID="listBoxCateg" runat="server" CssClass="listBox" Rows="3"></asp:ListBox>
                        <asp:Label ID="lblStatusListBox" runat="server"></asp:Label>
                    </div>
                </section>
            </main>
        </section>
    </form>
</body>

</html>
