using Veiculoclass;

namespace Veiculoclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Veiculo> frota = new List<Veiculo>();
            frota.Add(new Carro("Toyota", "Corolla"));
            frota.Add(new Caminhao("Volvo", "FH 540", 40.5));
            frota.Add(new Moto("Honda", "Hornet 600"));

            Console.WriteLine("------------- Testando Polimorfismo -------------");
            foreach (Veiculo v in frota)
            {
                // O comportamento muda dependendo da instancia real
                v.Mover();
            }

            Console.WriteLine("------------- Testando a Sobrecarrga --------------");
            Carro meuCarro = new Carro("Ford", "Mustang");
            meuCarro.Abastecer(50);
            meuCarro.Abastecer("Gasolina Podium", 50);
        }
    }
}
