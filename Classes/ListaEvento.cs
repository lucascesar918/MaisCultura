using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Classes
{
    public class ListaEvento : Banco
    {
        public List<Evento> Listar()
        {
            List<Evento> Eventos = new List<Evento>();

            MySqlDataReader data = Query("ListarEventos");

            List<MySqlParameter> parametroEvento = new List<MySqlParameter>();
            List<Categoria> categorias = new List<Categoria>();
            List<DiaEvento> dias = new List<DiaEvento>();

            while (data.Read())
            {
                parametroEvento.Clear();
                categorias.Clear();
                dias.Clear();

                parametroEvento.Add(new MySqlParameter("pEvento", data["CodigoEvento"].ToString()));

                MySqlDataReader dataCategorias = Query("BuscarCategoriasEvento", parametroEvento);
                MySqlDataReader dataDias = Query("BuscarDiasEvento", parametroEvento);

                while (dataCategorias.Read())
                    categorias.Add(new Categoria(Int32.Parse(data["CodigoCategoria"].ToString()), data["Nome"].ToString()));

                while (dataDias.Read())
                {
                    dias.Add(new DiaEvento(dataDias["Data"].ToString(), dataDias["Inicio"].ToString(), dataDias["Fim"].ToString()));
                }

                string local = data["Local"].ToString();

                string titulo = data["Titulo"].ToString();

                Eventos.Add(new Evento(Int32.Parse(data["CodigoEvento"].ToString()), data["Responsavel"].ToString(), titulo, local, data["Descricao"].ToString(), categorias, dias));
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

        public List<Evento> Feed(string codigo_usuario)
        {
            List<Evento> eventos = new List<Evento>();
            List<MySqlParameter> parametroPreferencia = new List<MySqlParameter>();
            List<MySqlParameter> parametroEvento = new List<MySqlParameter>();
            List<DiaEvento> dias = new List<DiaEvento>();
            List<Categoria> categorias = new List<Categoria>();

            parametroPreferencia.Add(new MySqlParameter("pUsuario", codigo_usuario));

           MySqlDataReader dadosEventos = Query("EventosFeed", parametroPreferencia);
           while (dadosEventos.Read())
           {
                categorias.Clear();
                dias.Clear();

                if (parametroEvento.Count == 0)
                    parametroEvento.Add(new MySqlParameter("pEvento", dadosEventos["Codigo"].ToString()));

                MySqlDataReader dataCategorias = Query("BuscarCategoriasEvento", parametroEvento);
                MySqlDataReader dataDias = Query("BuscarDiasEvento", parametroEvento);

                while (dataCategorias.Read())
                    categorias.Add(new Categoria(Int32.Parse(dataCategorias["CodigoCategoria"].ToString()), dataCategorias["Nome"].ToString()));

                while (dataDias.Read())
                {
                    dias.Add(new DiaEvento(dataDias["Data"].ToString(), dataDias["Inicio"].ToString(), dataDias["Fim"].ToString()));
                }

                    string titulo = dadosEventos["Titulo"].ToString();

                    if (titulo.Length > 35)
                    {
                        titulo = titulo.Substring(0, 32) + "...";
                    }

                    string local = dadosEventos["Local"].ToString();

                    if (local.Length > 30)
                    {
                        local = local.Substring(0, 27) + "...";
                    }

                eventos.Add(new Evento(Int32.Parse(dadosEventos["Codigo"].ToString()), dadosEventos["@"].ToString(), titulo, local, dadosEventos["Descricao"].ToString(), categorias, dias));
                }

            Desconectar();
            return eventos;
        }

        public List<Evento> Feed()
        {
            List<Evento> eventos = new List<Evento>();
            List<DiaEvento> dias = new List<DiaEvento>();
            List<Categoria> categorias = new List<Categoria>();

            MySqlDataReader dadosEventos = Query("EventosFeedDeslogado");
            while (dadosEventos.Read())
            {
                int codigo_evento = Int32.Parse(dadosEventos["Codigo"].ToString());

                categorias = BuscarCategorias(codigo_evento);
                dias = BuscarDias(codigo_evento);

                string titulo = dadosEventos["Titulo"].ToString();

                if (titulo.Length > 35)
                {
                    titulo = titulo.Substring(0, 32) + "...";
                }

                string local = dadosEventos["Local"].ToString();

                if (local.Length > 30)
                {
                    local = local.Substring(0, 27) + "...";
                }

                eventos.Add(new Evento(codigo_evento, dadosEventos["@"].ToString(), titulo, local, dadosEventos["Descricao"].ToString(), categorias, dias));
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
            List<Categoria> categorias = new List<Categoria>();
            List<DiaEvento> dias = new List<DiaEvento>();

            parametroEvento.Add(new MySqlParameter("pEvento", codigo));

            while (data.Read())
            {

                MySqlDataReader dataCategorias = Query("BuscarCategoriasEvento", parametroEvento);
                MySqlDataReader dataDias = Query("BuscarDiasEvento", parametroEvento);

                while (dataCategorias.Read())
                    categorias.Add(new Categoria(Int32.Parse(data["CodigoCategoria"].ToString()), data["Nome"].ToString()));

                while (dataDias.Read())
                {
                    dias.Add(new DiaEvento(dataDias["Data"].ToString(), dataDias["Inicio"].ToString(), dataDias["Fim"].ToString()));
                }


                evento = new Evento(Int32.Parse(data["CodigoEvento"].ToString()), data["Responsavel"].ToString(), data["Titulo"].ToString(), data["Local"].ToString(), data["Descricao"].ToString(), categorias, dias);
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