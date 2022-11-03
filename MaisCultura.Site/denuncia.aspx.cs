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

            string cdDenuncia = Request.QueryString["d"];
            
            Usuario Usuario = ListaUsuario.Buscar(Request.QueryString["u"]);
            if (Usuario == null) Usuario = ListaUsuario.Buscar("adriano.fraga");
            List<Denuncia> Denuncias = ListaDenuncia.BuscarPorUsuario(Usuario.Codigo);
            Evento Evento = ListaEvento.Buscar(Denuncias[0].CodigoEvento);

            litEventos.Text = $"<a href=\"eventos.aspx?u={Usuario.Codigo}\">Eventos</a>";
            lblUser.Text = Usuario.Codigo;
            lblNmEvento.Text = Evento.Titulo;
            lblMotivo.Text = Denuncias[0].Motivo.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Usuario.Codigo}\">Perfil</a>";

            dropbtnUsuario.Text = Usuario.Nome;
        }
    }
}