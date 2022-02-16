using FurnitureOnline2.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FurnitureOnline2
{
    class ShoppingCart
    {
        /// <summary>
        /// Adds product to a given shopping cart
        /// </summary>
        /// <param name="cart"></param>
        public static void AddProductToCart(Models.ShoppingCart cart)
        {
            using (var db = new WebShopDBContext())
            {
                var cartTable = db.ShoppingCarts;
                var updateQuantityProduct = cartTable.SingleOrDefault(u => u.ProductsId == cart.ProductsId);

                if (updateQuantityProduct == null)
                {
                    cartTable.Add(cart);
                    db.SaveChanges();

                }
                else UpdateQuantityInCart(cart.ProductsId, updateQuantityProduct.AmountOfItems + cart.AmountOfItems);
            }
        }

        /// <summary>
        /// Update the quantity of a shoppingcart by article number and number of item
        /// </summary>
        /// <param name="articleNumber"></param>
        /// <param name="numberOfItem"></param>
        public static void UpdateQuantityInCart(int? articleNumber, int? numberOfItem)
        {
            using (var db = new WebShopDBContext())
            {
                var articleToUpdate = db.ShoppingCarts.SingleOrDefault(c => c.ProductsId == articleNumber);
                var articleToUpdate2 = db.Products.SingleOrDefault(c => c.ArticleNumber == articleNumber);
                articleToUpdate.AmountOfItems = numberOfItem;

                if (articleToUpdate2.StockUnit > numberOfItem)
                {
                    db.SaveChanges();
                }
                else Console.WriteLine("Du kan inte lägga till fler produkter än vad lagersaldot har");
            }
        }
        /// <summary>
        /// Show the shopping cart and its contents.
        /// </summary>
        /// <param name="summa"></param>
        /// <param name="summaExcludingVat"></param>
        /// <returns></returns>
        public static string ShowShoppingCart(out double? summa, out double? summaExcludingVat)
        {
            summa = 0;
            using (var db = new WebShopDBContext())
            {
                var cartList = from
                               cart in db.ShoppingCarts
                               join
                               product in db.Products on cart.ProductsId equals product.ArticleNumber
                               select new ShoppingCartQuery
                               {
                                   Id = cart.Id,
                                   ProductName = product.Name,
                                   UnitPrice = product.CurrentPrice,
                                   Quantity = cart.AmountOfItems,
                                   ArticleNumber = product.ArticleNumber
                               };

                string returnString = $"SAMMANSTÄLLNING\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"ANTAL",-17}{"TOTAL KOSTNAD PER ARTIKEL",-30}\n";
                summa = 0;
                summaExcludingVat = 0;

                foreach (var item in cartList)
                {
                    returnString += $"{item.ArticleNumber,-10}{item.ProductName,-25}{item.UnitPrice,-14:C2}{item.Quantity,-17}{item.TotalAmount,-10:C2}\n";
                    summa += item.TotalAmount;
                    summaExcludingVat += item.TotalAmount * item.Moms;
                }
                returnString += $"\nTOTAL KOSTNAD FÖR ALLA ARTIKLAR: {summa:C2}\nEXKLUSIVE MOMS: {summa:C2}";
                return returnString;
            }
        }

        /// <summary>
        /// Remove all items in shopping cart
        /// </summary>
        public static void ClearShoppingCart() //ska det vara en specifik cart eller hela tabellen shopping cart? / Hector
        {
            using (var db = new WebShopDBContext())
            {
                var cartTable = db.ShoppingCarts;

                foreach (var item in cartTable)
                {
                    cartTable.Remove(item);
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Change or remove products in the a shopping cart based on products article number
        /// </summary>
        /// <param name="articleNr"></param>
        public static void ChangeOrRemoveProductsInCart(int articleNr)
        {
            Console.WriteLine($"Vill du ändra antalet produkter med artikelnummer: {articleNr} i kundvagnen eller ta bort en produkt? Välj mellan 1 och 2");
            int input = Convert.ToInt32(Console.ReadLine());

            using (var db = new WebShopDBContext())
            {
                var cartTable = db.ShoppingCarts;

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Ange det antalet du vill ha");
                        int input2 = Convert.ToInt32(Console.ReadLine());

                        UpdateQuantityInCart(articleNr, input2);
                        break;

                    case 2:

                        Console.WriteLine("Ange artikelnr. på den produkt du vill ta bort?");
                        int articleToRemove = Convert.ToInt32(Console.ReadLine());

                        foreach (var item in cartTable)
                        {
                            if (item.ProductsId == articleToRemove)
                            {
                                cartTable.Remove(item);
                            }

                            db.SaveChanges();


                        }
                        Console.WriteLine("Produkten finns inte i din kundvagn. Tryck var som helst för att fortsätta...");
                        Console.ReadLine();

                        break;
                }
            }
        }
    }
}