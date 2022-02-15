using System;
using System.Linq;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Furniture Online!");
            Console.WriteLine("----------------------------------");
            Console.WriteLine(Products.ShowChosenItems());

            Console.WriteLine("Vill du handla? Ja/Nej");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput.ToUpper() == "JA")
            {
                MenuSelection();
            }
            else
                AdminMenu();

                Orderhistory.CheckOut();
        }
        public static void MenuSelection()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Välj enligt menyn:");
                Console.WriteLine("[1] Sök på produkt\n" +
                    "[2] Se produktlista\n" +
                    "[3] Välj enligt kategori\n" +
                    "[4] Se kundvagn\n" +
                    "[5] Gå till kassan\n" +
                    "[6] Exit"
                    );

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Dapper.SearchForAProduct();
                        Products.AskForASpecificProduct();
                        break;

                    case 2:
                        Console.WriteLine(Products.ShowAllProducts());
                        Products.AskForASpecificProduct();
                        break;

                    case 3:
                        Console.WriteLine(Category.ChooseByCategory());
                        Products.AskForASpecificProduct();
                        break;

                    case 4:
                        Console.WriteLine(ShoppingCart.ShowShoppingCart(out _, out _));
                        break;

                    case 5:
                        Console.WriteLine(ShoppingCart.ShowShoppingCart(out _, out _));
                        Console.WriteLine("Vill du gå till kassan?");

                        Orderhistory.CheckOut();
                        Console.WriteLine();
                        break;


                    case 6:
                        Console.WriteLine("Tack för besöket, tipsa gärna dina vänner och familj!");
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning, måste vara enligt menyn");
                        break;
                }
            }
        }

        public static void AdminMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Välj enligt menyn:");
                Console.WriteLine("[1] Visa specifik order baserad på kund-ID\n" +
                    "[2] Visa order baserat på order-ID\n" +
                    "[3] Visa mest sålda produkter\n" +
                    "[4] Visa antal ordrar per stad\n" +
                    "[5] Se medlemslista\n" +
                    "[6] Visa ordrar baserat på ålder\n" +
                    "[7] Visa mest populära kategorin\n" +
                    "[8] Lägga till en produkt \n" +
                    "[9] Ändra produktdetaljer\n" +
                    "[10] Ta bort en produkt\n" +
                    "[11] Lägg till kategori\n" +
                    "[12] Ändra på en kategori\n" +
                    "[13] Ta bort en kategori\n" +
                    "[14] Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Ange kund-Id du vill se ordern på");
                        int customer = Convert.ToInt32(Console.ReadLine());
                        Dapper.OrderList(customer);
                        break;

                    case 2:
                        Console.WriteLine("Ange det order-Id du vill se ordern på");
                        int orderId = Convert.ToInt32(Console.ReadLine());
                        Dapper.ShowSpecificOrder(orderId);
                        break;

                    case 3:
                        Dapper.MostSoldProducts();
                        break;

                    case 4:
                        Dapper.NumberOfOrdersByCity();
                        break;

                    case 5:
                        Console.WriteLine(Dapper.MemberList());
                        break;

                    case 6:
                        /*Dapper.NumberOfOrdersGroupedByAge();*/
                        break;

                    case 7:
                        Category.ShowAllCategories();
                        Dapper.MostPopularCategory();
                        break;

                    case 8:
                        Products.AddProduct();
                        break;

                    case 9:
                        Console.WriteLine(Products.ShowAllProducts());
                        Console.Write("Ange namnet på produkten du vill ändra på");
                        string productName = Console.ReadLine().ToUpper();
                        using (var db = new WebShopDBContext())
                        {
                            var products = db.Products;
                            var findProduct = products.SingleOrDefault(p => p.Name == productName);

                            if (findProduct == null)
                            {
                                Console.WriteLine("Finns ingen produkt med det artikelnumret och därför tas inget bort.");
                            }
                            else Products.ModifyProductDetails(findProduct);
                        }
                        break;

                    case 10:
                        Console.WriteLine(Products.ShowAllProducts());
                        Products.RemoveProduct();
                        break;

                    case 11:
                        Category.AddCategory();
                        break;

                    case 12:
                        Category.ShowAllCategories();
                        Category.ModifyCategoryName();
                        break;

                    case 13:
                        Category.ShowAllCategories();
                        Category.RemoveCategory();
                        break;

                    case 14:
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning, det måste vara enligt menyn");
                        break;
                }
            }
        }
    }
}
