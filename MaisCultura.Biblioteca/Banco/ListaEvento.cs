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
 
        string DateToSqlDate(string data)
        {
            string dia = data.Substring(0, 2);
            string mes = data.Substring(3, 2);
            string ano = data.Substring(6, 4);

            string dataConv = $"{ano}-{mes}-{dia}"; ;

            return dataConv;
        }

        Evento DataReaderToEvento(MySqlDataReader data, bool Reticencias) {
            var cdEvento = Int32.Parse(data["Codigo"].ToString());
            string responsavel = data["@"].ToString();

            string local = data["Local"].ToString();

            if (data["Local"].ToString().Length > 35)
                local = data["Local"].ToString().Substring(0, 35) + "...";

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

            Desconectar();
            return ++codigo;
        }

        public int MaxCodigoImagem()
        {
            int codigo = 0;

            MySqlDataReader data = Query("MaxCodigoImagem");
            while (data.Read())
                codigo = Int32.Parse(data["Max"].ToString());

            Desconectar();
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

        public List<Evento> Feed(string codigo_usuario)
        {
            List<Evento> eventos = new List<Evento>();

            MySqlDataReader dadosEventos;
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

        public List<Evento> Filtro(string categoria)
        {
            List<Evento> eventos = new List<Evento>();

            MySqlDataReader dadosEventos = Query("BuscarEventoCategoria", ("pCat", categoria));

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
            foreach (Categoria categoria in categorias)
                NonQuery("CadastrarCategoriaEvento", ("pEvento", evento), ("pCategoria", categoria.Codigo));
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

        public List<Evento> BuscarPorUsuario(string codigo)
        {
            List<Evento> eventos = new List<Evento>();


            MySqlDataReader data = Query("BuscarEventoUsuario", ("pCodigo", codigo));

            while (data.Read())
            {
                Evento evento = DataReaderToEvento(data, false);
                eventos.Add(evento);
            }

            Desconectar();
            foreach (Evento evento in eventos)
            {
                evento.Categorias = BuscarCategorias(evento.Codigo);
                evento.Dias = BuscarDias(evento.Codigo);
            }

            return eventos;
        }

        public void Criar(Evento evento, string link)
        {
            NonQuery("CadastrarEvento",
                ("pCodigo", MaxCodigo()),
                ("pResponsavel", evento.Responsavel),
                ("pNome"    , evento.Titulo),
                ("pLocal", evento.Local),
                ("pDescricao", evento.Descricao)    
            );

            AdicionarImagem(link, evento.Codigo);
            AdicionarDatas(evento.Codigo, evento.Dias);
            AdicionarCategorias(evento.Codigo, evento.Categorias);
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

        public void Interessar(string codigoUsuario, int codigoEvento)
        {
            NonQuery("AdicionarInteresse", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento));
        }

        public void CancelarInteresse(string codigoUsuario, int codigoEvento)
        {
            NonQuery("RemoverInteresse", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento));
        }

        public bool VerificarInteresse(string codigoUsuario, int codigoEvento)
        {
            MySqlDataReader data = Query("BuscarInteresseUsuarioEvento", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento));

            bool resposta = data.HasRows;

            Desconectar();

            return resposta;
        }

        public (List<Evento>, List<Evento>) GetDiffFeed(string codigo)
        {
            List<Evento> AllEventos = Listar();         //  Todos
            List<Evento> Preferencia = Feed(codigo);    //  Feed
            List<Evento> Diff = new List<Evento>();     //  Todos - Feed

            foreach (Evento evento in AllEventos)
                if (!Preferencia.Contains(evento))
                    Diff.Add(evento);

            return (Diff, Preferencia);
        }

        public (List<Evento>, List<Evento>) GetFeedCreator(string codigo)
        {
            List<Evento> AllEventos = Listar();         //  Todos
            List<Evento> Creator = BuscarPorUsuario(codigo);    //  Feed
            List<Evento> Diff = new List<Evento>();     //  Todos - Feed

            foreach (Evento evento in AllEventos)
                if (!Creator.Contains(evento))
                    Diff.Add(evento);

            return (Diff, Creator);
        }

        public void Salvar(string codigoUsuario, int codigoEvento)
        {
            NonQuery("AdicionarSalvo", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento));
        }

        public void CancelarSalvo(string codigoUsuario, int codigoEvento)
        {
            NonQuery("RemoverSalvo", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento));
        }

        public bool VerificarSalvo(string codigoUsuario, int codigoEvento)
        {
            MySqlDataReader data = Query("BuscarSalvoUsuarioEvento", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento));

            bool resposta = data.HasRows;

            Desconectar();

            return resposta;
        }

        public void AdicionarData(int codigoEvento, DiaEvento dia)
        {
            NonQuery("CadastrarDiaEvento", ("pCodigoEvento", codigoEvento), ("pData", DateToSqlDate(dia.Data)), ("pInicio", $"{dia.Inicio}:00"), ("pFim", $"{dia.Fim}:00"));
        }

        public void AdicionarDatas(int codigoEvento, List<DiaEvento> dias)
        {
            foreach (DiaEvento dia in dias)
                AdicionarData(codigoEvento, dia);
        }

        public void AdicionarImagem(string link, int codigoEvento)
        {
            string maxImagem = MaxCodigoImagem().ToString();

            NonQuery("CadastrarImagem", ("pCodigo", maxImagem), ("pImagem", link));
            NonQuery("AdicionarImagemEvento", ("pCodigoEvento", codigoEvento), ("pCodigoImagem", maxImagem));
        }
    }
}