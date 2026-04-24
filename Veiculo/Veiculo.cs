using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculoclass
{
    internal class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Veiculo(string marca, string modelo)
        {
            this.Marca = marca;
            this.Modelo = modelo;
        }

        public virtual void Mover()
        {
            Console.WriteLine("O veículo está se movendo");
        }

        public void Abastecer(double litros)
        {
            Console.WriteLine($"Abastecendo {litros} litros de combustível padrão");
    
        }

        // Sobrecarga de Métodos
        public void Abastecer(string tipoCombustivel, double litros)
        {
            Console.WriteLine($"Abastecendo {litros} litros de {tipoCombustivel}");
    
        }
    }
}
