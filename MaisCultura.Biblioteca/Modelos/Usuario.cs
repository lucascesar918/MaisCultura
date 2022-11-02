using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisCultura.Biblioteca
{
    public class Usuario
    {
        public Usuario(string codigo, string tipo, string sexo, string nome, string email, string senha, string documento, string nascimento, List<Categoria> preferencias)
        {
            Codigo = codigo;
            Tipo = tipo;
            Sexo = sexo;
            Nome = nome;
            Email = email;
            Senha = senha;
            Documento = documento;
            Nascimento = nascimento;
            Preferencias = preferencias;
        }

        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Documento { get; set; }
        public string Nascimento { get; set; }
        public List<Categoria> Preferencias { get; set; }
    }
}