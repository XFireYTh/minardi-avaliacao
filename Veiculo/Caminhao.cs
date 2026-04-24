using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculoclass
{
    internal class Caminhao : Veiculo
    {
        public double CargaMaxima { get; set; }
        public Caminhao(string marca, string modelo, double carga) : base(marca, modelo)
        {
            this.CargaMaxima = carga;
        }

        public override void Mover()
        {
            Console.WriteLine($"O Caminhão {Modelo} está carregando {CargaMaxima} toneladas");
    
        }
    }
}
