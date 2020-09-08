using CarteiraConsole.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarteiraConsole.Entidades
{
    public class Ordem
    {
        public DateTime Data { get; set; }
        public TipoOrdem Tipo { get; set; }
        public Ativo Ativo { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        public Ordem(DateTime data, TipoOrdem tipo, Ativo ativo, int quantidade, double valor)
        {
            Data = data;
            Tipo = tipo;
            Ativo = ativo;
            Quantidade = quantidade;
            Valor = valor;
        }
    }
}
