using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace sistemaBatalha
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] combatentes = { "Jogador", "Inimigo" };
            double[] vida = { 100, 100 };
            int[] inventario = { 2, 0 };
            int mandante = 0;
            var rndn = new Random();

            while (true)
            {
                Console.WriteLine("\n--- Batalha C# 1.0 ---\nSistema: Bem vindo, escolha o seu nome: ");
                combatentes[0] = Console.ReadLine();
                combatentes[0] = combatentes[0] == "" ? "Jogador" : combatentes[0];
                Console.WriteLine($"\nSistema: Ok {combatentes[0]}, e quem você vai enfrentar hoje?\nSistema: Insira o nome do combatente rival/inimigo:");
                combatentes[1] = Console.ReadLine();
                combatentes[1] = combatentes[1] == "" ? "Jogador": combatentes[1];
                Console.WriteLine($"Sistema: Muito bem, agora vamos para a luta:\n\n----- {combatentes[0]} vs {combatentes[1]} -----\n\n-----   Que vença o melhor -----\n");
                mandante = rndn.Next(0, 1);
                Console.WriteLine($"\nO primeiro a atacar é {combatentes[mandante]}\n");
                int botDecision = 0;
                int playerDecision = 0;
                int turnos = 1;
                int rodada = 1;
                while (vida[0] > 0 && vida[1] > 0)
                {
                    if (rodada == 1)
                    {
                        Console.WriteLine($"\n Rodada {rodada}\n");
                    }
                    Console.WriteLine($"Turno de {combatentes[mandante]}");
                    if (mandante == 1)
                    {
                        botDecision = rndn.Next(1, 4);
                        Console.WriteLine($"{combatentes[mandante]} está pensando...\nDecisão tomada");
                        if (turnos == 1)
                        {
                            Console.WriteLine("\nProxímo...\n");
                            mandante--;
                            turnos++;
                            continue;
                        }
                        mandante--;
                    } 
                    else
                    {
                        Console.WriteLine($"Digite sua opção:\n   1- Ataque\n   2- Defesa\n   3- Curar\n");
                        if (int.TryParse(Console.ReadLine(), out int option))
                        {
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Força do ataque:\n   1- Leve - 100% de Acerto - 5 a 10 de Dano\n   2- Médio - 80% de Acerto - 10 a 20 de Dano\n   3- Forte - 50% de Acerto - 20 a 30 de Dano\n");
                                    if (int.TryParse(Console.ReadLine(),out int optAtk))
                                    {
                                        playerDecision = optAtk;
                                        Console.WriteLine("Decisão registrada.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insira uma entrada válida!");
                                        break; 
                                    }

                                case 2:
                                    Console.WriteLine("Você decidiu defender");
                                    playerDecision = 4;
                                    break;

                                case 3:
                                    if (inventario[0] > 0)
                                    {
                                        Console.WriteLine("Você decidiu Curar");
                                        playerDecision = 5;
                                        break;
                                    }
                                    Console.WriteLine("Você não possui poções em seu inventário");
                                    break;
                                default: Console.WriteLine("Digite uma opção váilda!"); break;
                            }
                            if (playerDecision != 0)
                            {
                                if (turnos == 1)
                                {
                                    Console.WriteLine("\nPróximo...\n");
                                    mandante++;
                                    turnos++;
                                    continue;
                                }
                                mandante++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    if (turnos == 2)
                    {
                        if (playerDecision == 4 && botDecision == 4)
                        {
                            Console.WriteLine("Os dois decidiram defender.");
                            playerDecision = 0;
                            botDecision = 0;
                            turnos = 1;
                            rodada++;
                            Console.WriteLine($"\n Rodada {rodada}\n");
                            continue;
                        }

                        if (mandante == 0)
                        {
                            switch (playerDecision)
                            {
                                case 1:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Ataque Leve\n");
                                    double dano = rndn.Next(5, 10);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante + 1]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueLeve(combatentes, vida, mandante + 1, dano / 2);
                                        break;
                                    }
                                    AtaqueLeve(combatentes, vida, mandante + 1, dano);
                                    break;

                                case 2:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Ataque Médio\n");
                                    double danom = rndn.Next(10, 20);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante + 1]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueMedio(combatentes, vida, mandante + 1, danom / 2);
                                        break;
                                    }
                                    AtaqueMedio(combatentes, vida, mandante + 1, danom);
                                    break;

                                case 3:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Ataque Forte\n");
                                    double danof = rndn.Next(20, 30);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante + 1]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueForte(combatentes, vida, mandante + 1, danof / 2);
                                        break;
                                    }
                                    AtaqueForte(combatentes, vida, mandante + 1, danof);
                                    break;

                                case 4:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Defender\n");
                                    break;

                                case 5:
                                    Console.WriteLine($"Decisão de {combatentes[mandante + 1]}: Curar\n");
                                    Curar(combatentes, vida, inventario, mandante + 1);
                                    break;
                                default: break;
                            }
                            switch (botDecision)
                            {
                                case 1:
                                    Console.WriteLine($"Decisão de {combatentes[mandante + 1]}: Ataque Leve\n");
                                    double dano = rndn.Next(5, 10);
                                    if (playerDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueLeve(combatentes, vida, mandante, dano / 2);
                                        break;
                                    }
                                    AtaqueLeve(combatentes, vida, mandante, dano);
                                    break;

                                case 2:
                                    Console.WriteLine($"Decisão de {combatentes[mandante + 1]}: Ataque Médio\n");
                                    double danom = rndn.Next(10, 20);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueMedio(combatentes, vida, mandante, danom / 2);
                                        break;
                                    }
                                    AtaqueMedio(combatentes, vida, mandante, danom);
                                    break;

                                case 3:
                                    Console.WriteLine($"Decisão de {combatentes[mandante + 1]}: Ataque Forte\n");
                                    double danof = rndn.Next(20, 30);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueForte(combatentes, vida, mandante, danof / 2);
                                        break;
                                    }
                                    AtaqueForte(combatentes, vida, mandante, danof);
                                    break;

                                case 4:
                                    Console.WriteLine($"Decisão de {combatentes[mandante + 1]}: Defender\n");
                                    break;

                                default: break;
                            }

                            playerDecision = 0;
                            botDecision = 0;
                            turnos = 1;
                            rodada++;
                            Console.WriteLine($"\n Rodada {rodada}\n");
                            ExibirDetalhes(combatentes, vida);
                            continue;
                        } 

                        else
                        // Aqui se aplica a mesma lógica, porém invertida, apenas apontando isso pois é muito texto
                        {
                           
                            switch (botDecision)
                            {
                                case 1:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Ataque Leve\n");
                                    double dano = rndn.Next(5, 10);
                                    if (playerDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante -1]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueLeve(combatentes, vida, mandante - 1, dano / 2);
                                        break;
                                    }
                                    AtaqueLeve(combatentes, vida, mandante - 1, dano);
                                    break;

                                case 2:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Ataque Médio\n");
                                    double danom = rndn.Next(10, 20);
                                    if (playerDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante - 1]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueMedio(combatentes, vida, mandante - 1, danom / 2);
                                        break;
                                    }
                                    AtaqueMedio(combatentes, vida, mandante - 1, danom);
                                    break;

                                case 3:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Ataque Forte\n");
                                    double danof = rndn.Next(20, 30);
                                    if (playerDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante - 1]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueForte(combatentes, vida, mandante - 1, danof / 2);
                                        break;
                                    }
                                    AtaqueForte(combatentes, vida, mandante - 1, danof);
                                    break;

                                case 4:
                                    Console.WriteLine($"Decisão de {combatentes[mandante]}: Defender\n");
                                    break;

                                default: break;
                            }

                            switch (playerDecision)
                            {
                                case 1:
                                    Console.WriteLine($"Decisão de {combatentes[mandante - 1]}: Ataque Leve\n");
                                    double dano = rndn.Next(5, 10);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueLeve(combatentes, vida, mandante, dano / 2);
                                        break;
                                    }
                                    AtaqueLeve(combatentes, vida, mandante, dano);
                                    break;

                                case 2:
                                    Console.WriteLine($"Decisão de {combatentes[mandante - 1]}: Ataque Médio\n");
                                    double danom = rndn.Next(10, 20);
                                    if (playerDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueMedio(combatentes, vida, mandante, danom / 2);
                                        break;
                                    }
                                    AtaqueMedio(combatentes, vida, mandante, danom);
                                    break;

                                case 3:
                                    Console.WriteLine($"Decisão de {combatentes[mandante - 1]}: Ataque Forte\n");
                                    double danof = rndn.Next(20, 30);
                                    if (botDecision == 4)
                                    {
                                        Console.WriteLine($"{combatentes[mandante]} decidiu defender e por isso sofrerá dano reduzido\n");
                                        AtaqueForte(combatentes, vida, mandante, danof / 2);
                                        break;
                                    }
                                    AtaqueForte(combatentes, vida, mandante, danof);
                                    break;

                                case 4:
                                    Console.WriteLine($"Decisão de {combatentes[mandante - 1]}: Defender\n");
                                    break;

                                case 5:
                                    Console.WriteLine($"Decisão de {combatentes[mandante - 1]}: Curar\n");
                                    Curar(combatentes, vida, inventario, mandante - 1);
                                    break;
                                default: break;
                            }

                            playerDecision = 0;
                            botDecision = 0;
                            turnos = 1;
                            rodada++;
                            Console.WriteLine($"\n Rodada {rodada}\n");
                            ExibirDetalhes(combatentes, vida);
                            continue;
                        }
                    }

                }
                Console.WriteLine("\nPartida Finalizada");
                if (vida[0] == 0) { Console.WriteLine($"{combatentes[0]} venceu!"); }
                else { Console.WriteLine($"{combatentes[1]} venceu!"); }
                ExibirDetalhes(combatentes, vida);
                Console.WriteLine("Obrigado por jogar");
                break;
            }

        }

        public static void AtaqueLeve(string[] jogadores, double[] status, int alvo, double dano)
        {
            status[alvo] -= dano;
            if (status[alvo] < 0)
            {
                status[alvo] = 0;
            }
            Console.WriteLine($"{jogadores[alvo]} sofreu {dano} de dano");    
        }
        
        public static void AtaqueMedio(string[] jogadores, double[] status, int alvo, double dano)
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

        public static void AtaqueForte(string[] jogadores, double[] status, int alvo, double dano)
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

        public static void Curar(string[] jogadores, double[] status, int[] inventario, int alvo)
        {
            if (inventario[alvo] > 0)
            {
                inventario[alvo]--;
                status[alvo] += 20;
                Console.WriteLine($"{jogadores[alvo]} curou 20 de vida");
            }
        }

        public static void ExibirDetalhes(string[] jogadores, double[] vida)
        {
            string barraVidaJ = string.Empty;
            string barraVidaI = string.Empty;

            for (int i = 1; i <= vida[0]; i++)
            {
                if (i % 5 == 0)
                {
                    if (i <= vida[0])
                    {
                        barraVidaJ += "[]";
                        continue;
                    }
                    barraVidaJ += "--";
                }
            }

            for (int i = 1; i <= vida[1]; i++)
            {
                if (i % 5 == 0)
                {
                    if (i <= vida[1])
                    {
                        barraVidaI += "[]";
                        continue;
                    }
                    barraVidaI += "--";
                }
            }

            Console.WriteLine("##################################_-STATUS-_#####################################");
            Console.WriteLine("----------#_Jogador_#-------------##_-VS-_##------------#_Inimigo_#--------------");
            Console.WriteLine($"{jogadores[0]}                            {jogadores[1]}");
            Console.WriteLine($"Vida: {vida[0]}                             Vida: {vida[1]}");
            Console.WriteLine($"{barraVidaJ}                              {barraVidaI}\n");


        } 
    }
}