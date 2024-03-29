﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura.Site
{
    public partial class perfil : System.Web.UI.Page
    {
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();
        ListaAvaliacao ListaAvaliacao = new ListaAvaliacao();

        Usuario Login;
        Usuario Usuario;

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
                pnlAval.Visible = true;
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
                pnlAval.Visible = false;
                dropbtnUsuario.Visible = false;
                btnLog.Visible = true;                                                                          //Deslogado
                btnCad.Visible = true;
                litLogoHeader.Text = $@"<a href='eventos.aspx'>
                    <img src = 'Images/logoNomeMenor.png' class='logo-header'/>
                </a>";
            }
        }

        void HandleUser()
        {
            Usuario = ListaUsuario.Buscar(Request.QueryString["u"]);

            if (Usuario == null)
                Response.Redirect($"erro.html?msg=Tá vendo coisa? Esse usuário não existe!" + (Login == null ? "" : $"&l={Login.Codigo}"));

            lblNmCompleto.Text = Usuario.Nome;
            lblArroba.Text = Usuario.Codigo;
            lblTUser.Text = Usuario.Tipo;
            litTittle.Text = Usuario.Nome;
        }

        void CreateEvents(string codigo)
        {
            litEventosCria.Text = "";

            List<Evento> eventos = new List<Evento>();

            eventos = ListaEvento.BuscarPorUsuario(codigo);

            string todosEventos = "";

            foreach (Evento evento in eventos)
            {
                Usuario usuarioEvento = ListaUsuario.Buscar(evento.Responsavel);
                List<Categoria> categorias = evento.Categorias;
                List<DiaEvento> dias = evento.Dias;

                var TagA = $"<a href='evento.aspx?e={evento.Codigo}'>";

                if (Request.QueryString["l"] != null)
                    TagA = $"<a href='evento.aspx?l={Login.Codigo}&e={evento.Codigo}'>";

                todosEventos += $@"<section class='card'>
                    <article class='card-header'>
                        <figure>
                            <img src='Images/perfil.png' alt='Imagem de Perfil' class='perfil'>
                        </figure>

                        <article class='card-header-nome'>
                            <h2>{usuarioEvento.Nome}</h2>
                            <h5>{usuarioEvento.Codigo}</h5>
                        </article>

                    </article>

                    {TagA}
                        <article class='card-tittle'>
                                <h2>{evento.Titulo}</h2>
                        </article>
                    </a>

                    <article class='card-tags'>";
                foreach (Categoria categoria in categorias)
                    todosEventos += $@"<h2 class='tag'>{categoria.Nome}</h2>
                    </article>

                    <article class='card-image'>
                        {TagA}
                            <figure>
                                <img src='{ListaEvento.BuscarImagem(evento.Codigo)[0]}' alt='Interclasse de cria' class='foto-evento'>
                            </figure>
                        </a>
                    </article>

                    <article class='card-dateTime dateTime'>
                        <article class='date'>
                            <figure>
                                <img src='Images/calendar.png' alt='Ícone calendário' class='calendar-icon'>
                            </figure>
                            <h3>{dias[0].Data} a {dias[dias.Count - 1].Data}</h3>
                        </article>

                        <article class='time'>
                            <figure>
                                <img src='Images/time.png' alt='Ícone Tempo' class='time-icon'>
                            </figure>
                            {dias[0].Inicio}
                        </article>
                    </article>

                    <article class='card-local'>
                        <figure>
                            <img src='Images/local.png' alt='Ícone Local' class='local-icon'>
                        </figure>
                        <h3>{evento.Local // Trocar pelo formato "Cidade, Estado" depois
                        }</h3>

                    </article>
                </section>";

                foreach (Avaliacao avaliacao in ListaAvaliacao.BuscarPorEvento(evento.Codigo))
                {
                    litAvaliacoes.Text += $@"<div class='umaAvaliacao'>
                                <div class='infosAvaliador'>
                                    <section class='infosNmAtDtAv'>
                                        <figure>
                                            <img src='Images/perfil526ace.png' class='imgPerfilAvaliacao' />
                                        </figure>
                                        <span class='userAval'>{avaliacao.CodigoUsuario}</span>
                                    </section>
                                    <div class='notaAvaliacao'>
                                        <span>{avaliacao.Estrelas}</span>
                                        <figure>
                                            <img src='Images/star.png' class='imgEstrelaMedia' />
                                        </figure>
                                    </div>
                                </div>
                                <div class='textoAvaliacao'>
                                    <span>{avaliacao.Descricao}</span>
                                </div>
                            </div>";
                }
            }

            litEventosCria.Text += $@"
                <section class='eventosCriador' id='eventosCria'>
                    <h2 class='h2'> Eventos do Criador </h2>

                    <section class='feedEventos'>
                        {todosEventos}
                    </section>
                </section>";
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            HandleLogin();
            HandleUser();
            CreateEvents(Usuario.Codigo);
            txtBoxAvaliacao.TextMode = TextBoxMode.MultiLine;
        }
    }
}