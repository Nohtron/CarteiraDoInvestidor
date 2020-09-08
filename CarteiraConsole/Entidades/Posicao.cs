using CarteiraConsole.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiraConsole.Entidades
{
    class Posicao
    {
        public List<Ordem> Ordens { get; set; }
        public Ativo Ativo { get; set; }
        public StatusPosicao Status { get; set; }

        public Posicao(Ativo ativo)
        {
            Ativo = ativo;
            Ordens = new List<Ordem>();
            Status = StatusPosicao.Aberta;
        }

        public void AdicionarOrdem(Ordem ordem)
        {
            if (Ativo.CodigoNegociacao.Equals(ordem.Ativo.CodigoNegociacao))
            {
                if (Status == StatusPosicao.Aberta)
                {
                    Ordens.Add(ordem);

                    Status = VerificarStatusAtualDaPosicao();
                }
            }            
        }

        public StatusPosicao VerificarStatusAtualDaPosicao()
        {
            if (Ordens.Count < 2)
            {
                return StatusPosicao.Aberta;
            }
            else
            {
                int quantidadeCompra = Ordens.Where(o => o.Tipo == TipoOrdem.Compra).Sum(o => o.Quantidade);
                int quantidadeVenda = Ordens.Where(o => o.Tipo == TipoOrdem.Venda).Sum(o => o.Quantidade);

                if (quantidadeCompra == quantidadeVenda)
                {
                    return StatusPosicao.Fechada;
                }
            }

            return StatusPosicao.Aberta;
        }

        public override string ToString()
        {
            string codigoAtivo = Ativo.CodigoNegociacao;
            int quantidadeCompra = Ordens.Where(o => o.Tipo == TipoOrdem.Compra).Sum(o => o.Quantidade);
            int quantidadeVenda = Ordens.Where(o => o.Tipo == TipoOrdem.Venda).Sum(o => o.Quantidade);
            double somaCompras = Ordens.Where(o => o.Tipo == TipoOrdem.Compra).Sum(o => o.Valor);
            double somaVendas = Ordens.Where(o => o.Tipo == TipoOrdem.Venda).Sum(o => o.Valor);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Posição {Status} em {codigoAtivo}:");
            sb.AppendLine($"Quantidade: {quantidadeCompra - quantidadeVenda}");
            sb.AppendLine($"Valor (R$): {(somaCompras - somaVendas):F2}");

            return sb.ToString();
        }
    }
}
