using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaisCultura.Site
{
    public partial class CriarEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBoxAvaliacao.TextMode = TextBoxMode.MultiLine;
        }
    }
}