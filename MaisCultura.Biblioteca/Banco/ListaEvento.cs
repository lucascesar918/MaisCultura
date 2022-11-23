using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using MySql.Data.MySqlClient;
using MaisCultura.Biblioteca;

namespace MaisCultura.Biblioteca
{
    public class ListaEvento : Banco
    {
        string AdicionarReticencia(string str, int TamanhoMaximo)
        {
            return str.Length > TamanhoMaximo ? str.Substring(0, TamanhoMaximo - 3) + "..." : str;
        }
 
        Evento DataReaderToEvento(MySqlDataReader data, bool Reticencias) {
            var cdEvento = Int32.Parse(data["Codigo"].ToString());
            string responsavel = data["@"].ToString();
            string local = data["Local"].ToString();
            string titulo = data["Titulo"].ToString();
            string descricao = data["Descricao"].ToString();
            if (Reticencias) {
                titulo = AdicionarReticencia(titulo, 35);
                local = AdicionarReticencia(local, 27);
            }
            return new Evento( cdEvento,responsavel , titulo, local, descricao,  null, null);
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
            foreach (Evento Evento in Eventos)
            {
                Evento.Categorias = BuscarCategorias(Evento.Codigo);
                Evento.Dias = BuscarDias(Evento.Codigo);
            }
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
                dadosEventos = Query("ListarEventosFeedDeslogado");
            else 
                dadosEventos = Query("ListarEventosFeed", ("pUsuario", codigo_usuario));

           while (dadosEventos.Read())
                eventos.Add(DataReaderToEvento(dadosEventos, true));

            Desconectar();

            foreach (Evento Evento in eventos)
            {
                Evento.Categorias = BuscarCategorias(Evento.Codigo);
                Evento.Dias = BuscarDias(Evento.Codigo);
            }
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


            MySqlDataReader data = Query("BuscarEvento", ("pCodigo", codigo)); 

            while (data.Read())
            {
                evento = DataReaderToEvento(data, false);    
            }

            Desconectar();

            evento.Categorias = BuscarCategorias(evento.Codigo);
            evento.Dias = BuscarDias(evento.Codigo);

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
            Desconectar();
            return categorias;
        }

        public List<Avaliacao> BuscarAvaliacoes(int codigo)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();

            MySqlDataReader data = Query("BuscarAvaliacoesEvento", ("pEvento", codigo));

            while (data.Read())
                avaliacoes.Add(new Avaliacao(data["@"].ToString(), Int32.Parse(data["CodigoEvento"].ToString()), data["Descricao"].ToString(), Int32.Parse(data["Estrelas"].ToString())));
            Desconectar();
            return avaliacoes;
        }

        public List<string> BuscarImagem(int codigo)
        {
            List<string> imagens = new List<string>();

            MySqlDataReader data = Query("BuscarImagemEvento", ("pEvento", codigo));

            while (data.Read())
                imagens.Add(data["Imagem"].ToString());

            Desconectar();
            return imagens;
        }

        public int? MediaEstrelas(int codigo)
        {
            var Media = (Decimal)Scalar("MediaAvaliacao", ("pEvento", codigo));

            Desconectar();
            return Decimal.ToInt32(Media);
        }

        public int BuscarInteresses(int codigo)
        {
            MySqlDataReader data = Query("BuscarInteressesEvento", ("pEvento", codigo));
            data.Read();

            int interesses = Int32.Parse(data["Soma"].ToString());

            Desconectar();

            return interesses;
        }

        public void Deletar(int codigo) {
            NonQuery("DeletarEvento", ("pCodigo", codigo));
        }
    }
}