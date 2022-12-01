using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura.Site
{
    public partial class meu_perfil : System.Web.UI.Page
    {
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;


        void HandleLogin()
        {
            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);
                dropbtnUsuario.Text = Login.Nome;
                litLogo.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>";
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                if (Login.Tipo == "Administrador")                                                              //Logado
                    litDropDownDenuncias.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";
                dropbtnUsuario.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";

                if (Login.Tipo != "Criador de Eventos" && Login.Tipo != "Empresa")
                {
                    meusEventos.Visible = false;
                    litEventos.Visible = false;
                }

                else
                {
                    meusEventos.Visible = true;
                    litEventos.Visible = true;
                }
            }
            else
            {
                dropbtnUsuario.Visible = false;
                btnLog.Visible = true;                                                                          //Deslogado
                btnCad.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleLogin();

            dropbtnUsuario.Text = Login.Nome;
            lblNomeUsuario.Text = Login.Nome;
            lblArroba.Text = $"@{Login.Codigo}";
            lblEmail.Text = Login.Email;
            lblNascimento.Text = Login.Nascimento.Substring(0, 10);
            lblSexo.Text = Login.Sexo == "M" ? "Masculino" : (Login.Sexo == "F" ? "Feminino" : "Não Informado");
            lblTipo.Text = Login.Tipo;

            litPrefs.Text = "";

            foreach (Categoria preferencia in Login.Preferencias)
                litPrefs.Text += $"<li>{preferencia.Nome}</li>";

            ListarEventos(Login.Codigo);

            LoadComplete += Page_Load;
        }

        private void PrintarEventos(List<Evento> Eventos, bool hidden)
        {
            foreach (Evento evento in Eventos)
            {
                Usuario usuarioEvento = ListaUsuario.Buscar(evento.Responsavel);
                List<Categoria> categorias = evento.Categorias;
                List<DiaEvento> dias = evento.Dias;

                string TagAEvento = $"<a href='evento.aspx?e={evento.Codigo}'>";
                string TagAPerfil = $"<a href='perfil.aspx?u={usuarioEvento.Codigo}'>";
                string ClassHidden = hidden ? "<section class='card hidden'>" : "<section class='card'>";

                if (Login != null)
                {
                    if (Login.Codigo == evento.Responsavel)
                        TagAPerfil = $"<a href='meu-perfil.aspx?l={Login.Codigo}&u={usuarioEvento.Codigo}'>";
                    else
                        TagAPerfil = $"<a href='perfil.aspx?l={Login.Codigo}&u={usuarioEvento.Codigo}'>";

                    TagAEvento = $"<a href='evento.aspx?l={Login.Codigo}&e={evento.Codigo}'>";
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
                                <img src='{ListaEvento.BuscarImagem(evento.Codigo)[0]}' alt='Interclasse de cria' class='foto-evento'>
                            </figure>
                        </a>
                    </article>

                    <article class='card-dateTime dateTime'>
                        <article class='date'>
                            <figure>
                                <img src='Images/calendar.png' alt='Ícone calendário' class='calendar-icon'>
                            </figure>
                            <h3>{dias[0].Data.ToShortDateString()} a {dias[dias.Count - 1].Data.ToShortDateString()}</h3>
                        </article>

                        <article class='time'>
                            <figure>
                                <img src='Images/time.png' alt='Ícone Tempo' class='time-icon'>
                            </figure>
                            {dias[0].Inicio.ToShortTimeString()}
                        </article>
                    </article>

                    <article class='card-local'>
                        <figure>
                            <img src='Images/local.png' alt='Ícone Local' class='local-icon'>
                        </figure>
                        <h3>{evento.Local}</h3>

                    </article>
                </section>";
            }
        }

        private void ListarEventos(string usuario)
        {

            litEventos.Text = "";

            List<Evento> Diff; // Eventos que não são da preferência do usuário
            List<Evento> Feed; // Eventos de preferência do usuário

            (Diff, Feed) = ListaEvento.GetFeedCreator(Login?.Codigo);

            litEventos.Text = "";
            PrintarEventos(Feed, false);
            PrintarEventos(Diff, Feed.Count > 0);
        }

        protected void btnSenha_Click(object sender, EventArgs e)
        { //Falta mostrar para o usuário se foi possível ou não alterar a senha

            if (txtSenhaAntiga.Text == txtSenhaNova.Text) return;

            ListaUsuario.AlterarSenha(Login.Codigo ,txtSenhaNova.Text);
        }

        protected void btnExcluirConta_Click(object sender, EventArgs e)
        {
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            ListaUsuario.Deletar(Login.Codigo);
            Response.Redirect("eventos.aspx");
        }
    }
}