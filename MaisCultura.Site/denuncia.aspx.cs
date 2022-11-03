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
            Usuario Usuario = ListaUsuario.Buscar(Request.QueryString["u"] == "" ? Request.QueryString["u"] : "adriano.fraga");
            List<Denuncia> Denuncias = ListaUsuario.BuscarDenuncias(Usuario.Codigo);
            Evento Evento = ListaEvento.Buscar(Denuncias[0].CodigoEvento);

            lblUser.Text = Usuario.Codigo;
            lblNmEvento.Text = Evento.Titulo;
            lblMotivo.Text = Denuncias[0].Motivo.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Usuario.Codigo}\">Perfil</a>";

            dropbtnUsuario.Text = Usuario.Nome;
        }
    }
}