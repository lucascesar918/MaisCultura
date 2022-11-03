using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
    public class ListaDenuncia : Banco
    {
        Denuncia DataReaderToDenuncia(MySqlDataReader data) {
            int CodigoDenuncia = Int32.Parse(data["CodigoDenuncia"].ToString());
            int CodigoEvento = Int32.Parse(data["CodigoEvento"].ToString());
            string CodigoUsuario = data["@"].ToString();
            DateTime Data = Convert.ToDateTime(data["Data"].ToString() + " " + data["Hora"].ToString());
            string Descricao = data["Descricao"].ToString();

            return new Denuncia(CodigoDenuncia, CodigoEvento, Descricao, CodigoUsuario, Data);
        }

        public List<Denuncia> Listar() {
            List<Denuncia> Denuncias = new List<Denuncia>();

            MySqlDataReader data = Query("ListarDenuncias");

            while (data.Read())
                Denuncias.Add(DataReaderToDenuncia(data));

            return Denuncias;
        }
    }
}