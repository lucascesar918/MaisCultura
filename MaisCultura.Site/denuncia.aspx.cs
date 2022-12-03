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

        void HandleLogin()
        {
            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);

                if (Login.Tipo != "Administrador")                                                              //Logado
                    Response.Redirect($"erro.html?msg=O que você está fazendo aqui? 😯 Você não tem permissão para acessar essa página!&l={Login.Codigo}");

                litLogo.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>";
                litUsuario.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}'>{Login.Nome}</a>";
                litHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litPerfil.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}'>Perfil</a>";

                switch (Login.Tipo)
                {
                    case "Administrador":
                        litAdicionais.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";
                        break;

                    default:
                        Response.Redirect("erro.html?msg=O que você está fazendo aqui? 😯 Você não tem permissão para acessar essa página!");
                        break;
                }

                litUsuario.Visible = true;
                litImgPerfil.Text = $@"<a href='meu-perfil.aspx?l={Login.Codigo}'>
                    <img src='Images/perfil526ace.png' class='imgPerfil'>
                </a>";
            }
            else
                Response.Redirect("erro.html?msg=O que você está fazendo aqui? 😯 Você não tem permissão para acessar essa página!");


        }

        protected void Page_Load(object sender, EventArgs e) //https://localhost:44335/denuncia.aspx?l=lucas.serio&d=2
        {
            HandleLogin();

            Denuncia = ListaDenuncia.Buscar(Int32.Parse(Request.QueryString["d"]));
            Evento = ListaEvento.Buscar(Denuncia.CodigoEvento);

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