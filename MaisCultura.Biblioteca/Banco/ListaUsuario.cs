using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Biblioteca;

namespace Biblioteca
{
    public class ListaUsuario : Banco
    {
        Usuario DataReaderToUsuario(MySqlDataReader data){
            var cdUsuario = data["@"].ToString();
            List<Categoria> categorias = new List<Categoria>();
            MySqlDataReader dataPref = Query("ListarPreferenciasUsuario", ("pCodigo", cdUsuario));

            while (dataPref.Read())
                categorias.Add(new Categoria(Int32.Parse(dataPref["CodigoCategoria"].ToString()), dataPref["Nome"].ToString()));

            return new Usuario(data["@"].ToString(), data["Tipo"].ToString(), data["Sexo"].ToString(), data["Nome"].ToString(), data["Email"].ToString(), data["Senha"].ToString(), data["Documento"].ToString(), data["Nascimento"].ToString(), categorias);
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
            return Usuarios;
        }

        public Usuario Buscar(string codigo)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            Usuario usuario = null;
            MySqlDataReader data = Query("BuscarUsuario", ("pCodigo", codigo));

            while (data.Read())
            {
                usuario = DataReaderToUsuario(data);
            }

            Desconectar();
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


            NonQuery("CadastrarUsuario",
                ("pCodigo", usuario.Codigo),
                ("pTipo", usuario.Tipo),
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

        public List<Avaliacao> BuscarAvaliacoes(string codigo)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            MySqlDataReader data = Query("BuscarAvaliacoesUsuario", ("pUsuario", codigo));
            
            while (data.Read())
                avaliacoes.Add(new Avaliacao(data["@"].ToString(), Int32.Parse(data["CodigoEvento"].ToString()), data["Descricao"].ToString(), Int32.Parse(data["Estrelas"].ToString())));

            return avaliacoes;
        }

        public List<Denuncia> BuscarDenuncias(string codigo)
        {
            List<Denuncia> denuncias = new List<Denuncia>();

            MySqlDataReader data = Query("BuscarDenuncias");

            while (data.Read()) {
                denuncias.Add(new Denuncia(Int32.Parse(data["CodigoDenuncia"].ToString()), Int32.Parse(data["CodigoEvento"].ToString()), data["Descricao"].ToString(), data["@"].ToString(), DateTime.Parse(data["Data"].ToString())));                
            }

            Desconectar();

            return denuncias;
        }
    }
}