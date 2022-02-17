using System;
using System.Linq;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Program
    {
        // GRUPPEN BESTÅR AV: Louise, Carl-Henrik & Hector
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
                Console.WriteLine(
                    "[1] Sök på produkt\n" +
                    "[2] Se produktlista\n" +
                    "[3] Välj enligt kategori\n" +
                    "[4] Se kundvagn\n" +
                    "[5] Gå till kassan\n" +
                    "[6] Exit");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Dapper.SearchForAProduct();
                        Products.AskForASpecificProduct();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine(Products.ShowAllProducts());
                        Products.AskForASpecificProduct();
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine(Category.ChooseByCategory());
                        Products.AskForASpecificProduct();
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine(ShoppingCart.ShowShoppingCart(out _, out _));
                        Console.WriteLine("\nVill du ändra i varukorgen? (Ja/Nej)");
                        string inputChange = Console.ReadLine();
                        if (inputChange == "Ja") ShoppingCart.ChangeOrRemoveProductsInCart();
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine(ShoppingCart.ShowShoppingCart(out _, out _));
                        Console.WriteLine("Vill du gå till kassan? (Ja/Nej)");
                        

                        Orderhistory.CheckOut();
                        Console.WriteLine();
                        break;


                    case 6:
                        Console.WriteLine("Tack för besöket, tipsa gärna dina vänner och familj!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning, måste vara enligt menyn");
                        break;
                }
            }
        }

        public static void AdminMenu()
        {
            Console.WriteLine("Hello World");
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Välj enligt menyn:\n");
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
                    "[14] Lägg till en leverantör\n" +
                    "[15] Ändra detaljer hos leverantör\n" +
                    "[16] Ta bort en leverantör\n" +
                    "[17] Exit ");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(Dapper.ShowCustomerId());
                        Console.WriteLine("Ange kund-Id du vill se ordern på");
                        int customer = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Dapper.OrderList(customer));
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ange det order-Id du vill se ordern på");
                        int orderId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Dapper.ShowSpecificOrder(orderId));
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine(Dapper.MostSoldProducts());
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine(Dapper.NumberOfOrdersByCity());
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine(Dapper.MemberList());
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.Clear();
                        Dapper.NumberOfOrdersGroupedByAge();
                        Console.ReadLine();
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine(Dapper.MostPopularCategory());
                        Console.ReadLine();
                        break;

                    case 8:
                        Console.Clear();
                        Products.AddProduct();

                        break;

                    case 9:
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine(Products.ShowAllProducts());
                        Products.RemoveProduct();
                        break;

                    case 11:
                        Console.Clear();
                        Category.AddCategory();
                        break;

                    case 12:
                        Console.Clear();
                        Category.ShowAllCategories();
                        Category.ModifyCategoryName();
                        break;

                    case 13:
                        Console.Clear();
                        Category.ShowAllCategories();
                        Category.RemoveCategory();
                        break;

                    case 14:
                        Console.Clear();
                        Supplier.AddSupplier();
                        break;

                    case 15:
                        Console.Clear();
                        Supplier.ShowAllSupplier();
                        Supplier.UpdateSupplier();
                        break;

                    case 16:
                        Console.Clear();
                        Supplier.DeleteSupplier();
                        break;

                    case 17:
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning, det måste vara enligt menyn");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
