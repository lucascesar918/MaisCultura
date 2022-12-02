using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura
{
    public partial class PainelDenuncias : System.Web.UI.Page
    {
        string AdicionarReticencias(string str, int TamanhoMaximo)
        {
            return str.Length > TamanhoMaximo ? str.Substring(0, TamanhoMaximo - 3) + "..." : str;
        }

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
                Response.Redirect("eventos.aspx");                                                              //Deslogado
            }

        }

        ListaDenuncia ListaDenuncia = new ListaDenuncia();
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;

        protected void Page_Load(object sender, EventArgs e)
        {

            List<Denuncia> Denuncias = ListaDenuncia.Listar();

            HandleLogin();

            foreach (Denuncia denuncia in Denuncias)
                litDenuncias.Text += $@"
                <a href='denuncia.aspx?l={Login.Codigo}&d={denuncia.CodigoDenuncia}'>
                <section class='denuncia'>      
                    <div class='divInfo'>
                        <h4 class='title'> DENÚNCIA FEITA POR</h4>
                        <p>⠀{denuncia.CodigoUsuario}</p>
                    </div>

                <div class='divInfo'>
                    <h4 class='title'>EVENTO</h4>
                    <p>⠀{AdicionarReticencias(ListaEvento.Buscar(denuncia.CodigoEvento).Titulo, 30)}</p>
                </div>

                <div class='divInfo'>
                    <h4 class='title'> MOTIVO</h4>
                    <p>⠀{AdicionarReticencias(ListaEvento.Buscar(denuncia.CodigoEvento).Descricao, 80)}</p>
                </div>
               
                <div class='divInfo'>
                    <div class='divdthr'>
                        <h4 class='title'> DATA</h4>
                        <p>⠀{denuncia.Data.ToShortDateString()}</p>
                    </div>
                    <div class='divdthr'>
                        <h4 class='title'> HORA</h4>
                        <p>⠀{denuncia.Data.ToShortTimeString()}</p>
                    </div>
                </div>
            </section>
            </a>";
        }
    }
}