﻿using System;
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

        /// <summary>
        /// Shows an entire order or a specific customer based on customer ID in overload
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>/
        public static string OrderList(int customer)
        {
            string returnString = "";
            var sql = @"Select Id, CustomerId, OrderDate, TotalPrice  
                        FROM OrderHistory
                        WHERE CustomerId";

            if (customer != 0)  sql += "= " + customer.ToString();
            if (customer == 0) sql += " between 1 AND 10000 ";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var orderlist = connection.Query<Models.OrderHistory>(sql).ToList();

                returnString = $"SAMMANSTÄLLNING\n\n{"KUND-ID",-10}{"ORDER-ID",-10}{"ORDERDATUM",-25}{"TOTAL KOSTNAD",-30}\n";
                foreach (var item in orderlist)
                {
                    returnString += $"{item.CustomerId,-10}{item.Id,-10}{item.OrderDate,-25}{item.TotalPrice,-15:C2}\n";
                }
            }
            return returnString;
        }
        /// <summary>
        /// Shows a specific order based on order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static string ShowSpecificOrder(int orderId)
        {
            var sql = @"Select * FROM OrderHistory oh
                        Join OrderDetail od ON od.OrderId = oh.Id
                        Join Products p ON od.ProductsId = p.Id
                        Join Payment pa ON oh.PaymentId = pa.id
                        Join Shipping s ON oh.ShippingId = s.Id
                        Join Customer c ON oh.CustomerId = c.Id
                        Where oh.id = " + orderId.ToString();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var product = connection.Query<ShowSpecificOrderQuery>(sql).ToList();

                string customerBought = $"{product[0].OrderDate} har kund {product[0].FirstName} {product[0].LastName} genomfört följande order:\n";
                Console.WriteLine(customerBought);

                string retString = "";
                
                foreach (var item in product)
                {
                    retString += $"{ item.ArticleNumber,-10}{item.Name,-25}{item.TotalPrice,-14:C2}{item.Quantity,-17}{item.TotalPrice * item.Quantity,-17:C2}\n";
                }

                string orderDetail = $"\nFraktadress: {product[0].ShippingAdress}\n" +
                    $"Postnummer: {product[0].ShippingZipCode}\n" +
                    $"Stad: {product[0].ShippingCity}\n" +
                    $"Fraktmetod: {product[0].ShippingId}\n" +
                    $"Betalningssätt: {product[0].PaymentId}\n";

                Console.WriteLine(orderDetail);
                Console.WriteLine($"{"Artikelnummer",-20}{"Namn",-25}{"Pris",-14}{"Antal",-17}{"Total kostnad",-17}");
                return retString;
            }

        }

        /// <summary>
        /// Shows the overall most sold products
        /// </summary>
        /// <returns></returns>/
        public static string MostSoldProducts()
        {
            var sql = @"Select p.Name, SUM(Quantity), SUM(Quantity * Price) 
                        FROM
                        OrderDetail od
                        Join OrderHistory oh ON od.OrderId = oh.Id
                        Join Products p ON od.ProductsId = p.Id
                        Group by p.Name
                        Order by SUM(Quantity) DESC";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var product = connection.Query<(string, int, int)>(sql).ToList();
                string returnString = $"Mest sålda produkter\n{"ProduktNamn: ",-40} {"Antal produkter: ",-15} {"Total pris: "}\n";

                foreach (var item in product)
                {
                    returnString += $"{item.Item1,-45}{item.Item2,-15}{item.Item3,-15}\n";
                }
                
                return returnString;
            }
        }

        /// <summary>
        /// Shows the most popular product category
        /// </summary>
        /// <returns></returns>
        public static string MostPopularCategory()
        {
            var sql = @"Select p.Name, SUM(Quantity), SUM(Quantity * Price) 
                        FROM
                        OrderDetail od
                        Join OrderHistory oh ON od.OrderId = oh.Id
                        Join Products p ON od.ProductsId = p.Id
                        Group by p.Name
                        Order by count(*) DESC";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var product = connection.Query<(string, int)>(sql).ToList();


                string returnString = $"{"Kategori:", -15}{"Antal ordrar", -10}";
                string retString = "";                
                Console.WriteLine(returnString);
                foreach (var item in product)
                {
                    retString += $"{item.Item1,-15}{item.Item2,-10}";
                }
                return retString;
            }
        }


        public static void NumberOfOrdersGroupedByAge()
        {
            var sql = @"SELECT
                Case
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 15 AND 25 Then 'Ålder 15-25'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 26 AND 50 Then 'Ålder 26-50'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) > 50 Then 'Ålder 50+'
                End, COUNT(*)
 
                FROM
                Customer c
                Join OrderHistory oh ON oh.CustomerId = c.Id
                Group by (Case
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 15 AND 25 Then 'Ålder 15-25'
                When DATEDIFF(YEAR, CAST(LSELECT
                Case
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 15 AND 25 Then 'Ålder 15-25'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 26 AND 50 Then 'Ålder 26-50'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) > 50 Then 'Ålder 50+'
                End, COUNT(*), sum(oh.TotalPrice)
 
                FROM
                Customer c
                Join OrderHistory oh ON oh.CustomerId = c.Id
                Group by (Case
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 15 AND 25 Then 'Ålder 15-25'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) between 26 AND 50 Then 'Ålder 26-50'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) > 50 Then 'Ålder 50+'
                End)EFT(IdNumber, 8) AS DATE), GETDATE()) between 26 AND 50 Then 'Ålder 26-50'
                When DATEDIFF(YEAR, CAST(LEFT(IdNumber, 8) AS DATE), GETDATE()) > 50 Then 'Ålder 50+'
                End)";
              using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var product = connection.Query<(string, int, double)>(sql).ToList();

                Console.WriteLine($"{"Ålder:", 10}{"Antal ordrar:"}{"Total pris:"}");
                foreach (var item in product)
                {
                    Console.WriteLine($"{item.Item1,-10}{item.Item2,-10}{item.Item2}");
                }
            }
        }

        /// <summary>
        /// Shows cities in order of most orders made in descending order
        /// </summary>
        /// <returns></returns>/
        public static string NumberOfOrdersByCity()
        {
            var sql = @"Select ShippingCity, count(distinct OrderId) FROM OrderDetail od
                        Join OrderHistory oh ON od.OrderId = oh.Id
                        Group by ShippingCity";

            var returnstring = $"{"Stad:",-20}{"Antal ordrar:",-10}";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var statisticList = connection.Query<Models.StatisticalQuery>(sql);


                foreach (var item in statisticList)
                {
                    returnstring += $"{item.City,-20}{item.Quantity,-10}";
                }
            }
            return returnstring;
        }
        /// <summary>
        /// Shows a list of all the members and their information
        /// </summary>
        /// <returns></returns>
        public static string MemberList()  
       {
            var sql = @"Select Id, FirstName, LastName, Adress, ZipCode, City, UserName, Email, IdNumber FROM Customer Where Membership = 1";
            var returnString = "Medlemslista:\n";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var memberList = connection.Query<Models.Customer>(sql);
                returnString += $"{"Kundnr:",-10}{"Namn:",-30}{"Adress:",-20}{"Postnummer:",-18}{"Stad:",-10}{"Username:",-15}{"Epost:",-30}{"Personnummer:",-20}\n";

                foreach (var item in memberList)
                {
                    returnString += $"{item.Id,-10}{item.FirstName + " " + item.LastName,-30}{item.Adress,-20}{item.ZipCode,-18}{item.City,-10}{item.UserName,-15}{item.Email,-30}{item.IdNumber,-20}\n";
                }
            }
            return returnString;
        }

        /// <summary>
        /// Search for a product in the products table based on article number or product name
        /// </summary>/
        public static void SearchForAProduct()
        {
            string sql = "";
            Console.Write("Sök efter en produkt: ");
            string productSearch = Console.ReadLine();

            if (int.TryParse(productSearch, out int result))
                sql = $"Select Name, ArticleNumber FROM Products WHERE ArticleNumber = {result}";
            else
                sql = $"Select Name, ArticleNumber FROM Products WHERE Name LIKE '%{productSearch}%'";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var searchResult = connection.Query<Models.Product>(sql);
                string returnString = $"{"Produktnamn",-20}{"Artikelnr.",-20}";
                foreach (var item in searchResult)
                {
                    Console.WriteLine($"{item.Name, -20}{item.ArticleNumber, -20}");
                }
            }
        }
    }
}
// mer statistik grejer?
// TESTA ALLT!