using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculoclass
{
    internal class Carro : Veiculo
    {
        public Carro(string marca, string modelo) : base(marca, modelo) { }

        public override void Mover()
        {
            Console.WriteLine($"O carro {Modelo} está se movendo");
        }
    }
}
