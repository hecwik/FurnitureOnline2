using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnline2.Models;

namespace FurnitureOnline2
{
    class Customers
    {
        /// <summary>
        /// Method for registering new members or logging in members
        /// </summary>
        /// <returns></returns>/
        public static Models.Customer DetermineMember()
        {
            Console.Write("Är du medlem? (Ja eller Nej): ");
            string input = Console.ReadLine();

            var member = new Models.Customer();

            if (input == "Ja")
            {
                member = MemberLogin();
            }
            else if (input == "Nej")
            {
                Console.Write("Vill du bli medlem (Ja eller Nej): ");
                string input2 = Console.ReadLine();

                if (input2 == "Ja")
                {
                    member = CreateMember();
                }
                else
                {
                    member = GuestShopping();
                }
            }
            return member;
        }

        public static Models.Customer CreateMember()
        {

            Console.Write("Personnummer (ÅÅÅÅMMDD-NNNN): ");
            string personalIdInput = Console.ReadLine();

            if (personalIdInput.Contains("-") == false || personalIdInput.Length != 13)
            {
                Console.WriteLine("Personnummer måste skrivas enligt formatet (ÅÅÅÅMMDD-NNNN).");
                Console.ReadLine();
            }

            Console.Write("Ange ett användarnamn (max 15 tecken): ");
            string userNameInput = Console.ReadLine();

            /*
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            */

            if (userNameInput.Length > 15)
            {
                Console.WriteLine("Användarnamn kan enbart vara 15 tecken långt.");
                Console.ReadLine();
            }

            Console.Write("Ange ett lösenord (max 15 tecken): ");
            var passWordInput = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && passWordInput.Length > 0)
                {
                    Console.Write("\b \b");
                    passWordInput = passWordInput[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    passWordInput += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            if (passWordInput.Length > 15) 
            { 
                Console.WriteLine("Lösenordet är för långt."); 
            }

            Console.Write("Förnamn: ");
            string firstNameInput = Console.ReadLine();

            Console.Write("Efternamn: ");
            string lastNameInput = Console.ReadLine();

            Console.Write("Adress: ");
            string adressInput = Console.ReadLine();

            Console.Write("Postnummer: ");
            string postalCodeInput = Console.ReadLine();

            Console.Write("Postort: ");
            string postalAreaInput = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            string phoneNumberInput = Console.ReadLine();

            Console.WriteLine("E-mail: ");
            string emailAdressInput = Console.ReadLine();

            var newCustomer = new Models.Customer()
            {
                IdNumber = personalIdInput,
                UserName = userNameInput,
                Password = passWordInput,
                FirstName = firstNameInput,
                LastName = lastNameInput,
                Adress = adressInput,
                ZipCode = postalCodeInput,
                City = postalAreaInput,
                PhoneNumber = phoneNumberInput,
                Email = emailAdressInput,
                Membership = true
            };

            using (var db = new Models.WebShopDBContext())
            {
                var customerList = db.Customers;

                customerList.Add(newCustomer);
                db.SaveChanges();
            }
            return newCustomer;
        }
        public static Models.Customer GuestShopping()
        {
            Console.Write("Personnummer (ÅÅÅÅMMDD-NNNN): ");
            string personalIdInput = Console.ReadLine();

            Console.Write("Förnamn: ");
            string firstNameInput = Console.ReadLine();

            Console.Write("Efternamn: ");
            string lastNameInput = Console.ReadLine();

            Console.Write("Adress: ");
            string adressInput = Console.ReadLine();

            Console.Write("Postnummer: ");
            string postalCodeInput = Console.ReadLine();

            Console.Write("Postort: ");
            string postalAreaInput = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            string phoneNumberInput = Console.ReadLine();

            Console.WriteLine("E-mail: ");
            string emailAdressInput = Console.ReadLine();

            var guestShopper = new Models.Customer() 
            { 
                IdNumber = personalIdInput, 
                FirstName = firstNameInput, 
                LastName = lastNameInput, 
                Adress = adressInput, 
                ZipCode = postalCodeInput, 
                City = postalAreaInput, 
                PhoneNumber = phoneNumberInput, 
                Email = emailAdressInput };

            using (var db = new Models.WebShopDBContext())
            {
                var customerList = db.Customers;

                if (guestShopper.UserName == null) guestShopper.UserName = guestShopper.LastName.ToString();

                customerList.Add(guestShopper);
                db.SaveChanges();
            }
            return guestShopper;
        }

        public static Models.Customer MemberLogin()
        {
            bool loggedIn = false;

            while (!loggedIn)
            {
                string addUserDetails = "Ange ditt användarnamn, personnummer(ÅÅÅÅMMDD-NNNN) eller email: ";
                string addPassword = "Ange ditt lösenord: ";
                
                Console.WriteLine(addUserDetails);
                string userDetailInput = Console.ReadLine();
                Console.WriteLine(addPassword);
                string passwordInput = Console.ReadLine();

                using (var db = new Models.WebShopDBContext())
                {
                    var customerList = db.Customers;

                    foreach (var customers in customerList)
                    {
                        if ((customers.UserName == userDetailInput || customers.IdNumber == userDetailInput || customers.Email == userDetailInput) && customers.Password == passwordInput)
                        {
                            loggedIn = true;
                            return customers;
                        }
                    }
                    Console.WriteLine("Felaktig inmatning, ange enligt exemplet");
                }
            }
            return null;
        }
    }
}
