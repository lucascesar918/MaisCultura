using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura
{
    public partial class perfil : System.Web.UI.Page
    {
        Usuario usuario;
        Usuario Login;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuario ListaUsuario = new ListaUsuario();

            usuario = ListaUsuario.Buscar(Request.QueryString["u"]);
            if (usuario == null) usuario = ListaUsuario.Buscar("adriano.fraga");

            Login = ListaUsuario.Buscar(Request.QueryString["l"]);
            if (Login == null) Login = ListaUsuario.Buscar("lucas.serio");

            litEventos.Text = $"<a href=\"eventos.aspx?u={usuario.Codigo}\">Eventos</a>";
            dropbtnUsuario.Text = usuario.Nome;
            lblNomeUsuario.Text = usuario.Nome;
            lblArroba.Text = $"@{usuario.Codigo}";
            lblEmail.Text = usuario.Email;
            lblNascimento.Text = usuario.Nascimento.Substring(0,10);
            lblSexo.Text = usuario.Sexo == "M" ? "Masculino" : (usuario.Sexo == "F" ? "Feminino" : "Não Informado");
            lblTipo.Text = usuario.Tipo;

            litPrefs.Text = "";

            foreach (Categoria preferencia in usuario.Preferencias)
                litPrefs.Text += $"<li>{preferencia.Nome}</li>";
        }

        protected void btnSenha_Click(object sender, EventArgs e)
        { //Falta mostrar para o usuário se foi possível ou não alterar a senha

            if (txtSenhaAntiga.Text != txtSenhaNova.Text) return;

            ListaUsuario ListaUsuario = new ListaUsuario();

            //falta trocar a senha
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            ListaUsuario ListaUsuario = new ListaUsuario();
            ListaUsuario.Deletar(usuario.Codigo);
        }
    }
}