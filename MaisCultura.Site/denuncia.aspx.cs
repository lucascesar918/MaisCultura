using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura
{
    public partial class denuncia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaEvento ListaEvento = new ListaEvento();
            ListaUsuario ListaUsuario = new ListaUsuario();
            ListaDenuncia ListaDenuncia = new ListaDenuncia();

            int cdDenuncia = Int32.Parse(Request.QueryString["d"]);
            Denuncia Denuncia = ListaDenuncia.Buscar(cdDenuncia);
            Evento Evento = ListaEvento.Buscar(Denuncia.CodigoEvento);
            
            Usuario Usuario = ListaUsuario.Buscar(Denuncia.CodigoUsuario);
            Usuario Login = ListaUsuario.Buscar(Request.QueryString["l"]);
            if (Usuario == null) Usuario = ListaUsuario.Buscar("adriano.fraga");
            if (Login == null) Login = ListaUsuario.Buscar("adriano.fraga");


            litEventos.Text = $"<a href=\"eventos.aspx?l={Login.Codigo}\">Eventos</a>";
            lblUser.Text = Usuario.Codigo;
            lblNmEvento.Text = Evento.Titulo;
            lblMotivo.Text = Denuncia.Motivo.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Login.Codigo}\">Perfil</a>";

            lblData.Text = Denuncia.Data.ToShortDateString();
            lblHora.Text = Denuncia.Data.ToShortTimeString();
            litTextoDenuncia.Text = Denuncia.Descricao;

            dropbtnUsuario.Text = Login.Nome;
        }
    }
}