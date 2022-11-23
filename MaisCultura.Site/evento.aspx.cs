using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura.Site
{
    public partial class EventoEspecifico : System.Web.UI.Page
    {
   

        protected void btnInteresse_Click(object sender, EventArgs e)
        {
            if (btnInteresse.CssClass.Contains("naoInt"))   
            {
                btnInteresse.CssClass = "Int";
                btnInteresse.Text = "Interesse Demonstrado";
            }
            else
            {
                btnInteresse.CssClass = "naoInt";
                btnInteresse.Text = "Demonstrar Interesse";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.CssClass.Contains("naoSalvo"))
            {
                btnSave.CssClass = "save salvo";
            }
            else
            {
                btnSave.CssClass = "save naoSalvo";
            }
        }
        ListaEvento ListaEvento = new ListaEvento();
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaDenuncia ListaDenuncia = new ListaDenuncia();
        ListaAvaliacao ListaAvaliacao = new ListaAvaliacao();

        Usuario Login;
        Evento Evento;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);      //Logado
                dropbtnUsuario.Text = Login.Nome;
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litDropDownPerfil.Text = $"<a href='perfil.aspx?l={Login.Codigo}'>Perfil</a>";
                dropbtnUsuario.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
            }
            else
            {
                dropbtnUsuario.Visible = false;                             //Deslogado
                btnLog.Visible = true;
                btnCad.Visible = true;
            }

            if (Request.QueryString["e"] != null)
            {
                Evento = ListaEvento.Buscar(Int32.Parse(Request.QueryString["e"]));
            }

            if (Evento != null)
            {
                lblTituloEvento.Text = Evento.Titulo;
                lblLocalEvento.Text = Evento.Local;
                lblDescEvento.Text = Evento.Descricao;
                titleResponsavel.Text = ListaUsuario.Buscar(Evento.Responsavel).Nome;
                lblArroba.Text = '@'+Evento.Responsavel;
                lblNotaResp.Text = ListaUsuario.BuscarMediaCriador(Evento.Responsavel).ToString();
                lblNmrInteresse.Text = ListaEvento.BuscarInteresses(Evento.Codigo).ToString();
                litData.Text = Evento.Dias[0].Data.ToShortDateString();
                litHrInicio.Text = Evento.Dias[0].Inicio.ToShortTimeString();
                litHrFim.Text = Evento.Dias[0].Fim.ToShortTimeString();

                List<String> imagens = new List<String>();
                imagens = ListaEvento.BuscarImagem(Evento.Codigo);

                string CarrouselTarget = "";
                string CarrouselImages = "";

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
    }
}