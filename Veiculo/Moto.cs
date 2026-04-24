using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculoclass
{
    internal class Moto : Veiculo
    {
        public Moto(string marca, string modelo) : base(marca, modelo) { }
        public override void Mover()
        {
            Console.WriteLine($"A moto {Modelo} está costurando no trânsito");
    
        }
    }
}
