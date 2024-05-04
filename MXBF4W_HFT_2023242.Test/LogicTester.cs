using Moq;
using MXBF4W_HFT_2023242.Logic;
using MXBF4W_HFT_2023242.Models;
using MXBF4W_HFT_2023242.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MXBF4W_HFT_2023242.Logic.CustomerLogic;
using static MXBF4W_HFT_2023242.Logic.PubLogic;

namespace MXBF4W_HFT_2023242.Test
{
    [TestFixture]
    public class LogicTester
    {

        CustomerLogic customerlogic;
        Mock<IRepository<Customer>> mockCustomerRepo;
        DrinkLogic drinklogic;
        Mock<IRepository<Drink>> mockDrinkRepo;
        PubLogic publogic;
        Mock<IRepository<Pub>> mockPubRepo;

        [SetUp]
        public void Init()
        {
            mockCustomerRepo = new Mock<IRepository<Customer>>();
            mockDrinkRepo = new Mock<IRepository<Drink>>();
            mockPubRepo = new Mock<IRepository<Pub>>();
            var customers = new List<Customer>()
            {
                new Customer("1#Test1#21#ApachHelikopter#1"),
                new Customer("2#Test2#23#ApachHelikopter#1"),
                new Customer("3#Test3#22#ApachHelikopter#2")
            };
            var drinks = new List<Drink>()
            {
                   new Drink("1#JagerMeister#40#1000"),
                   new Drink("2#Vodka#35#800"),
                   new Drink("3#Beer#4#500"),
                   new Drink("4#Wine#15#700"),
            };

            mockCustomerRepo.Setup(x => x.ReadAll()).Returns(new List<Customer>()
            {
                new Customer("1#Test1#21#ApachHelikopter#1"){ Drink = drinks[0]},
                new Customer("2#Test2#23#ApachHelikopter#1"){ Drink = drinks[2]},
                new Customer("3#Test3#22#ApachHelikopter#2"){ Drink = drinks[0]}
            }.AsQueryable());
            customerlogic = new CustomerLogic(mockCustomerRepo.Object);

            mockPubRepo.Setup(x => x.ReadAll()).Returns(new List<Pub>()
            {
                   new Pub("1#Bar1#1111 J street 3.#6"){ Customer = customers[0]},
                   new Pub("2#Bar2#1111 G street 15.#2"){ Customer = customers[1]},
                   new Pub("3#Bar3#1111 H street 20.#6"){ Customer = customers[1]},
                   new Pub("4#Bar4#1111 K street 30.#3"){ Customer = customers[2]},
                   new Pub("5#Bar5#1111 L street 25.#3"){ Customer = customers[2]},
                   new Pub("6#Bar6#1111 I street 42.#6"){ Customer = customers[2]},
            }.AsQueryable());
            publogic = new PubLogic(mockPubRepo.Object);


        }

        [Test]
        public void CustomersWithSameDrinkTestTrue()
        {
            var drinkCount = customerlogic.GetCustomersWithSameFavDrink("JagerMeister");

            var expected = new List<CustomerWithSameFavDrink>()
            {
                new CustomerWithSameFavDrink()
                {
                    Name = "Test1",
                    DrinkName = "JagerMeister"
                },
                 new CustomerWithSameFavDrink()
                {
                    Name = "Test2",
                    DrinkName = "JagerMeister"
                }


            };
            ;
            Assert.That(drinkCount.Count() == 2);
        }

        [Test]
        public void DrinkStatTestTrue()
        {
            var actual = customerlogic.GetDrinkStat();

            var expected = new List<DrinkOrder>()
            {
                new DrinkOrder()
                {
                    Name = "JagerMeister",
                    DrinksCount = 2
                },
                new DrinkOrder()
                {
                    Name = "Beer",
                    DrinksCount = 1
                }
            };
            ;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DrinkStatTestFalse()
        {
            var actual = customerlogic.GetDrinkStat();

            var expected = new List<DrinkOrder>()
            {
                new DrinkOrder()
                {
                    Name = "Vodka",
                    DrinksCount = 2
                },
                new DrinkOrder()
                {
                    Name = "Beer",
                    DrinksCount = 1
                }
            };
            ;
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void SameFavCustomerTestTrue()
        {
            var actual = publogic.GetPubsWithSameFavCustomer("Test3");

            var expected = new List<PubsWithSameCustomer>()
            {
                new PubsWithSameCustomer()
                {
                    PubName = "Bar4",
                    CustomerName = "Test3"
                },
                new PubsWithSameCustomer()
                {
                    PubName = "Bar5",
                    CustomerName = "Test3"
                },
                new PubsWithSameCustomer()
                {
                    PubName = "Bar6",
                    CustomerName = "Test3"
                }
            };
            ;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SameFavCustomerTestFalse()
        {
            var actual = publogic.GetPubsWithSameFavCustomer("Test3");

            var expected = new List<PubsWithSameCustomer>()
            {
                new PubsWithSameCustomer()
                {
                    PubName = "Bar2",
                    CustomerName = "Test3"
                },
                new PubsWithSameCustomer()
                {
                    PubName = "Bar5",
                    CustomerName = "Test3"
                },
                new PubsWithSameCustomer()
                {
                    PubName = "Bar6",
                    CustomerName = "Test3"
                }
            };
            ;
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void HowManyPubsFavCustomerTestTrue()
        {
            var actual = publogic.GetFavoriteCustomerWithMostPubs();
            var expected = new List<Alcoholic>()
            {
                new Alcoholic()
                {
                    Name = "Test3",
                    PubsCount = 3
                },
                new Alcoholic()
                {
                     Name = "Test2",
                    PubsCount = 2
                },
                new Alcoholic()
                {
                     Name = "Test1",
                    PubsCount = 1
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HowManyPubsFavCustomerTestFalse()
        {
            var actual = publogic.GetFavoriteCustomerWithMostPubs();
            var expected = new List<Alcoholic>()
            {

                new Alcoholic()
                {
                     Name = "Test2",
                    PubsCount = 2
                },
                new Alcoholic()
                {
                     Name = "Test1",
                    PubsCount = 1
                }
            };

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void FavCustomerAgeTest()
        {
            var actual = publogic.GetPubsFavCustomerAge("Bar1");
            var expected = new List<FavCustomerAge>()
            {
                new FavCustomerAge()
                {
                    PubName = "Bar1",
                    CustomerName = "Test1",
                    CustomerAge = 21
                },


            };
            ;
            Assert.AreEqual(expected.First(), actual.First());
        }

        [Test]
        public void CreateCustomerExceptionTest()
        {
            var customer = new Customer() { Age = 1 };
            try
            {
                customerlogic.Create(customer);
            }
            catch
            {

            }
            mockCustomerRepo.Verify(x => x.Create(customer), Times.Never);
        }

        [Test]
        public void CreatePubExceptionTest()
        {
            var pub = new Pub() { Address = "ad" };
            try
            {
                publogic.Create(pub);
            }
            catch
            {

            }
            mockPubRepo.Verify(x => x.Create(pub), Times.Never);
        }

        [Test]
        public void CreateDrinkExceptionTest()
        {
            var drink = new Drink() { AlcLevel = 81 };
            try
            {
                drinklogic.Create(drink);
            }
            catch
            {

            }
            mockDrinkRepo.Verify(x => x.Create(drink), Times.Never);
        }
    }
}
