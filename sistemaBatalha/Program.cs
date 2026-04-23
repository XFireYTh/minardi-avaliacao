using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace sistemaBatalha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Entidade inimigo = new Entidade("Zeus Rei Delax 2022");
            Entidade jogador = new Entidade("Kleitão da Galera 2026 YT");

            string[] entidades = { "Kratos", "Zeus" };
            double[] vida = { 100, 100 };



        }

        public void AtaqueLeve(string[] jogadores, double[] status, int alvo, double dano)
        {
            status[alvo] -= dano;
            if (status[alvo] < 0)
            {
                status[alvo] = 0;
            }
            Console.WriteLine($"{jogadores[alvo]} sofreu {dano} de dano");    
        }
        
        public void AtaqueMedio(string[] jogadores, double[] status, int alvo, double dano)
        {
            Random rand = new Random();
            bool acerto = rand.Next(1, 100) > 80 ? false : true;
            if (acerto)
            {
                status[alvo] -= dano;
                Console.WriteLine($"{jogadores[alvo]} sofreu {dano} de dano");
            }
            else
            {
                Console.WriteLine("O ataque falhou");
            }
        }

        public void AtaqueForte(string[] jogadores, double[] status, int alvo, double dano)
        {
            Random rand = new Random();
            bool acerto = rand.Next(1, 100) > 50 ? false : true;
            if (acerto)
            {
                status[alvo] -= dano;
                Console.WriteLine($"{jogadores[alvo]} sofreu {dano} de dano");
            }
            else
            {
                Console.WriteLine("O ataque falhou");
            }
        }

        public void Curar(string[] jogadores, double[] status, int[] inventario, int alvo)
        {
            if (inventario[alvo] > 0)
            {
                inventario[alvo]--;
                status[alvo] += 20;
                Console.WriteLine($"{jogadores[alvo]} curou 20 de vida");
            }
        }
    }
}