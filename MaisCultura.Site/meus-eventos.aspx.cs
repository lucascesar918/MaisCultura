using MaisCultura.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaisCultura
{
    public partial class EventosdoCriador : System.Web.UI.Page
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

                litLogo.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>";
                litUsuario.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}'>{Login.Nome}</a>";
                litHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litPerfil.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}'>Perfil</a>";

                switch (Login.Tipo)
                {
                    case "Administrador":
                        litAdicionais.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";
                        break;

                    case "Usuário Comum":
                        Response.Redirect($"erro.html?msg=O que você está tentando fazer? Você não tem permissão para isso! Torne-se um criador de eventos primeiro.&l={Login.Codigo}");
                        break;

                    default:
                        litAdicionais.Text = $"<a href='criar-evento.aspx?l={Login.Codigo}'>Criar Evento</a>";
                        break;
                }

                litUsuario.Visible = true;
                litImgPerfil.Text = $@"<a href='meu-perfil.aspx?l={Login.Codigo}'>
                    <img src='Images/perfil526ace.png' class='imgPerfil'>
                </a>";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleLogin();

            ListarEventos(Login?.Codigo);

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

        protected void btnCriarEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("criar-evento.aspx");
        }
    }
}