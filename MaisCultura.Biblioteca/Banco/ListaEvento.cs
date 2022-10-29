using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using MySql.Data.MySqlClient;

namespace MaisCultura
{
    public class ListaEvento : Banco
    {
 
        Evento DataReaderToEvento(MySqlDataReader data, bool Reticencias) {
            var cdEvento = Int32.Parse(data["Codigo"].ToString());
            List<Categoria> categorias = BuscarCategorias(cdEvento);
            List<DiaEvento> dias = BuscarDias(cdEvento);
            string responsavel = data["@"].ToString();
            string local = data["Local"].ToString();
            string titulo = data["Titulo"].ToString();
            string descricao = data["Descricao"].ToString();
            if (Reticencias) {
                titulo = AdicionarReticencia(titulo, 35);
                local = AdicionarReticencia(local, 27);
            }
            return new Evento( cdEvento,responsavel , titulo, local, descricao,  categorias, dias);
        }
        public List<Evento> Listar()
        {

            List<Evento> Eventos = new List<Evento>();
            MySqlDataReader data = Query("ListarEventos");
            List<MySqlParameter> parametroEvento = new List<MySqlParameter>();

            while (data.Read())
            {
                Eventos.Add(DataReaderToEvento(data,false));
            }

            Desconectar();
            return Eventos;
        }

        public int MaxCodigo()
        {
            int codigo = 0;

            MySqlDataReader data = Query("MaxCodigoEvento");
            while (data.Read())
                codigo = Int32.Parse(data["Max"].ToString());

            return ++codigo;
        }
        
        public List<Categoria> BuscarCategorias(int codigo_evento)
        {
            List<Categoria> categorias = new List<Categoria>();
            List<MySqlParameter> parametro = new List<MySqlParameter>();
            parametro.Add(new MySqlParameter("pEvento", codigo_evento));

            MySqlDataReader data = Query("BuscarCategoriasEvento", parametro);
            while (data.Read())
                categorias.Add(new Categoria(Int32.Parse(data["CodigoCategoria"].ToString()), data["Nome"].ToString()));

            Desconectar();
            return categorias;
        }

        public List<DiaEvento> BuscarDias(int codigo_evento)
        {
            List<DiaEvento> dias = new List<DiaEvento>();
            List<MySqlParameter> parametro = new List<MySqlParameter>();
            parametro.Add(new MySqlParameter("pEvento", codigo_evento));

            MySqlDataReader data = Query("BuscarDiasEvento", parametro);

            while (data.Read())
                dias.Add(new DiaEvento(data["Data"].ToString(), data["Inicio"].ToString(), data["Fim"].ToString()));

            Desconectar();
            return dias;
        }
        string AdicionarReticencia(string Str, int TamanhoMaximo)
        {
            if(Str.Length > TamanhoMaximo)
                return Str.Substring(0, TamanhoMaximo - 3) + "...";
            return Str;
        }
        public List<Evento> Feed(string codigo_usuario)
        {
            List<Evento> eventos = new List<Evento>();
            List<MySqlParameter> parametroPreferencia = new List<MySqlParameter>();

            parametroPreferencia.Add(new MySqlParameter("pUsuario", codigo_usuario));

           MySqlDataReader dadosEventos = Query("EventosFeed", parametroPreferencia);
           while (dadosEventos.Read())
           {
                //<< Eu nao sei pra que serve essa linha, mas ela nao é usada;
                // if (parametroEvento.Count == 0)
                //    parametroEvento.Add(new MySqlParameter("pEvento", dadosEventos["Codigo"].ToString()));
                eventos.Add(DataReaderToEvento(dadosEventos, true));
           }

            Desconectar();
            return eventos;
        }

        public List<Evento> Feed()
        {
            List<Evento> eventos = new List<Evento>();

            MySqlDataReader dadosEventos = Query("EventosFeedDeslogado");
            while (dadosEventos.Read())
            {
                eventos.Add(DataReaderToEvento(dadosEventos, false));
            }

            Desconectar();
            return eventos;
        }
         
        public void AdicionarCategorias(int evento, List<Categoria> categorias)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pEvento", evento));

            foreach (Categoria categoria in categorias)
            {
                if (parametros.Count > 1) parametros.RemoveAt(parametros.Count - 1);
                parametros.Add(new MySqlParameter("pCategoria", categoria.Codigo));
                NonQuery("CadastrarCategoriaEvento", parametros);
            }
        }

        public Evento Buscar(int codigo)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            Evento evento = null;
            parametros.Add(new MySqlParameter("pCodigo", codigo));


            MySqlDataReader data = Query("ListarEventos"); 
            List<MySqlParameter> parametroEvento = new List<MySqlParameter>();
   

            parametroEvento.Add(new MySqlParameter("pEvento", codigo));

            while (data.Read())
            {
                evento = DataReaderToEvento(data, false);    
            }


            Desconectar();
            return evento;
        }

        public void Criar(Evento evento)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pCodigo", MaxCodigo()));
            parametros.Add(new MySqlParameter("pResponsavel", evento.Responsavel));
            parametros.Add(new MySqlParameter("pNome", evento.Titulo));
            parametros.Add(new MySqlParameter("pLocal", evento.Local));
            parametros.Add(new MySqlParameter("pDescricao", evento.Descricao));

            NonQuery("CadastrarEvento", parametros);
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            MySqlDataReader data = Query("ListarCategorias");
            while (data.Read())
                categorias.Add(new Categoria(Int32.Parse(data["Codigo"].ToString()), data["Nome"].ToString()));

            return categorias;
        }

        public List<Avaliacao> BuscarAvaliacoes(int codigo)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            List<MySqlParameter> parametro = new List<MySqlParameter>();
            parametro.Add(new MySqlParameter("pEvento", codigo));

            MySqlDataReader data = Query("BuscarAvaliacoesEvento", parametro);

            while (data.Read())
                avaliacoes.Add(new Avaliacao(data["@"].ToString(), Int32.Parse(data["CodigoEvento"].ToString()), data["Descricao"].ToString(), Int32.Parse(data["Estrelas"].ToString())));

            return avaliacoes;
        }

        public string BuscarImagem(int codigo)
        {
            string imagem = "";

            List<MySqlParameter> parametro = new List<MySqlParameter>();
            parametro.Add(new MySqlParameter("pEvento", codigo));

            MySqlDataReader data = Query("BuscarImagemEvento", parametro);

            while (data.Read())
                imagem = data["Imagem"].ToString();

            return imagem;
        }

        public List<Denuncia> BuscarDenuncias(int codigo) {
            List<Denuncia> Denuncias = new List<Denuncia>(); 
            

            return Denuncias;
        }
    }
}