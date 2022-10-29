using Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenosCultura  
{
    class Filtro
    {
        public List<string> Categorias;
        public string Local;
        public DateTime? Inicio;
        public DateTime? Fim;
        public int QtEstrelas;


        public bool Verificar(Evento evento)
        {
            return VerificarLocal(evento)
                && VerificarInicio(evento)
                && VerificarFim(evento)
                && VerificarCategorias(evento);

        }

        bool VerificarLocal(Evento evento)
        {
            if (Local == null)
                return true;
            return evento.Local.ToLower().Contains(Local.ToLower());
        }

        bool VerificarInicio(Evento evento)
        {
            if (Inicio == null)
                return true;
            Debug.WriteLine(string.Join(";", evento.Dias.Select(d=>d.Data)));
            return evento.Dias.Any( (dia) => Inicio <= dia.Data );
        }
        bool VerificarFim(Evento evento)
        {
            if (Fim == null)
                return true; 
            return evento.Dias.Any((dia) => dia.Data <= Fim); 
        }
        bool VerificarCategorias(Evento evento)
        {
            if (Categorias?.DefaultIfEmpty() == null )
                return true;
            return Categorias.Any(filtroCat => 
            string.IsNullOrEmpty(filtroCat)  || 
            evento.Categorias.Any((categoria) => filtroCat == categoria.Nome));
        }
    }
    public partial class Index : System.Web.UI.Page
    {
        Filtro filtro =  new Filtro();
        private void ListarEventos(string usuario) {
            ListaUsuario ListaUsuario = new ListaUsuario();
            ListaEvento ListaEvento = new ListaEvento();
            List<Evento> Eventos;
            List<Categoria> categorias = new List<Categoria>();
            List<DiaEvento> dias = new List<DiaEvento>();



            if (ListaUsuario.Buscar(usuario) != null)
                Eventos = ListaEvento.Feed(usuario);

            else
                Eventos = ListaEvento.Feed();
            Eventos = Eventos.FindAll((e) => filtro.Verificar(e));
            Usuario usuarioEvento;
            litEventos.Text = "";
            foreach (Evento evento in Eventos)
            {
                usuarioEvento = ListaUsuario.Buscar(evento.Responsavel);
                categorias = evento.Categorias;
                dias = evento.Dias;

                litEventos.Text += "<section class=\"card\">";
                litEventos.Text += "<article class=\"card-header\">";
                litEventos.Text += "<figure>";
                litEventos.Text += "<img src=\"Images/perfil.png\" alt=\"Imagem de Perfil\" class=\"perfil\">";
                litEventos.Text += "</figure>";

                litEventos.Text += "<article class=\"card-header-nome\">";
                litEventos.Text += $"<h2>{usuarioEvento.Nome}</h2>";
                litEventos.Text += $"<h5>{usuarioEvento.Codigo}</h5>";
                litEventos.Text += "</article>";

                litEventos.Text += "<figure>";
                litEventos.Text += "<img src=\"Images/save.png\" alt=\"Salvar\" class=\"save\">";
                litEventos.Text += "</figure>";
                litEventos.Text += "</article>";

                litEventos.Text += "<article class=\"card-tittle\">";
                litEventos.Text += $"<h2>{evento.Titulo}</h2>";
                litEventos.Text += "</article>";

                litEventos.Text += "<article class=\"card-tags\">";
                foreach (Categoria categoria in categorias)
                    litEventos.Text += $"<h2 class=\"tag\">{categoria.Nome}</h2>";
                litEventos.Text += "</article>";
                litEventos.Text += "<article class=\"card-image\">";
                litEventos.Text += "<figure>";
                litEventos.Text += $"<img src=\"{ListaEvento.BuscarImagem(evento.Codigo)}\" alt=\"Interclasse de cria\" class=\"foto-evento\">";
                litEventos.Text += "</figure>";
                litEventos.Text += "</article>";

                litEventos.Text += "<article class=\"card-dateTime dateTime\">";
                litEventos.Text += "<article class=\"card-dateTime date\">";
                litEventos.Text += "<figure>";
                litEventos.Text += "<img src=\"Images/calendar.png\" alt=\"Ícone calendário\" class=\"calendar-icon\">";
                litEventos.Text += "</figure>";
                litEventos.Text += $"<h3>{dias[0].Data.ToShortDateString()} a {dias[dias.Count - 1].Data.ToShortDateString()}</h3>";
                litEventos.Text += "</article>";
                litEventos.Text += "<article class=\"card-dateTime time\">";
                litEventos.Text += "<figure>";
                litEventos.Text += "<img src=\"Images/time.png\" alt=\"Ícone Tempo\" class=\"time-icon\">";
                litEventos.Text += "</figure>";
                litEventos.Text += $"{dias[0].Inicio.ToShortTimeString()}";
                litEventos.Text += "</article>";
                litEventos.Text += "</article>";

                litEventos.Text += "<article class=\"card-local\">";
                litEventos.Text += "<figure>";
                litEventos.Text += "<img src=\"Images/local.png\" alt=\"Ícone Local\" class=\"local-icon\">";
                litEventos.Text += "</figure>";
                litEventos.Text += $"<h3>{evento.Local}</h3>"; // Trocar pelo formato "Cidade, Estado" depois
                litEventos.Text += "</article>";
                litEventos.Text += "</section>";
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
    }
}