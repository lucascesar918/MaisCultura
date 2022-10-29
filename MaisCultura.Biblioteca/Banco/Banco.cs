using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MaisCultura
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

        public MySqlDataReader Query(string comando)
        {
            try
            {
                Conectar();

                MySqlCommand cSQL = new MySqlCommand(comando, this._conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                return cSQL.ExecuteReader();

            }
            catch
            {
                throw new Exception("Erro ao contatar o servidor!");
            }
        }

        public MySqlDataReader Query(string comando, List<MySqlParameter> parametros)
        {
            try
            {
                Conectar();

                MySqlCommand cSQL = new MySqlCommand(comando, this._conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parametro in parametros)
                    cSQL.Parameters.Add(parametro);

                return cSQL.ExecuteReader();

            }
            catch
            {
                throw new Exception("Erro ao contatar o servidor!");
            }
        }

        public void NonQuery(string comando, List<MySqlParameter> parametros)
        {
            try
            {
                Conectar();

                MySqlCommand cSQL = new MySqlCommand(comando, this._conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (MySqlParameter parametro in parametros)
                    cSQL.Parameters.Add(parametro);


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