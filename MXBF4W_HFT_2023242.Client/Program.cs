using ConsoleTools;
using MXBF4W_HFT_2023242.Models;
using System;
using System.Collections.Generic;


namespace MXBF4W_HFT_2023242.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer name: ");
                string name = Console.ReadLine();
                rest.Post(new Customer() { Name = name, Age = 19 }, "customer");
            }
            if (entity == "Drink")
            {
                Console.Write("Enter Drink name: ");
                string name = Console.ReadLine();
                rest.Post(new Drink() { Name = name, AlcLevel = 19 }, "drink");
            }
            if (entity == "Pub")
            {
                Console.Write("Enter Pub name: ");
                string name = Console.ReadLine();
                rest.Post(new Pub() { Name = name, Address = "Adsadasd" }, "pub");
            }
        }
        static void List(string entity)
        {
            if (entity == "Customer")
            {
                List<Customer> customers = rest.Get<Customer>("customer");
                foreach (var item in customers)
                {
                    Console.WriteLine(item.CustomerID + ": " + item.Name);
                }
                Console.ReadLine();
            }
            if (entity == "Drink")
            {
                List<Drink> drinks = rest.Get<Drink>("drink");
                foreach (var item in drinks)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
            if (entity == "Pub")
            {
                List<Pub> pubs = rest.Get<Pub>("pub");
                foreach (var item in pubs)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
        static void Update(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Customer one = rest.Get<Customer>(id, "customer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "customer");
            }
            if (entity == "Drink")
            {
                Console.Write("Enter Drink's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Drink one = rest.Get<Drink>(id, "drink");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "drink");
            }
            if (entity == "Pub")
            {
                Console.Write("Enter Pub's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Pub one = rest.Get<Pub>(id, "pub");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "pub");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "customer");
            }
            if (entity == "Drink")
            {
                Console.Write("Enter Drink's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "drink");
            }
            if (entity == "Pub")
            {
                Console.Write("Enter Pub's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "pub");
            }
        }

        static void GetCustomersWithSameFavDrink(string entity)
        {
            if (entity == "GetCustomersWithSameFavDrink")
            {
                Console.WriteLine("Enter drink name: ");
                string drinkname = Console.ReadLine();
                var q = rest.Get<dynamic>($"stat/GetCustomersWithSameFavDrink/{drinkname}");

                foreach (var item in q)
                {
                    Console.WriteLine("Name: " + item.name + "\nDrink name: " + item.drinkName + "\n");
                }
                Console.ReadLine();
            }
        }
        static void GetDrinkStat(string entity)
        {
            if (entity == "GetDrinkStat")
            {
                var q = rest.Get<dynamic>("stat/GetDrinkStat");
                foreach (var item in q)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }

        static void GetFavoriteCustomerWithMostPubs(string entity)
        {
            if (entity == "GetFavoriteCustomerWithMostPubs")
            {
                var q = rest.Get<dynamic>("stat/GetFavoriteCustomerWithMostPubs");
                foreach (var item in q)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }

        static void GetPubsFavCustomerAge(string entity)
        {
            if (entity == "GetPubsFavCustomerAge")
            {
                Console.WriteLine("Enter bar name: ");
                string barname = Console.ReadLine();
                var q = rest.Get<dynamic>($"stat/GetPubsFavCustomerAge/{barname}");

                foreach (var item in q)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }

        static void GetPubsWithSameFavCustomer(string entity)
        {
            if (entity == "GetPubsWithSameFavCustomer")
            {
                Console.WriteLine("Enter customer name: ");
                string customername = Console.ReadLine();
                var q = rest.Get<dynamic>($"stat/GetPubsWithSameFavCustomer/{customername}");

                foreach (var item in q)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }



        static void Main(string[] args)
        {

            rest = new RestService("http://localhost:14226/", "pub");



            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("GetCustomersWithSameFavDrink", () => GetCustomersWithSameFavDrink("GetCustomersWithSameFavDrink"))
                .Add("GetDrinkStat", () => GetDrinkStat("GetDrinkStat"))
                .Add("Exit", ConsoleMenu.Close);

            var drinkSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Drink"))
                .Add("Create", () => Create("Drink"))
                .Add("Delete", () => Delete("Drink"))
                .Add("Update", () => Update("Drink"))
                .Add("Exit", ConsoleMenu.Close);

            var pubSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Pub"))
                .Add("Create", () => Create("Pub"))
                .Add("Delete", () => Delete("Pub"))
                .Add("Update", () => Update("Pub"))
                .Add("GetFavoriteCustomerWithMostPubs", () => GetFavoriteCustomerWithMostPubs("GetFavoriteCustomerWithMostPubs"))
                .Add("GetPubsFavCustomerAge", () => GetPubsFavCustomerAge("GetPubsFavCustomerAge"))
                .Add("GetPubsWithSameFavCustomer", () => GetPubsWithSameFavCustomer("GetPubsWithSameFavCustomer"))
                .Add("Exit", ConsoleMenu.Close);




            var menu = new ConsoleMenu(args, level: 0)
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Drinks", () => drinkSubMenu.Show())
                .Add("Pubs", () => pubSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
