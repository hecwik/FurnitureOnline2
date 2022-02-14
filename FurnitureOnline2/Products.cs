using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Products
    {
        public static string ShowChosenItems()
        {
            using (var db = new WebShopDBContext())
            {
                var products = db.Products;
                var chosenProducts = products.Where(s => s.ChosenItem == true);
                string returnString = "\nNågra utvalda produkter: \n\n";

                foreach (var product in chosenProducts)
                {
                    returnString += $"{product.Name}, {product.CurrentPrice} kr \t";
                }
                return returnString;
            }
        }

        public static string ShowAllProducts()
        {
            using (var db = new WebShopDBContext())
            {
                var productList = from
                                  product in db.Products
                                  join
                                  Category in db.Categories on product.CategoryId equals Category.Id
                                  join Supplier in db.Suppliers on product.SupplierId equals Supplier.Id
                                  select new ProductListQuery
                                  {
                                      Id = product.Id,
                                      ProductName = product.Name,
                                      Price = product.CurrentPrice,
                                      CategoryName = Category.Name,
                                      SupplierName = Supplier.Name,
                                      stockUnit = product.StockUnit,
                                      Description = product.Description,
                                      Color = product.Color,
                                      Material = product.Material,
                                      ArticleNumber = product.ArticleNumber
                                  };

                string returnString = $"PRODUKTLISTA\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"KATEGORI",-17}{"LEVERANTÖR",-20}{"LAGERSALDO",-25}\n";

                foreach (var product in productList)
                {
                    returnString += $"{product.ArticleNumber,-10}{product.ProductName,-25}{string.Format("{0:0.00}", product.Price) + " kr",-14}{product.CategoryName,-17}{product.SupplierName,-20}{product.stockUnit,-17}\n";
                }
                return returnString;
            }
        }

        public static string ShowAProduct(int articleNr)
        {
            using (var db = new WebShopDBContext())
            {
                var productList = from
                                  product in db.Products
                                  join
                                  Category in db.Categories on product.CategoryId equals Category.Id
                                  join Supplier in db.Suppliers on product.SupplierId equals Supplier.Id
                                  select new ProductListQuery 
                                  {
                                      Id = product.Id, 
                                      ProductName = product.Name, 
                                      Price = product.CurrentPrice, 
                                      CategoryName = Category.Name, 
                                      SupplierName = Supplier.Name, 
                                      stockUnit = product.StockUnit, 
                                      Description = product.Description, 
                                      Color = product.Color, Material = 
                                      product.Material, 
                                      ArticleNumber = product.ArticleNumber 
                                  };
                var specificArticle = productList.Where(a => a.ArticleNumber == articleNr).ToList();

                return $"{specificArticle[0].ProductName.ToUpper()}\n\nProduktbeskrivning: \n{specificArticle[0].Description}\n\nProduktfakta:\nArtikelnt: {specificArticle[0].Id}\nKategori: {specificArticle[0].CategoryName}\nLeverantör: {specificArticle[0].SupplierName}\nFärg: {specificArticle[0].Color}\nMaterial: {specificArticle[0].Material}";

            }
        }

        public static void UpdateStockUnit(int articleNr, int Quantity)
        {
            using (var db = new WebShopDBContext())
            {
                var products = db.Products;
                var updateQuantityProduct = products.SingleOrDefault(p => p.ArticleNumber == articleNr);

                if (updateQuantityProduct == null)
                {
                    Console.WriteLine("Finns ingen produkt med det artikelnumret och därför tas inget bort.");
                }
                else updateQuantityProduct.StockUnit -= Quantity;
                db.SaveChanges();
            }
        }

        public static void SearchProduct()
        {
            using (var db = new WebShopDBContext())
            {
                var product = db.Products;
                    
            }
            Console.WriteLine("Ange namnet på produkten du vill söka på");
            string inputName = Console.ReadLine();



        }
        /// <summary>
        /// Adds a new available product
        /// </summary>
        /// <returns></returns>/
        public static int AddProduct()
        {
            using (var db = new WebShopDBContext())
            {

                var products = db.Products;

                var newProduct = new Models.Product();

                EnterNewProductDetails(newProduct);

                products.Add(newProduct);
                db.SaveChanges();
            }
        }
        
        public static Models.Product EnterNewProductDetails(Models.Product newProd)
        {
            Console.Write("Skriv in artikelnumret: ");
            newProduct.ArticleNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Skriv in namnet på produkten: ");
            newProduct.Name = Console.ReadLine();
            Console.Write("Vad kostar produkten?");
            newProduct.CurrentPrice = Convert.ToDouble(Console.ReadLine());
            // metod för ny kategori
            Console.Write("Skriv in ID för produktens kategori: ");
            newProduct.CategoryId = Convert.ToInt32(Console.ReadLine());
            // metod för ny leverantör
            Console.Write("Skriv in ID för leverantör: ");
            newProduct.SupplierId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Är detta en utvald produkt? (Ja eller Nej: ");
            string inputChosen = Console.ReadLine();
            if (inputChosen == "Ja")
                newProduct.ChosenItem = true;
            else
                newProduct.ChosenItem = false;

            Console.Write("Hur många varor finns i lagret?: ");
            newProduct.StockUnit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lägg till en beskrivning för produkten: ");
            newProduct.Description = Console.ReadLine();
            Console.Write("Vad har varan för färg?: ");
            newProduct.Color = Console.ReadLine();
            Console.Write("Vad är varan av för material?");
            newProduct.Material = Console.ReadLine();
            Console.Write("Ange moms: ");
            newProduct.Moms = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ska varan vara dold?: ");
            string inputHidden = Console.ReadLine();
            if (inputHidden == "Ja")
                newProduct.HiddenArticle = true;
            else
                newProduct.HiddenArticle = false;
        }
        public static string ModifyArticleDetails()
            {
            string change = "";
            // return old vs new change

            return change;
            } 
    }
}
// lägg till i metod som visas när man kallar på produktlista
/*
 Console.WriteLine("Vilken produkt vill du klicka in på? Ange artikelnumret");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Products.ShowAProduct(input));
            Console.WriteLine("Vill du lägga till den i varukorgen? Skriv isåfall 'Ja' ");
            string stringInput = Console.ReadLine();
            if (stringInput == "Ja")
            {
                Console.WriteLine("Hur många exemplar av denna artikel vill du ha?");
                int number = Convert.ToInt32(Console.ReadLine());
                var newProductInCart = new Models.ShoppingCart() { ProductsId = input, AmountOfItems = number };
                ShoppingCart.AddProduct(newProductInCart);
            }
*/