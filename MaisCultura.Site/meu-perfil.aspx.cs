using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura.Site
{
    public partial class meu_perfil : System.Web.UI.Page
    {
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;


        void HandleLogin()
        {
            if (Request.QueryString["l"] != null)
            {
                Login = ListaUsuario.Buscar(Request.QueryString["l"]);
                dropbtnUsuario.Text = Login.Nome;
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litDropDownPerfil.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}&u={Login.Codigo}'>Perfil</a>";
                if (Login.Tipo == "Administrador")                                                              //Logado
                    litDropDownDenuncias.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";
                dropbtnUsuario.Visible = true;
                btnLog.Visible = false;
                btnCad.Visible = false;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
                litLogoHeader.Text = $@"<a href='eventos.aspx?l={Login.Codigo}'>
                    <img src = 'Images/logoNomeMenor.png' class='logo-header'/>
                </a>";
            }
            else
            {
                Response.Redirect("erro.html?msg=O que você está fazendo? Você não tem permissão para isso!");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleLogin();

            //litEventos.Text = $"<a href=\"eventos.aspx?u={usuario.Codigo}\">Eventos</a>";
            dropbtnUsuario.Text = Login.Nome;
            lblNomeUsuario.Text = Login.Nome;
            lblArroba.Text = $"@{Login.Codigo}";
            lblEmail.Text = Login.Email;
            lblNascimento.Text = Login.Nascimento.Substring(0, 10);
            lblSexo.Text = Login.Sexo == "M" ? "Masculino" : (Login.Sexo == "F" ? "Feminino" : "Não Informado");
            lblTipo.Text = Login.Tipo;

            litPrefs.Text = "";

            foreach (Categoria preferencia in Login.Preferencias)
                litPrefs.Text += $"<li>{preferencia.Nome}</li>";
        }

        protected void btnSenha_Click(object sender, EventArgs e)
        { //Falta mostrar para o usuário se foi possível ou não alterar a senha

            if (txtSenhaAntiga.Text == txtSenhaNova.Text) return;

            ListaUsuario.AlterarSenha(Login.Codigo ,txtSenhaNova.Text);
        }

        protected void btnExcluirConta_Click(object sender, EventArgs e)
        {
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            ListaUsuario.Deletar(Login.Codigo);
            Response.Redirect("eventos.aspx");
        }
    }
}