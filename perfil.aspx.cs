using AlfaMaisCultura;
using AlfaMaisCultura.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenosCultura
{
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuario ListaUsuario = new ListaUsuario();

            string usuarioCd = Request.QueryString["u"];
            Usuario usuario = ListaUsuario.Buscar(usuarioCd);
            if (usuario == null) usuario = ListaUsuario.Buscar("adriano.fraga");

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
            string usuario;
            if (Request.QueryString["u"] != null) usuario = Request.QueryString["u"];
            else usuario = "adriano.fraga";
            
        }
    }
}