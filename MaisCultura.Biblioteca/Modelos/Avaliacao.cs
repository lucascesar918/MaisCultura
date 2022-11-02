using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisCultura.Biblioteca
{
    public class Avaliacao
    {
        public Avaliacao(string codigoUsuario, int codigoEvento, string descricao, int estrelas)
        {
            CodigoUsuario = codigoUsuario;
            CodigoEvento = codigoEvento;
            Descricao = descricao;
            Estrelas = estrelas;
        }

        public string CodigoUsuario { get; set; }

        public int CodigoEvento { get; set; }

        public string Descricao { get; set; }

        public int Estrelas { get; set; }
    }
}