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
            var sql = @"Select Id, OrderDate, TotalPrice  
                        FROM OrderHistory
                        Where CustomerId ";

            if (customer != 0)  sql += "= " + customer.ToString();
            if (customer == 0) sql += " between 1 AND 10000 ";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var orderlist = connection.Query<Models.OrderHistory>(sql).ToList();

                foreach (var item in orderlist)
                {
                    returnString += $"{item.Id}  {item.OrderDate}  {item.TotalPrice}";
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
                        Join Products p ON od.ProductsId = p.ArticleNumber
                        Join Payment pa ON oh.PaymentId = pa.id
                        Join Shipping s ON oh.ShippingId = s.Id
                        Join Customer c ON oh.CustomerId = c.Id
                        Where oh.id = " + orderId.ToString();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var product = connection.Query<ShowSpecificOrderQuery>(sql).ToList();

                string returnString =  $"{product[0].OrderDate} har kund {product[0].FirstName} {product[0].LastName} har genomfört följande order:\n";
                returnString = $"SAMMANSTÄLLNING\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"ANTAL",-17}{"TOTAL KOSTNAD PER ARTIKEL",-30}\n";
                foreach (var item in product)
                {
                    returnString += $"{ item.ArticleNr,-10}{item.ArticleName,-25}{item.ProductPrice,-14:C2}{item.Quantity,-17}{item.ProductPrice * item.Quantity,-17:C2}";
                }

                returnString += $"\nFraktadress: {product[0].ShippingAdress}\nPostnummer: {product[0].ShippingZipCode}\nStad: {product[0].ShippingCity}\nFraktmetod: {product[0].ShippingMethod}\nBetalningssätt: {product[0].Payment}\nA";
                return returnString;
            }

        }

        /// <summary>
        /// Shows the overall most sold products
        /// </summary>
        /// <returns></returns>/
        public static string MostSoldProducts(bool desc)
        {
            var sql = @"Select Name, SUM(Quantity), SUM(Quantity * Price) FROM
                      OrderDetail od
                      Join OrderHistory oh ON od.OrderId = oh.Id
                      Join Products p ON oh.Id = p.ArticleNumber
                      Group by Name";

            using (var connection = new SqlConnection(connString))
            {

                connection.Open();
                var product = connection.Query<Models.StatisticalQuery>(sql).ToList();
                string returnString = $"Mest sålda produkter\n {"ProduktNamn: ",-10} {"Antal produkter: ",-10} {"Total pris: "}\n ";

                foreach  (var item in product)
                {
                    returnString += $"{item.ProductName,-10}    {item.Quantity,-10}  {item.TotalProductPrice,-10}";
                }

                 return returnString;
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
        public static string MemberList()  {
            var sql = @"Select Id, FirstName, LastName, UserName FROM Customer Where Membership = 1";
            var returnString = "Medlemslista:";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var memberList = connection.Query<Models.Customer>(sql);
                returnString += $"{"Kundnr:",-10}{"Namn:",-30}{"Adress:",-15}{"Postnummer:",-8}{"Stad:",-10}{"Username:",-15}{"Epost:",-15}{"Personnummer:",-20}\n";

                foreach (var item in memberList)
                {
                    returnString += $"{item.Id,-10}{item.FirstName + " " + item.LastName,-30}{item.Adress,-15}{item.ZipCode,-8}{item.City,-10}{item.UserName,-15}{item.Email,-15}{item.IdNumber,-20}\n";
                }
            }
            return returnString;
        }

        /// <summary>
        /// Search for a product in the database
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
        }
    }
}

// metod förändra & ta bort produkt 
// lägga till momshantering (CurrentPrice = inc. moms)
// mer statistik grejer?
// TESTA ALLT
// Fina till menyn