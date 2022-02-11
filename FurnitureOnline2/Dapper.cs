using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace FurnitureOnline2
{
    class Dapper
    {
        // static string connString = "data source=dbwebshop1.database.windows.net; initial catalog = WebShopDB; persist security info = True; Integrated Security = True;";
        static string connString = "Server=dbwebshop1.database.windows.net;Database=WebShopDB;User Id=Ladmin; Password=L'sdbwebshop1; Encrypt=True; TrustServerCertificate=False";

        public static List<Models.Category> GetAllSpots()
        {
            var sql = @"SELECT * FROM Category";

            var spotsPerHouse = new List<Models.Category>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                spotsPerHouse = connection.Query<Models.Category>(sql).ToList();

            }
            return spotsPerHouse;
        }

    }
}
