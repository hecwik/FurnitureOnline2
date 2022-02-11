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
        static string connString = "Server=dbwebshop1.database.windows.net;Database=WebShopDB;User Id=Ladmin; Password=L'sdbwebshop1; Encrypt=True; TrustServerCertificate=False";

        public static string CustomerOrderList( int customer)
        {

            string returnString = "";
            var sql = @"Select Id, OrderDate, TotalPrice  
                        FROM OrderHistory
                        Where CustomerId = " + customer;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var orderlist = connection.Query<Models.OrderHistory>(sql).ToList();

                foreach (var item  in orderlist)
                {
                    returnString += $"{item.Id}  {item.OrderDate}  {item.TotalPrice}";
                }

            }
            return returnString;
        }

        public static string ShowSpecificOrder(int orderId)
        {

            string returnString = "";
            var sql = @"Select * FROM OrderHistory oh
                        Join OrderDetail od ON od.OrderId = oh.Id
                        Join Products p ON od.ProductsId = p.ArticleNumber
                        Join Payment pa ON oh.PaymentId = pa.id
                        Join Shipping s ON oh.ShippingId = s.Id
                        Where oh.id = 0";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var product = connection.Query<Models.OrderHistory>(sql).ToList();

                foreach (var item in product)
                {
                    returnString += $"{ item.Id}  {item.OrderDate}  {item.TotalPrice}"
                }

            }
            return spotsPerHouse;
        }

    }
}
