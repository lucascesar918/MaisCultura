using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MaisCultura.Biblioteca;

namespace MaisCultura.Biblioteca
{
    public class ListaUsuario : Banco
    {
        Usuario DataReaderToUsuario(MySqlDataReader data)
        {
            return new Usuario(data["@"].ToString(), data["Tipo"].ToString(), data["Sexo"].ToString(), data["Nome"].ToString(), data["Email"].ToString(), data["Senha"].ToString(), data["Documento"].ToString(), data["Nascimento"].ToString(), null);
        }

        private List<Categoria> BuscarPreferencias(string cdUsuario)
        {
            List<Categoria> categorias = new List<Categoria>();
            MySqlDataReader dataPref = Query("ListarPreferenciasUsuario", ("pCodigo", cdUsuario));

            while (dataPref.Read())
                categorias.Add(new Categoria(Int32.Parse(dataPref["CodigoCategoria"].ToString()), dataPref["Nome"].ToString()));
            Desconectar();
            return categorias;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            MySqlDataReader data = Query("ListarUsuarios");
            while (data.Read())
            {
                Usuarios.Add(DataReaderToUsuario(data));
            }

            Desconectar();
            foreach (Usuario usuario in Usuarios)
                usuario.Preferencias = BuscarPreferencias(usuario.Codigo);

            return Usuarios;
        }

        public Usuario Buscar(string codigo)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            Usuario usuario = null;
            MySqlDataReader data = Query("BuscarUsuario", ("pCodigo", codigo));

            while (data.Read()) usuario = DataReaderToUsuario(data);
            Desconectar();

            if (usuario != null) usuario.Preferencias = BuscarPreferencias(usuario.Codigo);

            return usuario;
        }

        public Usuario BuscarLogin(string codigo, string senha)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            Usuario usuario = null;
            MySqlDataReader data = Query("BuscarLogin", ("pCodigo", codigo), ("pSenha", senha));

            while (data.Read())
            {
                usuario = new Usuario(data["@"].ToString(), data["Tipo"].ToString(), data["Sexo"].ToString(), data["Nome"].ToString(), data["Email"].ToString(), data["Senha"].ToString(), data["Documento"].ToString(), data["Nascimento"].ToString(), null);
            }

            Desconectar();
            return usuario;
        }

        public void CriarUsuario(Usuario usuario)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();

            int tipo;

            switch (usuario.Tipo)
            {
                case "Usuário Comum":
                    tipo = 2;
                    break;

                case "Criador de Eventos":
                    tipo = 3;
                    break;

                case "Empresa":
                    tipo = 4;
                    break;

                default:
                    tipo = 1;
                    break;
            }


            NonQuery("CadastrarUsuario",
                ("pCodigo", usuario.Codigo),
                ("pTipo", tipo),
                ("pSigla", usuario.Sexo),
                ("pNome", usuario.Nome),
                ("pEmail", usuario.Email),
                ("pSenha", usuario.Senha),
                ("pDocumento", usuario.Documento),
                ("pNascimento", usuario.Nascimento)
            );
        }

        public void AdicionarPreferencias(string codigo, List<Categoria> preferencias)
        {
            foreach (Categoria preferencia in preferencias)
                NonQuery("CadastrarPreferencia", ("pUsuario", codigo), ("pCategoria", preferencia.Codigo));
        }

        public void DeletarPreferencia(string codigo, List<Categoria> preferencias)
        {
            foreach (Categoria preferencia in preferencias)
                NonQuery("DeletarPreferencia", ("pUsuario", codigo), ("pCategoria", preferencia.Codigo));
        }

        public void AlterarPreferencia(string codigo, List<Categoria> preferencias)
        {
            foreach (Categoria preferencia in preferencias)
                NonQuery("AlterarPreferencia", ("pUsuario", codigo), ("pCategoria", preferencia.Codigo));
        }

        public List<Avaliacao> BuscarAvaliacoes(string codigo)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            MySqlDataReader data = Query("BuscarAvaliacoesUsuario", ("pUsuario", codigo));

            while (data.Read())
                avaliacoes.Add(new Avaliacao(data["@"].ToString(), Int32.Parse(data["CodigoEvento"].ToString()), data["Descricao"].ToString(), Int32.Parse(data["Estrelas"].ToString())));

            return avaliacoes;
        }

        public float BuscarMediaCriador(string codigo)
        {
            MySqlDataReader data = Query("BuscarMediaCriador", ("pCodigo", codigo));
            float media = 0;

            while (data.Read())
            {
                try { media = float.Parse(data["soma"].ToString()); }
                catch { media = 0; }
            }

            Desconectar();
            return media;
        }

        public void Deletar(string codigo)
        {
            NonQuery("DeletarUsuario", ("pCodigo", codigo));
        }

        public void AlterarSenha(string codigo, string senha)
        {
            NonQuery("AlterarSenha", ("pUsuario", codigo), ("pSenha", senha));
        }
    }
}