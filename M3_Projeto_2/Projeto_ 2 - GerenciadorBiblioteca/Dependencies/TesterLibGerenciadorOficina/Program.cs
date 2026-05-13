using LibGerenciadorOficina.Models;
using LibGerenciadorOficina.Repositories;

namespace TesterLibGerenciadorOficina
{
    internal class Program
    {
        public static string bd = "DB_GerenciadorOficinaTeste";
        static void Main(string[] args)
        {
            Console.WriteLine("////////// Teste Iniciado  //////////////");

            Console.WriteLine("---------------- Marcas:");
            Console.WriteLine("---------------- GetAll:");
            TesteGetAllMarca();
            Console.WriteLine("---------------- GetById:");
            TesteGetByIdMarca();
            Console.WriteLine("---------------- Modelos:");
            Console.WriteLine("---------------- GetAll:");
            TesteGetAllModelo();
            Console.WriteLine("---------------- GetById:");
            TesteGetByIdModelo(); 
            Console.WriteLine("---------------- Veiculos:");
            Console.WriteLine("---------------- GetAll:");
            TesteGetAllVeiculo();
            Console.WriteLine("---------------- GetById:");
            TesteGetByIdVeiculo();

            Console.WriteLine("//////////  Teste Finalizado  //////////////");
        }
        #region GetAll
        public static void TesteGetAllMarca()
        {
            
            MarcaRepository teste = new MarcaRepository(bd);
            List<Marca> listaTeste = teste.GetAll();
            foreach (var test in listaTeste)
            {
                Console.WriteLine(test.NomeMarca.ToString());
            }
        }
        public static void TesteGetAllModelo()
        {
            ModeloRepository teste = new ModeloRepository(bd);
            List<Modelo> listaTeste = teste.GetAll();
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
        #endregion

        #region GetById
        public static void TesteGetByIdMarca()
        {
            MarcaRepository teste = new MarcaRepository(bd);
            Marca marca = teste.GetById(1);
            Console.WriteLine(marca.NomeMarca.ToString());
        }
        public static void TesteGetByIdModelo()
        {
            ModeloRepository teste = new ModeloRepository(bd);
            Modelo listaTeste = teste.GetById(1);
            Console.WriteLine(listaTeste.NomeModelo.ToString());
        }
        public static void TesteGetByIdVeiculo()
        {
            VeiculoRepository teste = new VeiculoRepository(bd);
            Veiculo veiculo = teste.GetById(1);
            Console.WriteLine("Id: " + veiculo.Id.ToString() + "Ano: " + veiculo.Ano.ToString());
        }
        #endregion
        
        #region Insert
        public static void TesteInsertMarca()
        {
            Marca marca = new Marca();
            marca.NomeMarca = "Marca de Teste";

            MarcaRepository teste = new MarcaRepository(bd);
            MarcaRepository.Insert
        }
        public static void TesteInsertModelo()
        {
            ModeloRepository teste = new ModeloRepository(bd);
            Modelo listaTeste = teste.GetById(1);
            Console.WriteLine(listaTeste.NomeModelo.ToString());
        }
        public static void TesteInsertVeiculo()
        {
            VeiculoRepository teste = new VeiculoRepository(bd);
            Veiculo veiculo = teste.GetById(1);
            Console.WriteLine("Id: " + veiculo.Id.ToString() + "Ano: " + veiculo.Ano.ToString());
        }
        #endregion
    }
}
