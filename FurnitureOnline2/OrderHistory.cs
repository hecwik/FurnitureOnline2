using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Orderhistory
    {
        public static void CheckOut()
        {
            var orderCustomer = Customers.DetermineMember();
            var orderShippingMethod = Shipping.ChooseShipping();

            double? summa;
            double? summaExMoms;
            string orderSummary = ShoppingCart.ShowShoppingCart(out summa, out summaExMoms) +
                $"Frakt ({orderShippingMethod.Name}) \t{orderShippingMethod.Price:C}\n" +
                $"Total att betala: {summa + orderShippingMethod.Price:C}\n" +
                $"Exklusive moms: {summaExMoms:C}";
            
            Console.WriteLine(orderSummary);

            var payment = Payment.ChoosePayment();
            
            var newOrderHistory = new Models.OrderHistory() 
            { 
                CustomerId = orderCustomer.Id, 
                OrderDate = DateTime.Now, 
                ShippingId = orderShippingMethod.Id, 
                PaymentId = payment.Id, 
                ShippingAdress = orderCustomer.Adress, 
                ShippingZipCode = orderCustomer.ZipCode, 
                ShippingCity = orderCustomer.City, 
                TotalPrice = summa + orderShippingMethod.Price };

            using (var dbOrderHistory = new Models.WebShopDBContext())
            {
                var orderList = dbOrderHistory.OrderHistories;
                orderList.Add(newOrderHistory);
                dbOrderHistory.SaveChanges();

                var cartlist = from
                               cart in dbOrderHistory.ShoppingCarts
                               join
                               product in dbOrderHistory.Products on cart.ProductsId equals product.ArticleNumber
                               select new ShoppingCartQuery 
                               { 
                                   ArticleNumber = cart.ProductsId, 
                                   ProductName = product.Name, 
                                   Quantity = cart.AmountOfItems, 
                                   UnitPrice = product.CurrentPrice 
                               };

                foreach (var item in cartlist)
                {
                    using (var dbOrderDetail = new Models.WebShopDBContext())
                    {
                        var OrderDetailList = dbOrderDetail.OrderDetails;
                        var newOrderDetail = new Models.OrderDetail() 
                        { 
                            OrderId = newOrderHistory.Id, 
                            ProductsId = 4, 
                            Price = item.UnitPrice, 
                            Quantity = item.Quantity 
                        };

                        OrderDetailList.Add(newOrderDetail);
                        Products.UpdateStockUnit((int)item.ArticleNumber, (int)item.Quantity);
                        dbOrderDetail.SaveChanges();
                    }
                }

                Console.WriteLine("Orderbekräftelse:\n" + orderSummary);
                Console.ReadLine();

            }
            ShoppingCart.ClearShoppingCart();
        }
    }
}
