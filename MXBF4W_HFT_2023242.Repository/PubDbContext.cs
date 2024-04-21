using MXBF4W_HFT_2023242.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Repository
{
    public class PubDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Pub> Pubs { get; set; }

        public PubDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                .UseInMemoryDatabase("pub");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Customer>()
            .HasOne(c => c.Drink)
            .WithMany()
            .HasForeignKey(c => c.FavDrink)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pub>()
            .HasOne(c => c.Customer)
            .WithMany()
            .HasForeignKey(c => c.BiggestCustomerId)
            .OnDelete(DeleteBehavior.Restrict);





            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer("1#John Doe#21#Male#1#2"),
                new Customer("2#John Dave#42#Male#1#1"),
                new Customer("3#John Daniel#25#Male#2#2"),
                new Customer("4#John Dennis#22#Male#3#3"),
                new Customer("5#John Demeter#18#Male#4#1"),
                new Customer("6#Gipsz Jakab#18#Male#1#1"),
                new Customer("7#Varga Ágoston#18#Male#2#4"),
                new Customer("8#Lakatos Alfonz#18#Male#2#5"),
                new Customer("9#Kovács János#18#Male#3#2"),
                new Customer("10#Nagy Lajos#18#Male#4#3"),

            });

            modelBuilder.Entity<Drink>().HasData(new Drink[]
            {
                   new Drink("1#JagerMeister#40#1000"),
                   new Drink("2#Vodka#35#800"),
                   new Drink("3#Beer#4#500"),
                   new Drink("4#Wine#15#700"),

            });

            modelBuilder.Entity<Pub>().HasData(new Pub[]
            {
                   new Pub("1#Bar1#1111 J street 3.#6"),
                   new Pub("2#Bar2#1111 G street 15.#2"),
                   new Pub("3#Bar3#1111 H street 20.#6"),
                   new Pub("4#Bar4#1111 K street 30.#3"),
                   new Pub("5#Bar5#1111 L street 25.#3"),
                   new Pub("6#Bar6#1111 I street 42.#6"),


            });
        }
        }
    }
