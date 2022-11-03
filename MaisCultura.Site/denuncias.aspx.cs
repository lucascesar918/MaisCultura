using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca;

namespace MaisCultura
{
    public partial class PainelDenuncias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaDenuncia ListaDenuncia = new ListaDenuncia();
            ListaUsuario ListaUsuario = new ListaUsuario();
            Usuario Usuario = ListaUsuario.Buscar(Request.QueryString["u"].Length > 0 ? Request.QueryString["u"] : "adriano.fraga");
            List<Denuncia> Denuncias = ListaDenuncia.Listar();

            dropbtnUsuario.Text = Usuario.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Usuario.Codigo}\">Perfil</a>";

        }
    }
}