﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura
{
    public partial class Index : System.Web.UI.Page
    {
        Filtro Filtro;
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;

        void HandleLogin()
        {
            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);
                dropbtnUsuario.Text = Login.Nome;
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litDropDownPerfil.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}&u={Login.Codigo}'>Perfil</a>";
                if (Login.Tipo == "Administrador")                                                              //Logado
                    litDropDownDenuncias.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";

                if (Login.Tipo == "Criador de Eventos")
                {
                    litDropDownDenuncias.Text = $"<a href='criar-evento.aspx?l={Login.Codigo}'>Criar Evento</a>";
                    litDropDownDenuncias.Text += $"<a href='meus-eventos.aspx?l={Login.Codigo}&u={Login.Codigo}'>Meus Eventos</a>";
                }
                dropbtnUsuario.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
                litLogoHeader.Text = $@"<a href='eventos.aspx?l={Login.Codigo}'>
                    <img src = 'Images/logoNomeMenor.png' class='logo-header'/>
                </a>";
            }
            else
            {
                dropbtnUsuario.Visible = false;
                btnLog.Visible = true;                                                                          //Deslogado
                btnCad.Visible = true;
                litLogoHeader.Text = $@"<a href='eventos.aspx'>
                    <img src = 'Images/logoNomeMenor.png' class='logo-header'/>
                </a>";
            }
        }

        List<Categoria> CategoriasSelecionadas
        {
            get => ViewState["CategoriasSelecionadas"] as List<Categoria>;
            set => ViewState["CategoriasSelecionadas"] = value;
        }

        private void PrintarEventos(List<Evento> Eventos, bool hidden)
        {
            foreach (Evento evento in Eventos)
            {
                Usuario usuarioEvento = ListaUsuario.Buscar(evento.Responsavel);
                List<Categoria> categorias = evento.Categorias;
                List<DiaEvento> dias = ListaEvento.BuscarDias(evento.Codigo);
                string imagem = ListaEvento.BuscarImagem(evento.Codigo)[0];
                string dia_inicial = dias[0].Data;
                string dia_final = dias[dias.Count - 1].Data;
                string tempo = dias[0].Inicio;

                string TagAEvento = $"<a href='evento.aspx?e={evento.Codigo}'>";
                string TagAPerfil = $"<a href='perfil.aspx?u={usuarioEvento.Codigo}'>";
                string ClassHidden = hidden ? "<section class='card hidden'>" : "<section class='card'>";

                if (Login != null)
                {
                    TagAEvento = $"<a href='evento.aspx?l={Login.Codigo}&e={evento.Codigo}'>";
                    TagAPerfil = $"<a href='perfil.aspx?l={Login.Codigo}&u={usuarioEvento.Codigo}'>";
                }

                litEventos.Text += $@"{ClassHidden}
                    <article class='card-header'>
                        <figure>
                            {TagAPerfil}
                                <img src='Images/perfil.png' alt='Imagem de Perfil' class='perfil'>
                            </a>
                        </figure>

                        <article class='card-header-nome'>
                            {TagAPerfil}
                                <h2>{usuarioEvento.Nome}</h2>
                                <h5>{usuarioEvento.Codigo}</h5>
                            </a>
                        </article>

                    </article>

                    {TagAEvento}
                        <article class='card-tittle'>
                                <h2>{evento.Titulo}</h2>
                        </article>
                    </a>

                    <article class='card-tags'>";




                foreach (Categoria categoria in categorias)
                    litEventos.Text += $@"<h2 class='tag'>{categoria.Nome}</h2>";





                litEventos.Text += $@"</article>

                    <article class='card-image'>
                        {TagAEvento}
                            <figure>
                                <img src='{imagem}' alt='Interclasse de cria' class='foto-evento'>
                            </figure>
                        </a>
                    </article>

                    <article class='card-dateTime dateTime'>
                        <article class='date'>
                            <figure>
                                <img src='Images/calendar.png' alt='Ícone calendário' class='calendar-icon'>
                            </figure>
                            <h3>{dia_inicial} a {dia_final}</h3>
                        </article>

                        <article class='time'>
                            <figure>
                                <img src='Images/time.png' alt='Ícone Tempo' class='time-icon'>
                            </figure>
                            {tempo}
                        </article>
                    </article>

                    <article class='card-local'>
                        <figure>
                            <img src='Images/local.png' alt='Ícone Local' class='local-icon'>
                        </figure>
                        <h3>{
                            evento.Local
                        }</h3>

                    </article>
                </section>";
            }
        }

        private void ListarEventos(string usuario)
        {

            litEventos.Text = "";

            List<Evento> Diff; // Eventos que não são da preferência do usuário
            List<Evento> Feed; // Eventos de preferência do usuário

            (Diff, Feed) = ListaEvento.GetDiffFeed(Login?.Codigo);

            Feed = Feed.FindAll((e) => Filtro.Verificar(e));
            Diff = Diff.FindAll((e) => Filtro.Verificar(e));

            litEventos.Text = "";
            PrintarEventos(Feed, false);
            PrintarEventos(Diff, Feed.Count > 0);
        }

        DateTime? StrinToDate(string strDate)
        {
            if (string.IsNullOrEmpty(strDate))
                return null;
            DateTime dt;
            DateTime.TryParse(strDate, out dt);
            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Categorias = ListaEvento.ListarCategorias();
                filtrosCategorias.DataSource = Categorias;
                filtrosCategorias.DataBind();
                if (CategoriasSelecionadas == null)
                    CategoriasSelecionadas = new List<Categoria>();
            }

            viewCategoriasSelecionadas.DataSource = CategoriasSelecionadas;
            viewCategoriasSelecionadas.DataBind();
            HandleLogin();
            Filtro = new Filtro();
            Filtro.Inicio = StrinToDate(dtStart.Text);
            Filtro.Fim = StrinToDate(dtEnd.Text);
            //Filtro.Nome = StrinToDate(txtBoxNome);
            if (int.TryParse(dpdAval.SelectedValue, out var qtEstrela))
                Filtro.QtEstrelas = qtEstrela;
            else
                Filtro.QtEstrelas = null;
            Filtro.Titulo = txtPesquisa.Text;
            Filtro.Categorias = CategoriasSelecionadas;

            ListarEventos(Login?.Codigo);

            LoadComplete += Page_Load;

        }

        protected void ClickCategoria(object sender, EventArgs e)
        {
            var Botao = (Button)sender;
            if (!int.TryParse(Botao.CommandArgument, out var codigoCategoria))
                return;
            if (CategoriasSelecionadas.Count < 3 && !CategoriasSelecionadas.Any(c => c.Codigo == codigoCategoria))
                CategoriasSelecionadas.Add(new Categoria(codigoCategoria, Botao.Text));


        }

        protected void ClickExcluirCategoria(object sender, EventArgs e)
        {
            var Botao = (Button)sender;
            if (!int.TryParse(Botao.CommandArgument, out var codigoCategoria))
                return;
            CategoriasSelecionadas.RemoveAll((c) => c.Codigo == codigoCategoria);
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Login = ListaUsuario.BuscarLogin(txtBoxUser.Text, txtBoxSenha.Text);

            if (Login != null)
                Response.Redirect($"eventos.aspx?l={Login.Codigo}");
            else
            {
                lblStatusLogin.Text = "Usuário e/ou senha inválidos!";
                txtBoxUser.Text = "";
                txtBoxSenha.Text = "";
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario Cadastrado = new Usuario(txtBoxNmUsuario.Text, ddlTipoUser.Text, ddlSexo.Text, txtBoxNome.Text + txtBoxSobrenome.Text, txtBoxEmail.Text, txtBoxSenhaCad.Text, " ", txtData.Text, null);

            ListaUsuario.CriarUsuario(Cadastrado);
        }

        protected void btnCadastrar_Click1(object sender, EventArgs e)
        {
            Usuario Cadastrado = new Usuario(txtBoxNmUsuario.Text, ddlTipoUser.Text, ddlSexo.Text, txtBoxNome.Text + txtBoxSobrenome.Text, txtBoxEmail.Text, txtBoxSenhaCad.Text, " ", txtData.Text, null);

            ListaUsuario.CriarUsuario(Cadastrado);
        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            dtStart.Text = "";
            dtEnd.Text = "";
            txtPesquisa.Text = "";
            dpdAval.SelectedIndex = 0;
            CategoriasSelecionadas.Clear();

        }
        protected string GetNomeCategoria(object categoria)
        {
            return (categoria as Categoria)?.Nome ?? "Bom dia";
        }
        protected int GetCodigoCategoria(object categoria)
        {
            return (categoria as Categoria)?.Codigo ?? 0;
        }
    }
}