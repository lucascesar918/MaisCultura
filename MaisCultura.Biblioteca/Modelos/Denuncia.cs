using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca
{
    public class Denuncia
    {
        public Denuncia(int codigoDenuncia, int codigoEvento, string descricao, string codigoUsuario, DateTime date)
        {
            CodigoDenuncia = codigoDenuncia;
            CodigoEvento = codigoEvento;
            Descricao = descricao;
            CodigoUsuario = codigoUsuario;
            Data = date;
        }

        public int CodigoDenuncia { get; set; }

        public int CodigoEvento { get; set; }

        public string Descricao { get; set; }

        public string CodigoUsuario { get; set; }

        public DateTime Data { get; set; }

        public Motivo Motivo { get; set; }
    }

    public class Motivo
    {
        public Motivo(int codigoMotivo, string nome)
        {
            CodigoMotivo = codigoMotivo;
            Nome = nome;
        }

        public int CodigoMotivo { get; set; }

        public string Nome { get; set; }

    }
}