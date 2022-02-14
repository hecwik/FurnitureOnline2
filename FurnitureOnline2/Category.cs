using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Category
    {
        /// <summary>
        /// Method for adding a Category
        /// </summary>
        public static void AddCategory()
        {
            Console.WriteLine("Vad vill du att den nya kategorin ska heta?");
            string input = Console.ReadLine();

            using (var db = new WebShopDBContext())
            {
                var categories = db.Categories;
                var newCategory = new Models.Category();
                newCategory.Name = input;

                if (input != null)
                {
                    categories.Add(newCategory);
                    db.SaveChanges();
                }
                else Console.WriteLine("Du måste ange namnet på katgeorin du vill lägga till");
            }
        }

        // metod för att ta bort kategori
        public static void RemoveCategory()
        {
            ShowAllCategories();

            Console.WriteLine("Ange namnet på kategorin du vill ta bort");
            string input = Console.ReadLine();

            using (var db = new WebShopDBContext())
            {
                var categories = db.Categories;
                var updateCategories = categories.SingleOrDefault(c => c.Name == input);

                if (updateCategories != null)
                {
                    try
                    {
                        categories.Remove(updateCategories);
                    }
                    catch
                    {
                        Console.WriteLine("Den här kategorin finns nog redan i någons orderhistorik och kan därför inte tas bort.\nVill du gömma kategorin istället?");
                        string inputHide = Console.ReadLine();

                        if (inputHide == "Ja")

                            updateCategories.HiddenCategory = true;
                        else
                            updateCategories.HiddenCategory = false;
                    }
                    db.SaveChanges();

                }
                else
                    Console.WriteLine("Hittade ingen sådan kategori");
            }
        }

            ///  Shows all categories that exist for admin 
            public static string ShowAllCategories()
            {
                using (var db = new WebShopDBContext())
                {
                    var categoryList = db.Categories;

                    string returnString = $"KATEGORILISTA\n\n{"KATEGORI-ID",-10}{"KATEGORINAMN",-10}";

                    foreach (var category in categoryList)
                    {
                        returnString += $"{category.Id,-10}{category.Name,-10}\n";
                    }
                    return returnString;
                }
            }

        public static string ModifyCategories()
        {
            string change = "";
            Console.WriteLine("Vill du ändra namnet på en kategori?")
                string input = Console.ReadLine();

            if(input == "Ja")
            {
                Console.WriteLine("Ange det namnet på den befintliga kategorin");
                string oldName = Console.ReadLine();

                if(oldName == CategoName)
            }
                // return old vs new change

                return change;
        }
    }
}
