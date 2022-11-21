using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura
{
    public partial class Index : System.Web.UI.Page
    {
        void HandleLogin()
        {
            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);
                dropbtnUsuario.Text = Login.Nome;
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litDropDownPerfil.Text = $"<a href='perfil.aspx?l={Login.Codigo}&u={Login.Codigo}'>Perfil</a>";
                if (Login.Tipo == "Administrador")                                                              //Logado
                    litDropDownDenuncias.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";
                dropbtnUsuario.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
            }
            else
            {
                dropbtnUsuario.Visible = false;
                btnLog.Visible = true;                                                                          //Deslogado
                btnCad.Visible = true;
            }

        }


        Filtro filtro;
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;

        private void ListarEventos(string usuario) {



            List<Evento> Eventos;
            if (ListaUsuario.Buscar(usuario) != null)
                Eventos = ListaEvento.Feed(usuario);
            else
                Eventos = ListaEvento.Feed();

            Eventos = Eventos.FindAll((e) => filtro.Verificar(e));
           
            litEventos.Text = "";
            foreach (Evento evento in Eventos)
            {
                Usuario usuarioEvento = ListaUsuario.Buscar(evento.Responsavel);
                List<Categoria> categorias = evento.Categorias;
                List<DiaEvento> dias = evento.Dias;

                var TagA = $"<a href='evento.aspx?e={evento.Codigo}'>";

                if(Request.QueryString["l"] != null)
                {
                    TagA = $"<a href='evento.aspx?l={Login.Codigo}&e={evento.Codigo}'>";
                }

                litEventos.Text += $@"<section class='card'>
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
                    litEventos.Text += $@"<h2 class='tag'>{categoria.Nome}</h2>
                    </article>

                    <article class='card-image'>
                        {TagA}
                            <figure>
                                <img src='{ListaEvento.BuscarImagem(evento.Codigo)}' alt='Interclasse de cria' class='foto-evento'>
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
                        <h3>{
                            evento.Local // Trocar pelo formato "Cidade, Estado" depois
                        }</h3>

                    </article>
                </section>";
            }
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
            HandleLogin();

            filtro = new Filtro();
            filtro.Inicio = StrinToDate(dtStart.Text);
            filtro.Fim = StrinToDate(dtEnd.Text);
            filtro.Local = txtLocal.Text;
            filtro.Categorias = new List<string>();
            filtro.Categorias.Add((string)ViewState["Cateoria"]);
            string usuario = Request.QueryString["u"];

            ListarEventos(usuario);
            LoadComplete += Page_Load;
        }

        protected void ClickCategoria(object sender, EventArgs e)
        {
            var Botao = (Button)sender;
            ViewState["Cateoria"] = Botao.Text;
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Login = ListaUsuario.BuscarLogin(txtBoxUser.Text, txtBoxSenha.Text);

            if (Login != null)
                Response.Redirect($"eventos.aspx?l={Login.Codigo}");
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
    }
}