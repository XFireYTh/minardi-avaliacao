using System;

namespace sistemaBatalha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Entidade inimigo = new Entidade("Zeus Rei Delax 2022");
            Entidade jogador = new Entidade("Kleitão da Galera 2026 YT");

            inimigo.Defender();
            jogador.Atacar(inimigo, 3);
            inimigo.Defender();
        }
    }
}