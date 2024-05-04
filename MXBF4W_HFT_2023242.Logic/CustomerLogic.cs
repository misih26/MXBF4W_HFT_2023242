using MXBF4W_HFT_2023242.Logic;
using MXBF4W_HFT_2023242.Models;
using MXBF4W_HFT_2023242.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> repo)
        {

            this.repo = repo;
        }

        public void Create(Customer item)
        {
            if (item.Age < 18)
            {
                throw new ArgumentException("Customer too young......");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Customer Read(int id)
        {
            var customer = this.repo.Read(id);
            if (customer == null)
            {
                throw new ArgumentException("Customer doesn't exist");
            }
            return customer;
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Customer item)
        {
            this.repo.Update(item);
        }

        //non-crud

        public IEnumerable<CustomerWithSameFavDrink> GetCustomersWithSameFavDrink(string drinkName)
        {
            return from x in this.repo.ReadAll()
                   where x.Drink.Name == drinkName
                   select new CustomerWithSameFavDrink()
                   {
                       Name = x.Name,
                       DrinkName = drinkName

                   };



        }
        public class CustomerWithSameFavDrink
        {

            public string Name { get; set; }
            public string DrinkName { get; set; }
        }


        //legnépszerűbb italok sorrendbe

        public IEnumerable<DrinkOrder> GetDrinkStat()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Drink.Name into g
                   orderby g.Count() descending
                   select new DrinkOrder
                   {
                       Name = g.Key,
                       DrinksCount = g.Count()
                   };



        }

        public class DrinkOrder
        {
            public string Name { get; set; }
            public int DrinksCount { get; set; }

            public override bool Equals(object obj)
            {
                DrinkOrder other = obj as DrinkOrder;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == other.Name &&
                        this.DrinksCount == other.DrinksCount;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.DrinksCount);
            }
        }
    }
}
