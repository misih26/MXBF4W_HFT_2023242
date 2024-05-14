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
                Console.Write("Enter Customer ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Customer age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter Customer gender: ");
                string gender = Console.ReadLine();
                Console.Write("Enter Customer favorite drink ID: ");
                int favDrink = int.Parse(Console.ReadLine());
                rest.Post(new Customer() { Name = name, CustomerID = id, Age = age, Gender = gender, FavDrink = favDrink }, "customer");
            }
            if (entity == "Drink")
            {
                Console.Write("Enter Drink ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Drink name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Alcohol level: ");
                int alcLevel = int.Parse(Console.ReadLine());

                Console.Write("Enter Drink price: ");
                int price = int.Parse(Console.ReadLine());

                rest.Post(new Drink() { DrinkId = id, Name = name, AlcLevel = alcLevel, Price = price }, "drink");
            }
            if (entity == "Pub")
            {
                Console.Write("Enter Pub ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Pub name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Pub address: ");
                string address = Console.ReadLine();

                Console.Write("Enter Biggest Customer ID: ");
                int biggestCustomerId = int.Parse(Console.ReadLine());
                rest.Post(new Pub() { PubId = id, Name = name, Address = address, BiggestCustomerId = biggestCustomerId }, "pub");
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

                Console.Write($"New age [old: {one.Age}]: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write($"New gender [old: {one.Gender}]: ");
                string gender = Console.ReadLine();
                Console.Write($"New favorite drink ID [old: {one.FavDrink}]: ");
                int favDrink = int.Parse(Console.ReadLine());

                one.Name = name;
                one.Age = age;
                one.Gender = gender;
                one.FavDrink = favDrink;
                rest.Put(one, "customer");
            }
            if (entity == "Drink")
            {
                Console.Write("Enter Drink's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Drink one = rest.Get<Drink>(id, "drink");

                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write($"New alcohol level [old: {one.AlcLevel}]: ");
                int alcLevel = int.Parse(Console.ReadLine());
                Console.Write($"New price [old: {one.Price}]: ");
                int price = int.Parse(Console.ReadLine());

                one.Name = name;
                one.AlcLevel = alcLevel;
                one.Price = price;
                rest.Put(one, "drink");
            }
            if (entity == "Pub")
            {
                Console.Write("Enter Pub's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Pub one = rest.Get<Pub>(id, "pub");

                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write($"New address [old: {one.Address}]: ");
                string address = Console.ReadLine();
                Console.Write($"New biggest customer ID [old: {one.BiggestCustomerId}]: ");
                int biggestCustomerId = int.Parse(Console.ReadLine());

                one.Name = name;
                one.Address = address;
                one.BiggestCustomerId = biggestCustomerId;
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
