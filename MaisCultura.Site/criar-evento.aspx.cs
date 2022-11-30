    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaisCultura.Biblioteca;

namespace MaisCultura.Site
{
    public partial class CriarEvento : System.Web.UI.Page
    {
        ListaEvento ListaEvento = new ListaEvento();
        ListaUsuario ListaUsuario = new ListaUsuario();

        Usuario Login;

        void HandleLogin()
        {
            Login = ListaUsuario.Buscar("adriano.fraga");

            if (Request.QueryString["l"] != null || Login != null)
            {
                if (Request.QueryString["l"] != null)
                    Login = ListaUsuario.Buscar(Request.QueryString["l"]);

                dropbtnUsuario.Text = Login.Nome;
                litDropDownHome.Text = $"<a href='eventos.aspx?l={Login.Codigo}'>Início</a>";
                litDropDownPerfil.Text = $"<a href='meu-perfil.aspx?l={Login.Codigo}&u={Login.Codigo}'>Perfil</a>";

                switch (Login.Tipo) {
                    case "Administrador":
                        litDropDownDenuncias.Text = $"<a href='denuncias.aspx?l={Login.Codigo}'>Denúncias</a>";
                        break;

                    case "Usuário Comum":
                        Response.Redirect($"erro.html?msg=O que você está tentando fazer? Você não tem permissão para isso! Torne-se um criador de eventos primeiro.&l={Login.Codigo}");
                        break;

                    default:
                        litDropDownDenuncias.Text = $"<a href='criar-evento.aspx?l={Login.Codigo}'>Criar Evento</a>";
                        litDropDownDenuncias.Text += $"<a href='meus-eventos.aspx?l={Login.Codigo}&u={Login.Codigo}'>Meus Eventos</a>";
                        break;
                }

                dropbtnUsuario.Visible = true;
                litImgPerfil.Text = $@"<img src='Images/perfil526ace.png' class='imgPerfil'>";
            }
            else
            {
                dropbtnUsuario.Visible = false;
                Response.Redirect("erro.html?msg=O que você está tentando fazer? Você não tem permissão para isso!");
            }
        }

        void PrepareInputs()
        {
            if (!IsPostBack)
            {
                List<Categoria> AllCategorias = ListaEvento.ListarCategorias();

                foreach (Categoria categoria in AllCategorias)
                    ddlCategs.Items.Add(new ListItem(categoria.Nome, categoria.Codigo.ToString()));
            }

            lblStatusListBox.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleLogin();
            PrepareInputs();

            txtBoxDescricao.TextMode = TextBoxMode.MultiLine;
        }

        protected void btnAdicionarDtHr_Click(object sender, EventArgs e)
        {
            string data = DateTime.Parse(txtDtInicio.Text).ToShortDateString();
            string hr_inicio = txtHrInicio.Text;
            string hr_fim = txtHrFim.Text;

            listBoxDtHr.Items.Add(new ListItem($"Dia {data} das {hr_inicio} até às {hr_fim}", $"{data}-{hr_inicio}-{hr_fim}"));
        }
        
        void StatusHandler(string status)
        {
            lblStatusListBox.ForeColor = System.Drawing.Color.Red;

            switch (status)
            {
                case "null_categ":
                    lblStatusListBox.Text = "Selecione uma categoria!";
                    return;

                case "max_categ":
                    lblStatusListBox.Text = "O máximo de categorias foi atingido!";
                    return;
            }
        }

        protected void btnAddCateg_Click(object sender, EventArgs e)
        {
            if (ddlCategs.SelectedItem == null) { StatusHandler("null_categ"); return; }
            if (listBoxCateg.Items.Count >= 3) { StatusHandler("max_categ"); return; }


            listBoxCateg.Items.Add(new ListItem(ddlCategs.SelectedItem.Text, ddlCategs.SelectedValue));
            ddlCategs.Items.RemoveAt(ddlCategs.SelectedIndex);
        }

        protected void btnRmCateg_Click(object sender, EventArgs e)
        {
            if (listBoxCateg.SelectedItem == null) return;

            ddlCategs.Items.Add(new ListItem(listBoxCateg.SelectedItem.Text, listBoxCateg.SelectedValue));
            listBoxCateg.Items.RemoveAt(listBoxCateg.SelectedIndex);
        }

        protected void btnRemoverDtHr_Click(object sender, EventArgs e)
        {
            if (listBoxDtHr.SelectedItem == null) return;

            listBoxDtHr.Items.RemoveAt(listBoxDtHr.SelectedIndex);
        }


        protected void btnAddEvento_Click(object sender, EventArgs e)
        {
            DiaEvento ValueToDiaEvento(string value)
            {
                string[] splitValue = value.Split('-');

                return new DiaEvento(splitValue[0], splitValue[1], splitValue[2]);
            }

            Evento Evento;
            List<Categoria> Categorias = new List<Categoria>();
            List<DiaEvento> Dias = new List<DiaEvento>();

            foreach (ListItem item in listBoxCateg.Items)
                Categorias.Add(new Categoria(Int32.Parse(item.Value), item.Text));

            foreach (ListItem item in listBoxDtHr.Items)
                Dias.Add(ValueToDiaEvento(item.Value));

            Evento = new Evento(ListaEvento.MaxCodigo(), Login.Codigo, txtTituloEvento.Text, $"{ddlUF.SelectedItem.Text}, {txtCidade.Text}, {txtEndereco.Text}", txtBoxDescricao.Text, Categorias, Dias);

            ListaEvento.Criar(Evento);

            Response.Redirect($"eventos.aspx?l={Login.Codigo}");
        }
    }
}