using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;
using System.Web.Services;
using MySql.Data.MySqlClient;

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

        [WebMethod]
        public static void DemonstrarInteresse(string codigoUsuario, int codigoEvento)
        {
            ListaEvento ListaEvento = new ListaEvento();
            ListaEvento.Interessar(codigoUsuario, codigoEvento);
        }

        [WebMethod]
        public static void RemoverInteresse(string codigoUsuario, int codigoEvento)
        {
            ListaEvento ListaEvento = new ListaEvento();
            ListaEvento.CancelarInteresse(codigoUsuario, codigoEvento);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtBoxAvaliacao.TextMode = TextBoxMode.MultiLine;
            txtBoxDescProb.TextMode = TextBoxMode.MultiLine;

            litCategorias.Text = "";

            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);      //Logado
                litUsuario.Text = Login.Nome;
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litDropDownPerfil.Text = $"<a href='perfil.aspx?l={Login.Codigo}'>Perfil</a>";
                litUsuario.Visible = true;
                pnlAval.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
                bool save = ListaEvento.VerificarSalvo(Login.Codigo, int.Parse(Request.QueryString["e"]));
                cbxSave.Checked = save;

                verificarAvalicao();
            }
            else
            {
                litUsuario.Visible = false;                             //Deslogado
                pnlAval.Visible = false;
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
                lblArroba.Text = '@' + Evento.Responsavel;
                lblNotaResp.Text = ListaUsuario.BuscarMediaCriador(Evento.Responsavel).ToString();
                litNmrInteresse.Text = ListaEvento.BuscarInteresses(Evento.Codigo).ToString();
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
                    if (i == 0)
                    {
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
                    litCategorias.Text += $"<span class='tag'>{categoria.Nome}</span>";

                litAvaliacoes.Text = "";

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

                PreencherDdlMotivos();
            }
        }

        void colocarEstrelas (int numero){
            switch (numero)
            {
                case 1:
                    umaEstrela.ImageUrl = "~/Images/star.png";
                    duasEstrelas.ImageUrl = "~/Images/star2.png";
                    tresEstrelas.ImageUrl = "~/Images/star2.png";
                    quatroEstrelas.ImageUrl = "~/Images/star2.png";
                    cincoEstrelas.ImageUrl = "~/Images/star2.png";
                    break;
                case 2:
                    umaEstrela.ImageUrl = "~/Images/star.png";
                    duasEstrelas.ImageUrl = "~/Images/star.png";
                    tresEstrelas.ImageUrl = "~/Images/star2.png";
                    quatroEstrelas.ImageUrl = "~/Images/star2.png";
                    cincoEstrelas.ImageUrl = "~/Images/star2.png";
                    break;
                case 3:
                    umaEstrela.ImageUrl = "~/Images/star.png";
                    duasEstrelas.ImageUrl = "~/Images/star.png";
                    tresEstrelas.ImageUrl = "~/Images/star.png";
                    quatroEstrelas.ImageUrl = "~/Images/star2.png";
                    cincoEstrelas.ImageUrl = "~/Images/star2.png";
                    break;
                case 4:
                    umaEstrela.ImageUrl = "~/Images/star.png";
                    duasEstrelas.ImageUrl = "~/Images/star.png";
                    tresEstrelas.ImageUrl = "~/Images/star.png";
                    quatroEstrelas.ImageUrl = "~/Images/star.png";
                    cincoEstrelas.ImageUrl = "~/Images/star2.png";
                    break;
                case 5:
                    umaEstrela.ImageUrl = "~/Images/star.png";
                    duasEstrelas.ImageUrl = "~/Images/star.png";
                    tresEstrelas.ImageUrl = "~/Images/star.png";
                    quatroEstrelas.ImageUrl = "~/Images/star.png";
                    cincoEstrelas.ImageUrl = "~/Images/star.png";
                    break;
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            Login = ListaUsuario.BuscarLogin(txtBoxUser.Text, txtBoxSenha.Text);

            if (Login != null)
                Response.Redirect($"evento.aspx?l={Login.Codigo}&e={Evento.Codigo}");
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Login = ListaUsuario.BuscarLogin(txtBoxUser.Text, txtBoxSenha.Text);

            if (Login != null)
                Response.Redirect($"evento.aspx?e={Evento.Codigo}&l={Login.Codigo}");
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

        void PreencherDdlMotivos()
        {
            Banco banco = new Banco();

            MySqlDataReader data = banco.Query("ListarMotivos");

            ddlMotivos.DataTextField = "Nome";
            ddlMotivos.DataValueField = "Codigo";
            ddlMotivos.DataSource = data;
        }

        void verificarAvalicao()
        {
            if (!ListaAvaliacao.VerificarAvaliacaoPorUsuarioEvento(Login.Codigo, int.Parse(Request.QueryString["e"])))
                return;

            Avaliacao aval = ListaAvaliacao.BuscarAvaliacaoPorUsuarioEvento(Login.Codigo, int.Parse(Request.QueryString["e"]));

            txtBoxAvaliacao.Text = aval.Descricao;
            colocarEstrelas(aval.Estrelas);
        }

        protected void umaEstrela_Click(object sender, ImageClickEventArgs e)
        {
            colocarEstrelas(1);
        }

        protected void duasEstrelas_Click(object sender, ImageClickEventArgs e)
        {
            colocarEstrelas(2);
        }

        protected void tresEstrelas_Click(object sender, ImageClickEventArgs e)
        {
            colocarEstrelas(3);
        }

        protected void quatroEstrelas_Click(object sender, ImageClickEventArgs e)
        {
            colocarEstrelas(4);
        }

        protected void cincoEstrelas_Click(object sender, ImageClickEventArgs e)
        {
            colocarEstrelas(5);
        }

        protected void btnAvaliar_Click(object sender, EventArgs e)
        {
            string texto = txtBoxAvaliacao.Text;
            int estrelas = 0;

            if (duasEstrelas.ImageUrl == "~/Images/star.png")
                if (tresEstrelas.ImageUrl == "~/Images/star.png")
                    if (quatroEstrelas.ImageUrl == "~/Images/star.png")
                        if (cincoEstrelas.ImageUrl == "~/Images/star.png")
                            estrelas = 5;
                        else
                            estrelas = 4;
                    else
                        estrelas = 3;
                else
                    estrelas = 2;
            else
                estrelas = 1;

            ListaAvaliacao.Avaliar(Login.Codigo, Evento.Codigo, texto, estrelas);
        }

        protected void btnDenunciar_Click(object sender, EventArgs e)
        {
            string texto = txtBoxDescProb.Text;
            int motivo = int.Parse(ddlMotivos.SelectedValue);

            ListaDenuncia.CriarDenuncia(Evento.Codigo, Login.Codigo, motivo, texto);
        }
    }
}