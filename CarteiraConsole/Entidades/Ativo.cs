using System;
using System.Collections.Generic;
using System.Text;

namespace CarteiraConsole.Entidades
{
    public class Ativo
    {
        public string CodigoNegociacao { get; set; }
        public string Descrição { get; set; }
        public string CNPJ { get; set; }

        public Ativo(string codigoNegociacao, string descrição, string cNPJ)
        {
            CodigoNegociacao = codigoNegociacao;
            Descrição = descrição;
            CNPJ = cNPJ;
        }

        public override string ToString()
        {
            return
                $"Código Negociação: {CodigoNegociacao}" +
                $"CNPJ: {CNPJ}";
        }
    }
}
