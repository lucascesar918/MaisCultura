﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisCultura.Biblioteca
{
    [Serializable]
    public class Categoria
    {
        public Categoria(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get; set; }

        public string Nome { get; set; }
    }
}