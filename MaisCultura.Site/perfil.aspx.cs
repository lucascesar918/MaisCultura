using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura.Site
{
    public partial class perfil : System.Web.UI.Page
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

        void HandleUser()
        {
            if (Request.QueryString["u"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["u"]);
                lblNmCompleto.Text = Login.Nome;
                lblArroba.Text = Login.Codigo;
                lblTUser.Text = Login.Tipo;

                if (Login.Tipo == "Criador de Eventos")
                {
                    CreateEvents();
                }
            }
            else
            {
                Response.Redirect("erro.html");
            }
        }

        void CreateEvents()
        {
            List<Evento> eventos = new List<Evento>();
            litEventosCria.Text += $@"
                <section class='eventosCriador' id='eventosCria'>
                    <h2 class='h2'> Eventos do Criador </h2>

                    <section class='feedEventos'>
                        
                    </section>
                </section>";
        }

        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleUser();
            HandleLogin();
        }
    }
}