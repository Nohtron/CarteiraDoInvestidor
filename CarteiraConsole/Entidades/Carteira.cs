using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiraConsole.Entidades
{
    class Carteira
    {
        public string Nome { get; set; }
        public HashSet<Posicao> Posicoes { get; set; }

        public Carteira(string nome)
        {
            Nome = nome;
            Posicoes = new HashSet<Posicao>();
        }

        public void AdicionarPosicao(Posicao ordem)
        {
            Posicoes.Add(ordem);
        }

        public void ImprimePosicoesAbertas()
        {
            foreach (Posicao posicao in Posicoes)
            {
                Console.WriteLine(posicao.ToString());
            }
        }
    }
}
