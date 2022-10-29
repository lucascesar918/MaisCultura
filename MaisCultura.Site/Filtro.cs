using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MaisCultura
{
    class Filtro
    {
        public List<string> Categorias;
        public string Local;
        public DateTime? Inicio;
        public DateTime? Fim;
        public int QtEstrelas;


        public bool Verificar(Evento evento)
        {
            return VerificarLocal(evento)
                && VerificarInicio(evento)
                && VerificarFim(evento)
                && VerificarCategorias(evento);

        }

        bool VerificarLocal(Evento evento)
        {
            if (Local == null)
                return true;
            return evento.Local.ToLower().Contains(Local.ToLower());
        }

        bool VerificarInicio(Evento evento)
        {
            if (Inicio == null)
                return true;
            Debug.WriteLine(string.Join(";", evento.Dias.Select(d=>d.Data)));
            return evento.Dias.Any( (dia) => Inicio <= dia.Data );
        }
        bool VerificarFim(Evento evento)
        {
            if (Fim == null)
                return true; 
            return evento.Dias.Any((dia) => dia.Data <= Fim); 
        }
        bool VerificarCategorias(Evento evento)
        {
            if (Categorias?.DefaultIfEmpty() == null )
                return true;
            return Categorias.Any(filtroCat => 
            string.IsNullOrEmpty(filtroCat)  || 
            evento.Categorias.Any((categoria) => filtroCat == categoria.Nome));
        }
    }
}