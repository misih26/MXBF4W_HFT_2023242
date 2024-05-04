using MXBF4W_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MXBF4W_HFT_2023242.Logic.CustomerLogic;

namespace MXBF4W_HFT_2023242.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);

        IEnumerable<DrinkOrder> GetDrinkStat();

        IEnumerable<CustomerWithSameFavDrink> GetCustomersWithSameFavDrink(string drinkName);


    }
}
