using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;

namespace TesterLibGerenciadorOficina
{
    internal class Program
    {
        public static string bd = "DB_GerenciadorOficinaTeste";
        static void Main(string[] args)
        {
            Console.WriteLine("//////////  Tester GetAll  //////////////");

            //Console.WriteLine("Marcas:");
            //TesteGetAllMarca();
            //Console.WriteLine("----------");
            //Console.WriteLine("Modelos:");
            //TesteGetAllModelo();
            //Console.WriteLine("----------");
            Console.WriteLine("Veiculos:");
            TesteGetAllVeiculo();
            
            Console.WriteLine("//////////  Teste Finalizado  //////////////");
        }
        public static void TesteGetAllMarca()
        {
            
            MarcaRepository teste = new MarcaRepository();
            List<Marca> listaTeste = teste.GetAll(bd);
            foreach (var test in listaTeste)
            {
                Console.WriteLine(test.NomeMarca.ToString());
            }
        }
        public static void TesteGetAllModelo()
        {
            ModeloRepository teste = new ModeloRepository();
            List<Modelo> listaTeste = teste.GetAll(bd);
            foreach (var test in listaTeste)
            {
                Console.WriteLine(test.NomeModelo.ToString());
            }
        }
        public static void TesteGetAllVeiculo()
        {
            VeiculoRepository teste = new VeiculoRepository(bd);
            List<Veiculo> listaTeste = teste.GetAll();
            foreach (var test in listaTeste)
            {
                Console.WriteLine("Id: " + test.Id.ToString() + "Ano: " + test.Ano.ToString());
            }
        }
    }
}
