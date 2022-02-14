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
                Console.Write("Vill du bli medlem (Ja eller Nej): ?");
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
            {
                Console.Write("Personnummer (ÅÅÅÅMMDD-NNNN): ");
                string personalIdInput = Console.ReadLine();

                Console.Write("Användarnamn: ");
                string userNameInput = Console.ReadLine();

                Console.Write("Password: ");
                string passWordInput = Console.ReadLine();

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
