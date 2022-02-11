﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Shipping
    {
        public static void ShowShippingAlternatives()
        {
            using (var db = new WebShopDBContext())
            {
                string header = $"FRAKTBOLAG\n\n{"SPECIFIKATION",-20}{"PRIS",-13}\n";
                var shippingList = db.Shippings;

                Console.WriteLine(header);

                foreach (var shipping in shippingList)
                {
                    Console.WriteLine($"{shipping.Id,-3}" +
                        $"{shipping.Name,-20}" +
                        $"{shipping.Price,-13:C2}\n" +
                        $"{shipping.Specification,-25}\n"); // uppdatera & kontrollera
                                                            // att Id börjar från 1
                }
            }
        }

        public static Models.Shipping ChooseShipping()
        {
            using (var db = new WebShopDBContext())
            {
                string headerLines = "-----------------------";
                var shippingList = db.Shippings;

                foreach (var shipping in shippingList)
                {
                    Console.WriteLine($"{shipping.Id}\t{shipping.Name}\t{shipping.Price}\n{headerLines}\n{shipping.Specification}\n\n");

                }

                Console.WriteLine("Vilken fraktmetod vill du använda? (Ange ID-nr.) \n");
                int selectMethod = Convert.ToInt32(Console.ReadLine());

                return db.Shippings.SingleOrDefault(s => s.Id == selectMethod);
            }
        }
    }
}