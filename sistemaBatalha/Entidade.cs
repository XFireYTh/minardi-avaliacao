using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace sistemaBatalha
{
    internal class Entidade
    {
        public string Nome {  get; set; }
        public double Vida {  get; set; }
        public List<string> Pocoes {  get; set; }
        public bool Defesa { get; set; }

        public Entidade(string nome, int pocoes = 0)
        {
            Nome = nome;
            Vida = 100;
            Pocoes = new List<string>();
            for (int i = 0; i <= pocoes; i++)
            {
                Pocoes.Add("Cura");
            }
            Defesa = false;
        }

        private Random rand = new Random();

        // Funções que retornam o acerto

        public bool AtaqueMedio()
        {
            int prob = rand.Next(1, 100);
            if (prob > 80)
            {
                return false;
            }
            return true;
        }

        public bool AtaqueForte()
        {
            int prob = rand.Next(1, 100);
            if (prob > 50)
            {
                return false;
            }
            return true;
        }

        // Funções de Alteração
        
        public void Defender()
        {
            if (Defesa == false)
            {
                Defesa = true;
            }
            else
            {
                Defesa = false;
            }
        }

        public void Atacar(Entidade alvo, int forca = 1)
        {
            switch (forca)
            {
                case 1:
                    int dano = rand.Next(5, 10);
                    if (alvo.Defesa)
                    {
                        alvo.Vida -= dano / 2;
                        if (alvo.Vida < 0)
                        {
                            alvo.Vida = 0;
                        }
                        Console.WriteLine($"{alvo.Nome} sofreu {dano / 2} de dano");
                        break;
                    }
                    
                    alvo.Vida -= dano;
                    if (alvo.Vida < 0)
                    {
                        alvo.Vida = 0;
                    }
                    Console.WriteLine($"{alvo.Nome} sofreu {dano} de dano");
                    break;
                    

                case 2:
                    if (this.AtaqueMedio())
                    {
                        int danom = rand.Next(10, 20);
                        if (alvo.Defesa)
                        {
                            alvo.Vida -= danom / 2;
                            if (alvo.Vida < 0)
                            {
                                alvo.Vida = 0;
                            }
                            Console.WriteLine($"{alvo.Nome} sofreu {danom / 2} de dano");
                            break;
                        }
                        alvo.Vida -= danom;
                        if (alvo.Vida < 0)
                        {
                            alvo.Vida = 0;
                        }
                        Console.WriteLine($"{alvo.Nome} sofreu {danom} de dano");
                        break;
                    }
                    Console.WriteLine($"{Nome} errou o ataque em {alvo.Nome}");
                    break;

                case 3:
                    if (this.AtaqueForte())
                    {
                        int danof = rand.Next(20, 30);
                        if (alvo.Defesa)
                        {
                            alvo.Vida -= danof / 2;
                            if (alvo.Vida < 0)
                            {
                                alvo.Vida = 0;
                            }
                            Console.WriteLine($"{alvo.Nome} sofreu {danof / 2} de dano");
                            break;
                        }
                        alvo.Vida -= danof;
                        if (alvo.Vida < 0)
                        {
                            alvo.Vida = 0;
                        }
                        Console.WriteLine($"{alvo.Nome} sofreu {danof} de dano");
                        break;
                    }
                    Console.WriteLine($"{Nome} errou o ataque em {alvo.Nome}");
                    break;

                default:
                    Console.WriteLine("Insira uma entrada válida");
                    break;
                
             
            }
        }

        public void Curar()
        {
            if (Pocoes.Count > 0)
            {
                Pocoes.Remove("Cura");
                Vida += 20;
                Console.WriteLine($"{Nome} Foi Curado");
            }
            else { Console.WriteLine($"{Nome} não possui poções no inventário"); }
        }
    }
}
