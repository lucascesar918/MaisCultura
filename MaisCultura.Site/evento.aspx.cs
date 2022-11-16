using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaisCultura.Site
{
    public partial class EventoEspecifico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInteresse_Click(object sender, EventArgs e)
        {
            if (btnInteresse.CssClass.Contains("naoInt"))   
            {
                btnInteresse.CssClass = "Int";
                btnInteresse.Text = "Interesse Demonstrado";
            }
            else
            {
                btnInteresse.CssClass = "naoInt";
                btnInteresse.Text = "Demonstrar Interesse";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.CssClass.Contains("naoSalvo"))
            {
                btnSave.CssClass = "save salvo";
            }
            else
            {
                btnSave.CssClass = "save naoSalvo";
            }
        }
    }
}