using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.Repositories
{
    public static class Conection2Repo
    {
        static string DB_GerenciadorOficina = "Server=(LocalDb)\\MSSQLLocalDB;Database=GestaoOficina;Trusted_Connection=True;TrustServerCertificate=True";
        static string DB_GerenciadorOficinaTeste = "Server=(LocalDb)\\MSSQLLocalDB;Database=GestaoOficinaTeste;Trusted_Connection=True;TrustServerCertificate=True";

        public static string GetRepoConection(string tagRepo)
        {
            if (tagRepo == "DB_GerenciadorOficina") return DB_GerenciadorOficina;
            if (tagRepo == "DB_GerenciadorOficinaTeste") return DB_GerenciadorOficinaTeste;
            return "";
        }
    }
}
