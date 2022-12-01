using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura
{
    public partial class EventosdoCriador : System.Web.UI.Page
    {
        ListaEvento ListaEvento = new ListaEvento();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCriarEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("criar-evento.aspx");
        }
    }
}