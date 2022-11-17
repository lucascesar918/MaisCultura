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

        protected void Page_Load(object sender, EventArgs e)
        {

            Login = ListaUsuario.Buscar(Request.QueryString["l"]);

            List<Denuncia> Denuncias = ListaDenuncia.Buscar(Int32.Parse(Request.QueryString["d"]));
            Evento Evento = ListaEvento.Buscar(Denuncias[0].CodigoEvento);
            
            litEventos.Text = $"<a href=\"eventos.aspx?l={Login.Codigo}\">Eventos</a>";
            dropbtnUsuario.Text = Login.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Login.Codigo}&l={Login.Codigo}\">Perfil</a>";

            lblUser.Text = Login.Codigo;
            lblNmEvento.Text = Evento.Titulo;
            lblMotivo.Text = Denuncias[0].Motivo.Nome;

            //terminar essa aqui
        }
    }
}