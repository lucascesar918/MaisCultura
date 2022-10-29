using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisCultura
{
    public class Evento
    {
        public Evento(int codigo, string responsavel, string titulo, string local, string descricao, List<Categoria> categorias, List<DiaEvento> dias)
        {
            _codigo = codigo;
            _responsavel = responsavel;
            _titulo = titulo;
            _local = local;
            _descricao = descricao;
            _categorias = categorias;
            _dias = dias;
        }

        private int _codigo { get; set; }
        public int Codigo { get { return _codigo; } set { _codigo = value; } }

        private string _responsavel { get; set; }
        public string Responsavel { get { return _responsavel; } set { _responsavel = value; } }

        private string _titulo { get; set; }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }

        private string _local { get; set; }
        public string Local { get { return _local; } set { _local = value; } }

        private string _descricao { get; set; }
        public string Descricao { get { return _descricao; } set { _descricao = value; } }

        private List<Categoria> _categorias { get; set; }
        public List<Categoria> Categorias { get { return _categorias; } set { _categorias = value; } }

        private List<DiaEvento> _dias;


        public List<DiaEvento> Dias
        {
            get { return _dias; }
            set { _dias = value; }
        }


    }
}