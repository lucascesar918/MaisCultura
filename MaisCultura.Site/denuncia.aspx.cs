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
        ListaEvento ListaEvento = new ListaEvento();
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaDenuncia ListaDenuncia = new ListaDenuncia();

        Usuario Login;
        Denuncia Denuncia;
        Evento Evento;

        protected void Page_Load(object sender, EventArgs e)
        {

            Login = ListaUsuario.Buscar(Request.QueryString["l"]);

            Denuncia = ListaDenuncia.Buscar(Int32.Parse(Request.QueryString["d"]));
            Evento = ListaEvento.Buscar(Denuncia.CodigoEvento);
            
            litEventos.Text = $"<a href=\"eventos.aspx?l={Login.Codigo}\">Eventos</a>";
            dropbtnUsuario.Text = Login.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Login.Codigo}&l={Login.Codigo}\">Perfil</a>";

            lblUser.Text = Denuncia.CodigoUsuario;
            lblNmEvento.Text = Evento.Titulo;
            lblMotivo.Text = Denuncia.Motivo.Nome;
            litTextoDenuncia.Text = Denuncia.Descricao;
            lblData.Text = Denuncia.Data.ToShortDateString();
            lblHora.Text = Denuncia.Data.ToShortTimeString();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            ListaEvento.Deletar(Evento.Codigo);
        }

        protected void btnRetirar_Click(object sender, EventArgs e)
        {
            ListaDenuncia.Deletar(Denuncia.CodigoDenuncia);
        }
    }
}