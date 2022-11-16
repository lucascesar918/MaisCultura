using System;
using System.Collections.Generic;
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

        //public Denuncia Buscar() { 

        //}
    }
}
