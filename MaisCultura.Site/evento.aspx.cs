﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;
using System.Web.Services;

namespace MaisCultura.Site
{
    public partial class EventoEspecifico : System.Web.UI.Page
    {
        ListaEvento ListaEvento = new ListaEvento();
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaDenuncia ListaDenuncia = new ListaDenuncia();
        ListaAvaliacao ListaAvaliacao = new ListaAvaliacao();

        Usuario Login;
        Evento Evento;

        [WebMethod]
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
                pnlAval.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
                bool save = ListaEvento.VerificarSalvo(Login.Codigo, int.Parse(Request.QueryString["e"]));
                cbxSave.Checked = save;
                litLogoHeader.Text = $@"<a href='eventos.aspx?l={Login.Codigo}'>
                    <img src = 'Images/logoNomeMenor.png' class='logo-header'/>
                </a>";
            }
            else
            {
                dropbtnUsuario.Visible = false;
                pnlAval.Visible = false;
                btnLog.Visible = true;                                                                          //Deslogado
                btnCad.Visible = true;
                litLogoHeader.Text = $@"<a href='eventos.aspx'>
                    <img src = 'Images/logoNomeMenor.png' class='logo-header'/>
                </a>";
            }
        }

        public static void salvarEvento(string codigoUsuario, int codigoEvento)
        {
            ListaEvento ListaEvento = new ListaEvento();
            ListaEvento.Salvar(codigoUsuario, codigoEvento);
        }

        [WebMethod]
        public static void removerSalvo(string codigoUsuario, int codigoEvento)
        {
            ListaEvento ListaEvento = new ListaEvento();
            ListaEvento.CancelarSalvo(codigoUsuario, codigoEvento);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtBoxAvaliacao.TextMode = TextBoxMode.MultiLine;
            txtBoxDescProb.TextMode = TextBoxMode.MultiLine;

            HandleLogin();

            litCategorias.Text = "";

            if (Request.QueryString["e"] != null)
            {
                Evento = ListaEvento.Buscar(Int32.Parse(Request.QueryString["e"]));
            }

            if (Evento != null)
            {
                litTitle.Text = Evento.Titulo;
                lblTituloEvento.Text = Evento.Titulo;
                lblLocalEvento.Text = Evento.Local;
                lblDescEvento.Text = Evento.Descricao;
                titleResponsavel.Text = ListaUsuario.Buscar(Evento.Responsavel).Nome;
                lblArroba.Text = '@'+Evento.Responsavel;
                lblNotaResp.Text = ListaUsuario.BuscarMediaCriador(Evento.Responsavel).ToString();
                lblNmrInteresse.Text = ListaEvento.BuscarInteresses(Evento.Codigo).ToString();
                litData.Text = Evento.Dias[0].Data;
                litHrInicio.Text = Evento.Dias[0].Inicio;
                litHrFim.Text = Evento.Dias[0].Fim;

                List<String> imagens = new List<String>();

                imagens = ListaEvento.BuscarImagem(Evento.Codigo);

                Usuario usuarioEvento = ListaUsuario.Buscar(Evento.Responsavel);

                string CarrouselTarget = "";
                string CarrouselImages = "";

                var TagAPerfil = $"<a href='perfil.aspx?u={usuarioEvento.Codigo}'>";

                if (Request.QueryString["l"] != null)
                {
                    TagAPerfil = $"<a href='perfil.aspx?l={Login.Codigo}&u={usuarioEvento.Codigo}'>";
                }

                litPerfilImage.Text = TagAPerfil;
                litPerfilNome.Text = TagAPerfil;

                for (int i = 0; i < imagens.Count; i++)
                {
                    if (i == 0){
                        CarrouselImages += $@"
                        <div class='carousel-item active'>
                              <img class='d-block w-100' src='{imagens[0]}' alt='Slide'>
                        </div>";
                        CarrouselTarget = $"<li data-target='#carouselExampleIndicators' data-slide-to='0' class='active'></li>";
                    }
                    else
                    {
                        CarrouselImages += $@"
                        <div class='carousel-item'>
                              <img class='d-block w-100' src='{imagens[i]}' alt='Slide'>
                        </div>";
                        CarrouselTarget += $"<li data-target='#carouselExampleIndicators' data-slide-to='{i}'></li>";
                    }
                }

                if (imagens.Count == 1)
                {
                    litCarrousel.Text = $@"
                    <div id='carouselExampleSlidesOnly' class='carousel slide' data-ride='carousel'>
                        <div class='carousel-inner'>
                            {CarrouselImages}
                        </div>
                    </div>";
                }
                else
                {
                    litCarrousel.Text = $@"
                    <div id='carouselExampleIndicators' class='carousel slide' data-ride='carousel'>
                        <ol class='carousel-indicators'>
                            {CarrouselTarget}
                        </ol>
                        <div class='carousel-inner'>
                            {CarrouselImages}
                        </div>
                        <a class='carousel-control-prev' href='#carouselExampleIndicators' role='button' data-slide='prev'>
                            <span class='carousel-control-prev-icon' aria-hidden='true'></span>
                            <span class='sr-only'>Previous</span>
                        </a>
                        <a class='carousel-control-next' href='#carouselExampleIndicators' role='button' data-slide='next'>
                            <span class='carousel-control-next-icon' aria-hidden='true'></span>
                            <span class='sr-only'>Next</span>
                        </a>
                    </div>";
                }

                foreach (Categoria categoria in Evento.Categorias)
                    litCategorias.Text += $"<span class='ag'>{categoria.Nome}</span>";
                
                foreach (Avaliacao avaliacao in ListaAvaliacao.BuscarPorEvento(Evento.Codigo))
                    litAvaliacoes.Text += $@"<div class='umaAvaliacao'>
                                <div class='infosAvaliador'>
                                    <section class='infosNmAtDtAv'>
                                        <figure>
                                            <img src='Images/perfil526ace.png' class='imgPerfilAvaliacao' />
                                        </figure>
                                        <span>{avaliacao.CodigoUsuario}</span>
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

        protected void btnLog_Click(object sender, EventArgs e)
        {
            Login = ListaUsuario.BuscarLogin(txtBoxUser.Text, txtBoxSenha.Text);

            if (Login != null)
                Response.Redirect($"evento.aspx?l={Login.Codigo}&e={Evento.Codigo}");
            else
            {
                lblStatusLogin.Text = "Usuário e/ou senha inválidos!";
                txtBoxUser.Text = "";
                txtBoxSenha.Text = "";
            }
        }

        protected void btnCad_Click(object sender, EventArgs e)
        {
            Usuario Cadastrado = new Usuario(txtBoxNmUsuario.Text, ddlTipoUser.Text, ddlSexo.Text, txtBoxNome.Text + txtBoxSobrenome.Text, txtBoxEmail.Text, txtBoxSenhaCad.Text, " ", txtData.Text, null);

            ListaUsuario.CriarUsuario(Cadastrado);
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario Cadastrado = new Usuario(txtBoxNmUsuario.Text, ddlTipoUser.Text, ddlSexo.Text, txtBoxNome.Text + txtBoxSobrenome.Text, txtBoxEmail.Text, txtBoxSenhaCad.Text, " ", txtData.Text, null);

            ListaUsuario.CriarUsuario(Cadastrado);
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Login = ListaUsuario.BuscarLogin(txtBoxUser.Text, txtBoxSenha.Text);

            if (Login != null)
                Response.Redirect($"evento.aspx?l={Login.Codigo}&e={Evento.Codigo}");
            else
            {
                lblStatusLogin.Text = "Usuário e/ou senha inválidos!";
                txtBoxUser.Text = "";
                txtBoxSenha.Text = "";
            }
        }
    }
}