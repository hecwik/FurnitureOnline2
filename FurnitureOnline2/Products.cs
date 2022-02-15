using FurnitureOnline2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    returnString += $"{product.Name,-20} {product.CurrentPrice,-15:C2}\n";
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

                string returnString = $"PRODUKTLISTA\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-30}{"PRIS",-14}{"KATEGORI",-17}{"LEVERANTÖR",-20}{"LAGERSALDO",-25}\n";

                foreach (var product in productList)
                {
                    returnString += $"{product.ArticleNumber,-10}{product.ProductName,-30}{product.Price,-17:C2}{product.CategoryName,-17}{product.SupplierName,-20}{product.stockUnit,-17}\n";
                }
                return returnString;
            }
        }

        public static string ShowAProductToCustomer(int articleNr)
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
                var specificArticle = productList.Where(a => a.ArticleNumber == articleNr).ToList();

                return $"{specificArticle[0].ProductName.ToUpper()}\n\n" +
                    $"Produktbeskrivning: \n{specificArticle[0].Description}\n\n" +
                    $"== Produktfakta ==\n" +
                    $"Artikelnr: {specificArticle[0].Id}\n" +
                    $"Kategori: {specificArticle[0].CategoryName}\n" +
                    $"Leverantör: {specificArticle[0].SupplierName}\n" +
                    $"Färg: {specificArticle[0].Color}\n" +
                    $"Material: {specificArticle[0].Material}";

            }
        }
        public static string ShowAllProductDetails(int articleNr)
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
                var specificArticle = productList.Where(a => a.ArticleNumber == articleNr).ToList();

                return $"{specificArticle[0].ProductName.ToUpper()}\n\n" +
                    $"Produktbeskrivning: \n{specificArticle[0].Description}\n\n" +
                    $"== Produktfakta ==\n" +
                    $"Artikelnr: {specificArticle[0].Id}\n" +
                    $"Kategori: {specificArticle[0].CategoryName}\n" +
                    $"Leverantör: {specificArticle[0].SupplierName}\n" +
                    $"Färg: {specificArticle[0].Color}\n" +
                    $"Material: {specificArticle[0].Material}";

                /*Console.Write($"[{selectNumber++}] Artikelnummer");
                Console.Write($"[{selectNumber++}] Namnet på produkten");
                Console.Write($"[{selectNumber++}] Kostnad för produkten");
                Console.Write($"[{selectNumber++}] Produktens kategori-ID");
                Console.Write($"[{selectNumber++}] Leverantörens ID");
                Console.Write($"[{selectNumber++}] Utvald produkt?");
                Console.Write($"[{selectNumber++}] Hur många varor som finns i lager");
                Console.Write($"[{selectNumber++}] Produktbeskrivning");
                Console.Write($"[{selectNumber++}] Färg på varan");
                Console.Write($"[{selectNumber++}] Varans material");
                Console.Write($"[{selectNumber++}] Ange moms");
                Console.Write($"[{selectNumber++}] Ska varan vara dold?");*/

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

        /// <summary>
        /// Adds a new available product
        /// </summary>
        /// <returns></returns>/
        public static Models.Product AddProduct()
        {
            using (var db = new WebShopDBContext())
            {
                var products = db.Products;

                var newProduct = new Models.Product();

                EnterNewProductDetails(newProduct);

                products.Add(newProduct);
                db.SaveChanges();

                return newProduct;
            }
        }

        public static Models.Product EnterNewProductDetails(Models.Product newProduct)
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

            return newProduct;
        }
        /// <summary>
        /// Modifies details of product fetched in overload
        /// </summary>
        /// <param name="product"></param>
        public static string ModifyProductDetails(Models.Product product)
        {
            string retString = "";

            using (var db = new WebShopDBContext())
            {
                
                bool isRunning = true;
                
                while (isRunning)
                {
                    int selectNumber = 0;
                    // ändra ordning så den blir mer passande
                    Console.Write($"Vad vill du ändra hos {product.Name}?");

                    Console.Write($"[{selectNumber++}] Artikelnummer");
                    Console.Write($"[{selectNumber++}] \nNamnet på produkten");
                    Console.Write($"[{selectNumber++}] \nKostnad för produkten");
                    Console.Write($"[{selectNumber++}] \nProduktens kategori-ID");
                    Console.Write($"[{selectNumber++}] \nLeverantörens ID");
                    Console.Write($"[{selectNumber++}] \nUtvald produkt?");
                    Console.Write($"[{selectNumber++}] \nHur många varor som finns i lager");
                    Console.Write($"[{selectNumber++}] \nProduktbeskrivning");
                    Console.Write($"[{selectNumber++}] \nFärg på varan");
                    Console.Write($"[{selectNumber++}] \nVarans material");
                    Console.Write($"[{selectNumber++}] \nAnge moms");
                    Console.Write($"[{selectNumber++}] \nSka varan vara dold?");

                    string editInput = Console.ReadLine();

                    if (Int32.TryParse(editInput, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Vald produkt: " + ShowAProductToCustomer(product.ArticleNumber));
                                Console.Write($"Nuvarande artikelnummer: {product.ArticleNumber}");
                                Console.Write("Skriv in det nya artikelnumret: ");
                                product.ArticleNumber = Convert.ToInt32(Console.ReadLine());
                                retString = $"Nytt artikelnummer: {product.ArticleNumber}";
                                isRunning = KeepEditing();
                                break;

                            case 2:
                                string oldName = product.Name;
                                Console.Write($"Skriv in ett nytt namn på {oldName}: ");
                                product.Name = Console.ReadLine();
                                retString = $"Nytt namn: {product.Name}\n";
                                isRunning = KeepEditing();
                                break;

                            case 3:
                                Console.Write("Ange nytt pris för produkten: ");
                                product.CurrentPrice = Convert.ToDouble(Console.ReadLine());
                                retString = $"Nytt pris: {product.ArticleNumber}";
                                isRunning = KeepEditing();
                                break;

                            case 4:
                                Console.Write("Ange nytt kategori-ID för produkten: ");
                                product.CategoryId = Convert.ToInt32(Console.ReadLine());
                                retString = $"Nytt ID: {product.CategoryId}";
                                isRunning = KeepEditing();
                                break;

                            case 5:
                                Console.WriteLine("Ange ny leverantörs-ID: ");
                                product.SupplierId = Convert.ToInt32(Console.ReadLine());
                                retString = $"Nytt ID: {product.SupplierId}";
                                isRunning = KeepEditing();
                                break;

                            case 6:
                                Console.WriteLine("Ändra om produkten skall vara utvald (Ja/Nej): ");
                                string inputYesNo = Console.ReadLine();
                                product.ChosenItem = InputYesOrNo();
                                if (product.ChosenItem == true)
                                    Console.WriteLine($"{product.Name} är en utvald produkt.");
                                else
                                    Console.WriteLine($"{product.Name} är inte en utvald produkt.");

                                isRunning = KeepEditing();
                                break;

                            case 7:
                                Console.Write("Ange nytt antal varor i lagret: ");
                                product.StockUnit = Convert.ToInt32(Console.ReadLine());
                                retString = $"Nytt antal i lager: {product.StockUnit}";
                                isRunning = KeepEditing();
                                break;

                            case 8:
                                Console.Write("Lägg till en ny beskrivning för produkten: ");
                                product.Description = Console.ReadLine();
                                isRunning = KeepEditing();
                                break;

                            case 9:
                                Console.Write("Ange en ny färg på varan: ");
                                product.Color = Console.ReadLine();
                                isRunning = KeepEditing();
                                break;

                            case 10:
                                Console.Write("Ange nytt material för varan: ");
                                product.Material = Console.ReadLine();
                                isRunning = KeepEditing();
                                break;

                            case 11:
                                Console.Write("Ange ny moms för varan: ");
                                double? momsInput = Convert.ToDouble(Console.ReadLine());
                                product.Moms = momsInput;
                                retString = $"Ny moms för {product.Name}: {product.Moms}\n";
                                isRunning = KeepEditing();
                                break;

                            case 12:
                                Console.Write("Ska varan vara dold? (Ja/Nej)");
                                product.HiddenArticle = InputYesOrNo();
                                if (product.HiddenArticle == true)
                                    Console.WriteLine($"{product.Name} är ändrad till en dold produkt.");
                                else
                                    Console.WriteLine($"{product.Name} är ändrad till en ej dold produkt.");

                                isRunning = KeepEditing();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning. Tryck var som helst för att gå tillbaka...");
                        Console.ReadLine();
                    }
                }
            }
            return retString;
        }
        /// <summary>
        /// Gets a specific product based on article number.
        /// </summary>
        public static void AskForASpecificProduct()
        {
            Console.WriteLine("Vilken produkt vill du klicka in på? Ange artikelnumret");
            int input = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(ShowAProductToCustomer(input));
            Console.WriteLine("Vill du lägga till den i varukorgen? Skriv isåfall 'Ja' ");
            string stringInput = Console.ReadLine();
            
            if (stringInput == "Ja")
            {
                Console.Write("Hur många exemplar av denna artikel vill du ha?: ");
                int number = Convert.ToInt32(Console.ReadLine());
                var newProductInCart = new Models.ShoppingCart() { ProductsId = input, AmountOfItems = number };
                ShoppingCart.AddProductToCart(newProductInCart);
            }
        }
        
        /// <summary>
        /// Removes a specific product based on name.
        /// </summary>
        public static void RemoveProduct()
        {
            ShowAllProducts();

            Console.WriteLine("Ange namnet på produkten du vill ta bort");
            string input = Console.ReadLine();

            using (var db = new WebShopDBContext())
            {
                var products = db.Categories;
                var updateProducts = products.SingleOrDefault(c => c.Name == input);

                if (updateProducts != null)
                {
                    try
                    {
                        products.Remove(updateProducts);
                    }
                    catch
                    {
                        Console.WriteLine("Den här kategorin finns nog redan i någons orderhistorik och kan därför inte tas bort.\nVill du gömma produkten istället?");
                        string inputHide = Console.ReadLine();

                        if (inputHide == "Ja")

                            updateProducts.HiddenCategory = true;
                        else
                            updateProducts.HiddenCategory = false;
                    }
                    db.SaveChanges();

                }
                else Console.WriteLine("Hittade ingen sådan produkt");
            }
        }


        /// <summary>
        /// Returns true if ja and false if else
        /// </summary>
        /// <returns></returns>
        public static bool? InputYesOrNo()
        {
            string inChoice = Console.ReadLine();

            if (inChoice.ToUpper() == "JA") 
            { return true; }
            else 
            { return false; }
        }
        public static bool KeepEditing()
        {
            Console.Write("\nVill du göra något annat? (Ja/Nej): ");
            bool? keepShopping = InputYesOrNo();
            if (keepShopping == true)
                return true;
            else
                return false;
        }
    }
}
