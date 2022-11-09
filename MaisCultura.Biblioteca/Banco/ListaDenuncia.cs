using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MaisCultura.Biblioteca
{
    public class ListaDenuncia : Banco
    {
        Denuncia DataReaderToDenuncia(MySqlDataReader data) {
            int CodigoDenuncia = Int32.Parse(data["CodigoDenuncia"].ToString());
            
            int CodigoEvento = Int32.Parse(data["Codigo"].ToString());
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

        public List<Denuncia> BuscarPorUsuario(string cdUsuario) { 
            List<Denuncia> denuncias = new List<Denuncia>();

            MySqlDataReader data = Query("BuscarDenunciasUsuario", ("pCodigo", cdUsuario));

            while (data.Read())
                denuncias.Add(DataReaderToDenuncia(data));

            return denuncias;
        }

        public List<Denuncia> BuscarPorEvento(int cdEvento) {
            List<Denuncia> denuncias = new List<Denuncia>();

            MySqlDataReader data = Query("BuscarDenunciasEvento", ("pEvento", cdEvento));

            while (data.Read())
                denuncias.Add(DataReaderToDenuncia(data));

            return denuncias;
        }

        public List<Denuncia> BuscarPorUsuarioEvento(string cdUsuario, int cdEvento) {
            List<Denuncia> denuncias = new List<Denuncia>();

            MySqlDataReader data = Query("BuscarDenunciasUsuarioEvento", ("pCodigo", cdUsuario), ("pEvento", cdEvento));

            while (data.Read())
                denuncias.Add(DataReaderToDenuncia(data));

            return denuncias;
        }

        //public Denuncia Buscar() { 
        
        //}
    }
}