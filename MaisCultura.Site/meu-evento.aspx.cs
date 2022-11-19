using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaisCultura.Site
{
    public partial class EventoEspecificoCriador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCriarEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("CriarEvento.aspx");
        }
    }
}