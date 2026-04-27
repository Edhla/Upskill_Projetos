using System;
using System.Collections.Generic;
using System.Text;

namespace NothwindLib.Repositories
{
    public static class Conection2Repo
    {
        static string DB_Northwind = "Server=(LocalDb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True";
        static string NorthwindTest = "Server=localhost;Database=NorthwindTest;Trusted_Connection=True";

        public static string GetRepoConection(string tagRepo)
        {
            if (tagRepo == "DB_Northwind") return DB_Northwind;
            if (tagRepo == "NorthwindTest") return NorthwindTest;
            return "";
        }
    }
}
