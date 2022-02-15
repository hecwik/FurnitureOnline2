using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnline2
{
    class Supplier
    {
        public static void AddSupplier()
        {
            using (var db = new Models.WebShopDBContext())
            {
                var supplierList = db.Suppliers;
                var newSupplier = new Models.Supplier();
                Console.Write("Vad heter leverantören? ");
                newSupplier.Name = Console.ReadLine();
                Console.WriteLine("Leverantörens adress:");
                newSupplier.Adress = Console.ReadLine();
                Console.WriteLine("Postnummer:");
                newSupplier.ZipCode = Console.ReadLine();
                Console.WriteLine("Stad");
                newSupplier.City = Console.ReadLine();
                newSupplier.HiddenSupplier = false;

                supplierList.Add(newSupplier);
                db.SaveChanges();
            }
        }

        public static void ShowAllSupplier()
        {
            using (var db = new Models.WebShopDBContext())
            {
                var supplierList = db.Suppliers;
                foreach (var item in supplierList)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
            }
        }


        public static void DeleteSupplier()
        {
            ShowAllSupplier();

            using (var db = new Models.WebShopDBContext())
            {
                var supplierList = db.Suppliers;

                Console.WriteLine("Vilken leverantör vill du ta bort?");
                string input = Console.ReadLine();

                var deleteSupplier = supplierList.SingleOrDefault(p => p.Name == input);

                try
                {
                    supplierList.Remove(deleteSupplier);
                }
                catch
                {
                    Console.WriteLine("Det går inte att ta bort produkten eftersom en kund redan har köpt den. Vill du istället gömma artikeln? (Ja eller Nej)");
                    string inputString = Console.ReadLine();

                    if (inputString == "Ja") deleteSupplier.HiddenSupplier = true;
                }

                db.SaveChanges();
            }
        }


        public static void UpdateSupplier()
        {
            ShowAllSupplier();
            using (var db = new Models.WebShopDBContext())
            {
                Console.WriteLine("Vilken leverantör vill du ta bort?");
                string input = Console.ReadLine();

                var supplierList = db.Suppliers;
                var updateSupplier = supplierList.SingleOrDefault(p => p.Name == input);

                Console.WriteLine("Vad vill du ändra?\n1. Adress\n2. Namnn\n3.Gömd artikel");
                int input2 = Convert.ToInt32(Console.ReadLine());

                if (input2 == 1)
                {
                    Console.Write("Adress: ");
                    updateSupplier.Adress = Console.ReadLine();
                    Console.Write("Postnummer: ");
                    updateSupplier.ZipCode = Console.ReadLine();
                    Console.Write("Stad: ");
                    updateSupplier.City = Console.ReadLine();
                }
                else if (input2 == 2)
                {
                    Console.Write("Nya namnet: ");
                    updateSupplier.Name = Console.ReadLine();
                }
                else
                {
                    Console.Write("Vill du att artikeln ska vara gömd? Ja/Nej ");
                    input = Console.ReadLine();
                    if (input == "Ja")
                    {
                        updateSupplier.HiddenSupplier = true;
                    }
                    else
                    {
                        updateSupplier.HiddenSupplier = false;
                    }
                }
                db.SaveChanges();
            }

        }
    }
}
