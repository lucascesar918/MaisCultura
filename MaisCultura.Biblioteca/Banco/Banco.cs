using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
    public class Banco
    {
        private string LinhaConexao { get; set; }
        MySqlConnection _conexao = null;

        public Banco()
        {
            LinhaConexao = Conexao.linhaConexao;
        }

        private void Conectar()
        {
            _conexao = new MySqlConnection(LinhaConexao);
            try
            {
                this._conexao.Open();

            }
            catch
            {
                throw new Exception("Erro ao tentar conectar ao servidor!");
            }

        }

        protected void Desconectar()
        {
            if (_conexao != null && _conexao.State == System.Data.ConnectionState.Open)
                this._conexao.Close();
        }

        public MySqlCommand CriarProcedure(string comando, params (string nome, object valor)[] parametros)
        {
            MySqlCommand cSQL = new MySqlCommand(comando, _conexao);
            cSQL.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
                cSQL.Parameters.AddWithValue(parametro.nome, parametro.valor);
            return cSQL;
        }
        public MySqlDataReader Query(string comando, params (string nome, object valor)[] parametros)
        {
            try
            {
                Conectar();
                MySqlCommand cSQL = CriarProcedure(comando, parametros);
                return cSQL.ExecuteReader();

            }
            catch(Exception Ex)
            {
                throw new Exception("Erro ao contatar o servidor!", Ex);
            }
        }
        public object Scalar(string comando, params (string nome, object valor)[] parametros)
        {
            try
            {
                Conectar();
                MySqlCommand cSQL = CriarProcedure(comando, parametros);
                return cSQL.ExecuteScalar();

            }
            catch(Exception Ex)
            {
                throw new Exception("Erro ao contatar o servidor!", Ex);
            }
        }

        public void NonQuery(string comando, params (string nome, object valor)[] parametros)
        {
            try
            {
                Conectar();

                MySqlCommand cSQL = CriarProcedure(comando, parametros);

                cSQL.ExecuteNonQuery();
                Desconectar();

            }
            catch
            {
                throw new Exception("Erro ao executar comando no servidor!");
            }
        }
    }
}