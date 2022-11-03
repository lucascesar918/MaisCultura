using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using MySql.Data.MySqlClient;
using Biblioteca;

namespace Biblioteca
{
    public class ListaEvento : Banco
    {
        string AdicionarReticencia(string str, int TamanhoMaximo)
        {
            return str.Length > TamanhoMaximo ? str.Substring(0, TamanhoMaximo - 3) + "..." : str;
        }
 
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
            MySqlDataReader data = Query("BuscarCategoriasEvento", ("pEvento", codigo_evento));
            while (data.Read())
                categorias.Add(new Categoria(Int32.Parse(data["CodigoCategoria"].ToString()), data["Nome"].ToString()));

            Desconectar();
            return categorias;
        }

        public List<DiaEvento> BuscarDias(int codigo_evento)
        {
            List<DiaEvento> dias = new List<DiaEvento>();

            MySqlDataReader data = Query("BuscarDiasEvento", ("pEvento", codigo_evento));

            while (data.Read())
                dias.Add(new DiaEvento(data["Data"].ToString(), data["Inicio"].ToString(), data["Fim"].ToString()));

            Desconectar();
            return dias;
        }
        public List<Evento> Feed(string codigo_usuario = null)
        {
            List<Evento> eventos = new List<Evento>();

            MySqlDataReader dadosEventos;
            if (codigo_usuario == null)
                dadosEventos = Query("EventosFeedDeslogado");
            else 
                dadosEventos = Query("EventosFeed", ("pUsuario", codigo_usuario));
           while (dadosEventos.Read())
           { 
                eventos.Add(DataReaderToEvento(dadosEventos, true));
           }

            Desconectar();
            return eventos;
        }

         
        public void AdicionarCategorias(int evento, List<Categoria> categorias)
        {

            foreach (Categoria categoria in categorias) {
                NonQuery("CadastrarCategoriaEvento", ("pEvento", evento), ("pCategoria", categoria.Codigo));
            }
        }

        public Evento Buscar(int codigo)
        {
            Evento evento = null;


            MySqlDataReader data = Query("ListarEventos"); 

            while (data.Read())
            {
                evento = DataReaderToEvento(data, false);    
            }

            Desconectar();
            return evento;
        }

        public void Criar(Evento evento)
        { 
            NonQuery("CadastrarEvento",
                ("pCodigo", MaxCodigo()),
                ("pResponsavel", evento.Responsavel),
                ("pNome"    , evento.Titulo),
                ("pLocal", evento.Local),
                ("pDescricao", evento.Descricao)    
            );
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

            MySqlDataReader data = Query("BuscarAvaliacoesEvento", ("pEvento", codigo));

            while (data.Read())
                avaliacoes.Add(new Avaliacao(data["@"].ToString(), Int32.Parse(data["CodigoEvento"].ToString()), data["Descricao"].ToString(), Int32.Parse(data["Estrelas"].ToString())));

            return avaliacoes;
        }

        public string BuscarImagem(int codigo)
        {
            string imagem = "";

            MySqlDataReader data = Query("BuscarImagemEvento", ("pEvento", codigo));

            while (data.Read())
                imagem = data["Imagem"].ToString();

            return imagem;
        }

        public List<Denuncia> BuscarDenuncias(int codigo) {
            List<Denuncia> Denuncias = new List<Denuncia>(); 
            

            return Denuncias;
        }

        public int? MediaEstrelas(int codigo)
        {
            var Media = (Decimal)Scalar("MediaAvaliacao", ("pEvento", codigo));
            return Decimal.ToInt32(Media);
        }
    }
}