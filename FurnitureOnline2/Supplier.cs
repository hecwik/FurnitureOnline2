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

                var deleteSupplier =  supplierList.SingleOrDefault(p => p.Name == input);

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


        public static void UpdateSupplier(int id)
        {
            ShowAllSupplier();
            using (var db = new Models.WebShopDBContext())
            {

                Console.WriteLine("Vad vill du ändra?\n1. Adress\n2. Namnn\n3.Gömd artikel");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine("Adress");
                    Console.ReadLine();
                    Console.WriteLine("Postnummer");
                    Console.ReadLine();
                    Console.WriteLine("Stad:");
                    Console.ReadLine();
                }
            }
        }

    }
}
