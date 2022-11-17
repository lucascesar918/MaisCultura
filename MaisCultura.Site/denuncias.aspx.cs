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
        string AdicionarReticencias(string str, int TamanhoMaximo) {
            return str.Length > TamanhoMaximo ? str.Substring(0, TamanhoMaximo - 3) + "..." : str;
        }

        ListaDenuncia ListaDenuncia = new ListaDenuncia();
        ListaUsuario ListaUsuario = new ListaUsuario();
        ListaEvento ListaEvento = new ListaEvento();

        Usuario Login;

        protected void Page_Load(object sender, EventArgs e)
        {

            Login = ListaUsuario.Buscar(Request.QueryString["l"]);

            List<Denuncia> Denuncias = ListaDenuncia.Listar();

            litEventos.Text = $"<a href=\"eventos.aspx?l={Login.Codigo}\">Eventos</a>";
            dropbtnUsuario.Text = Login.Nome;
            litPerfil.Text = $"<a href=\"perfil.aspx?u={Login.Codigo}&l={Login.Codigo}\">Perfil</a>";

            foreach (Denuncia denuncia in Denuncias)
                litDenuncias.Text += $@"<section class='denuncia'>      
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
                    <p>⠀{denuncia.Descricao}</p>
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
            </section>";
        }
    }
}