using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisCultura
{
    public class Usuario
    {
        public Usuario(string codigo, string tipo, string sexo, string nome, string email, string senha, string documento, string nascimento, List<Categoria> preferencias)
        {
            _codigo = codigo;
            _tipo = tipo;
            _sexo = sexo;
            _nome = nome;
            _email = email;
            _senha = senha;
            _documento = documento;
            _nascimento = nascimento;
            _preferencias = preferencias;
        }

        private string _codigo { get; set; }
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        private string _tipo { get; set; }
        public string Tipo { get { return _tipo; } set { _tipo = value; } }
        private string _sexo { get; set; }
        public string Sexo { get { return _sexo; } set { _sexo = value; } }
        private string _nome { get; set; }
        public string Nome { get { return _nome; } set { _nome = value; } }

        private string _email { get; set; }
        public string Email { get { return _email; } set { _email = value; } }

        private string _senha { get; set; }
        public string Senha { get { return _senha; } set { _senha = value; } }

        private string _documento { get; set; }
        public string Documento { get { return _documento; } set { _documento = value; } }

        private string _nascimento { get; set; }
        public string Nascimento { get { return _nascimento; } set { _nascimento = value; } }

        private List<Categoria> _preferencias { get; set; }
        public List<Categoria> Preferencias { get { return _preferencias; } set { _preferencias = value; } }
    }
}