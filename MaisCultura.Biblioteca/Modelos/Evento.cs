using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca
{
    public class Evento
    {
        public Evento(int codigo, string responsavel, string titulo, string local, string descricao, List<Categoria> categorias, List<DiaEvento> dias)
        {
            Codigo = codigo;
            Responsavel = responsavel;
            Titulo = titulo;
            Local = local;
            Descricao = descricao;
            Categorias = categorias;
            Dias = dias;
        }

        public int Codigo { get; set; }
        public string Responsavel { get; set; }
        public string Titulo { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<DiaEvento> Dias { get; set; }

    }
}