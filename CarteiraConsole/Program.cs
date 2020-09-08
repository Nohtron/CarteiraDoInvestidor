using CarteiraConsole.Entidades;
using CarteiraConsole.Enumerados;
using System;

namespace CarteiraConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Digite o código do ativo: ");
            string codigoNegociacao = "PETR4";
            string descricaoAtivo = "Petroleo Brasileiro SA";
            string cnpj = "33.000.167/0001-01";

            Ativo pret4 = new Ativo(codigoNegociacao, descricaoAtivo, cnpj);

            DateTime data = DateTime.Now;
            TipoOrdem compra = TipoOrdem.Compra;
            TipoOrdem venda = TipoOrdem.Venda;

            int quantidade = 100;
            double precoTotal = 2000.00;

            Ordem ordem1 = new Ordem(data, compra, pret4, quantidade, precoTotal);
            Ordem ordem2 = new Ordem(data, venda, pret4, quantidade, precoTotal);
            Ordem ordem3 = new Ordem(data, venda, pret4, quantidade, precoTotal);
            Ordem ordem4 = new Ordem(data, compra, pret4, quantidade, precoTotal);

            Posicao posicao = new Posicao(pret4);

            posicao.AdicionarOrdem(ordem1);
            posicao.AdicionarOrdem(ordem2);
            posicao.AdicionarOrdem(ordem3);
            posicao.AdicionarOrdem(ordem4);

            Carteira carteira = new Carteira("Minha Carteira");

            carteira.AdicionarPosicao(posicao);

            carteira.ImprimePosicoesAbertas();
        }
    }
}
