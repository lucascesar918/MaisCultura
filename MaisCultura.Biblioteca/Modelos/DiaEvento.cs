﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaisCultura.Biblioteca
{
    public class DiaEvento
    {
        public DateTime SqlDateToDatetime(string data)
        {
            DateTime convertido;

            string dia;
            string mes;
            string ano;

            if (data[5] == '/')
            {
                dia = data.Substring(0,2);
                mes = data.Substring(3,2);
                ano = data.Substring(6,4);
            }
            else
            {
                dia = data.Substring(8,2);
                mes = data.Substring(5,2);
                ano = data.Substring(0,4);
            }

            convertido = DateTime.Parse($"{dia}/{mes}/{ano}");

            return convertido;
        }

        public DateTime SqlTimeToDatetime(string tempo)
        {
            DateTime convertido;

            int hora = Int32.Parse(tempo.Substring(0,2));
            int minuto = Int32.Parse(tempo.Substring(3,2));
            int segundo = Int32.Parse(tempo.Substring(6,2));

            DateTime Agora = DateTime.Now;
            convertido = new DateTime(Agora.Year, Agora.Month, Agora.Day, hora, minuto, segundo);

            return convertido;
        }


        public DiaEvento(string data, string inicio, string fim)
        {
            Data = DateTime.Parse(data).ToShortDateString();
            Inicio = DateTime.Parse(inicio).ToShortTimeString();
            Fim = DateTime.Parse(fim).ToShortTimeString();
        }


        private string _data;
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private string _inicio;
        public string Inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }

        private string _fim;
        public string Fim
        {
            get { return _fim; }
            set { _fim = value; }
        }

    }
}