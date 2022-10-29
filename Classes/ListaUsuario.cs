using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Classes
{
    public class ListaUsuario : Banco
    {
        public List<Usuario> Listar()
        {
            List<Usuario> Usuarios = new List<Usuario>();

            MySqlDataReader data = Query("ListarUsuarios");
            while (data.Read())
            {
                List<Categoria> categorias = new List<Categoria>();
                List<MySqlParameter> parametro = new List<MySqlParameter>();
                parametro.Add(new MySqlParameter("pCodigo", data["@"].ToString()));
                MySqlDataReader dataPref = Query("ListarPreferenciasUsuario", parametro);
                while (dataPref.Read())
                    categorias.Add(new Categoria(Int32.Parse(dataPref["CodigoCategoria"].ToString()), dataPref["Nome"].ToString()));


                Usuarios.Add(new Usuario(data["@"].ToString(), data["Tipo"].ToString(), data["Sexo"].ToString(), data["Nome"].ToString(), data["Email"].ToString(), data["Senha"].ToString(), data["Documento"].ToString(), data["Nascimento"].ToString(), categorias));
            }

            Desconectar();
            return Usuarios;
        }

        public Usuario Buscar(string codigo)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            Usuario usuario = null;
            parametros.Add(new MySqlParameter("pCodigo", codigo));

            MySqlDataReader data = Query("BuscarUsuario", parametros);

            while (data.Read())
            {
                List<Categoria> categorias = new List<Categoria>();
                List<MySqlParameter> parametro = new List<MySqlParameter>();
                parametro.Add(new MySqlParameter("pCodigo", codigo));
                MySqlDataReader dataPref = Query("ListarPreferenciasUsuario", parametro);
                while (dataPref.Read())
                    categorias.Add(new Categoria(Int32.Parse(dataPref["CodigoCategoria"].ToString()), dataPref["Nome"].ToString()));

                usuario = new Usuario(data["@"].ToString(), data["Tipo"].ToString(), data["Sexo"].ToString(), data["Nome"].ToString(), data["Email"].ToString(), data["Senha"].ToString(), data["Documento"].ToString(), data["Nascimento"].ToString(), categorias);
            }

            Desconectar();
            return usuario;
        }

        public Usuario BuscarLogin(string codigo, string senha)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            Usuario usuario = null;
            parametros.Add(new MySqlParameter("pCodigo", codigo));
            parametros.Add(new MySqlParameter("pSenha", senha));

            MySqlDataReader data = Query("BuscarLogin", parametros);

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
            parametros.Add(new MySqlParameter("pCodigo", usuario.Codigo));
            parametros.Add(new MySqlParameter("pTipo", usuario.Tipo));
            parametros.Add(new MySqlParameter("pSigla", usuario.Sexo));
            parametros.Add(new MySqlParameter("pNome", usuario.Nome));
            parametros.Add(new MySqlParameter("pEmail", usuario.Email));
            parametros.Add(new MySqlParameter("pSenha", usuario.Senha));
            parametros.Add(new MySqlParameter("pDocumento", usuario.Documento));
            parametros.Add(new MySqlParameter("pNascimento", usuario.Nascimento));

            NonQuery("CadastrarUsuario", parametros);
        }

        public void AdicionarPreferencias(string codigo, List<Categoria> preferencias)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pUsuario", codigo));

            foreach (Categoria preferencia in preferencias)
            {
                if (parametros.Count > 1) parametros.RemoveAt(parametros.Count - 1);
                parametros.Add(new MySqlParameter("pCategoria", preferencia.Codigo));
                NonQuery("CadastrarPreferencia", parametros);
            }
        }

        public List<Avaliacao> BuscarAvaliacoes(string codigo)
        {
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            List<MySqlParameter> parametro = new List<MySqlParameter>();
            parametro.Add(new MySqlParameter("pUsuario", codigo));

            MySqlDataReader data = Query("BuscarAvaliacoesUsuario", parametro);

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