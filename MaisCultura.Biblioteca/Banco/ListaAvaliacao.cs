using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MaisCultura.Biblioteca;
using MySql.Data.MySqlClient;

namespace MaisCultura.Biblioteca
{
    public class ListaAvaliacao : Banco
    {
        Avaliacao DataReaderToAvaliacao(MySqlDataReader data)
        {
            string CodigoUsuario = data["@"].ToString();
            string Descricao = data["Descricao"].ToString();
            int Estrelas = Int32.Parse(data["Estrelas"].ToString());

            return new Avaliacao(CodigoUsuario, 0, Descricao, Estrelas);
        }

        public List<Avaliacao> Listar()
        {
            List<Avaliacao> Avaliacoes = new List<Avaliacao>();

            MySqlDataReader data = Query("ListarAvaliacoes");

            while (data.Read())
                Avaliacoes.Add(DataReaderToAvaliacao(data));

            Desconectar();
            return Avaliacoes;
        }

        public List<Avaliacao> BuscarPorUsuario(string cdUsuario)
        {
            List<Avaliacao> Avaliacoes = new List<Avaliacao>();

            MySqlDataReader data = Query("BuscarAvaliacoesUsuario", ("pCodigo", cdUsuario));

            while (data.Read())
                Avaliacoes.Add(DataReaderToAvaliacao(data));

            Desconectar();
            return Avaliacoes;
        }

        public List<Avaliacao> BuscarPorEvento(int cdEvento)
        {
            List<Avaliacao> Avaliacoes = new List<Avaliacao>();

            MySqlDataReader data = Query("BuscarAvaliacoesEvento", ("pEvento", cdEvento));

            while (data.Read())
                Avaliacoes.Add(DataReaderToAvaliacao(data));

            Desconectar();
            return Avaliacoes;
        }

        public List<Avaliacao> BuscarPorUsuarioEvento(string cdUsuario, int cdEvento)
        {
            List<Avaliacao> Avaliacoes = new List<Avaliacao>();

            MySqlDataReader data = Query("BuscarDenunciasUsuarioEvento", ("pCodigo", cdUsuario), ("pEvento", cdEvento));

            while (data.Read())
                Avaliacoes.Add(DataReaderToAvaliacao(data));

            Desconectar();
            return Avaliacoes;
        }

        public void Avaliar(string codigoUsuario, int codigoEvento, string descricao, int estrelas) {
            NonQuery("CadastrarAvaliacao", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento), ("pDescricao", descricao), ("pEstrelas", estrelas));
        }

        public bool VerificarAvaliacaoPorUsuarioEvento(string cdUsuario, int cdEvento)
        {
            MySqlDataReader data = Query("BuscarAvaliacaoEventoUsuario", ("pUsuario", cdUsuario), ("pEvento", cdEvento));

            bool verify = data != null;

            Desconectar();

            return verify;
        }

        public Avaliacao BuscarAvaliacaoPorUsuarioEvento(string cdUsuario, int cdEvento)
        {
            MySqlDataReader data = Query("BuscarAvaliacaoEventoUsuario", ("pUsuario", cdUsuario), ("pEvento", cdEvento));

            List<Avaliacao> aval = new List<Avaliacao>();

            while (data.Read())
                aval.Add(DataReaderToAvaliacao(data));

            Desconectar();

            return aval[0];
        }

        public void AlterarAvaliacao(string codigoUsuario, int codigoEvento, string descricao, int estrelas) {
            NonQuery("AlterarAvaliacao", ("pUsuario", codigoUsuario), ("pEvento", codigoEvento), ("pDescricao", descricao), ("pEstrelas", estrelas));
        }

    }
}
