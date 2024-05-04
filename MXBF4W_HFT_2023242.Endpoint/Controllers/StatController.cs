using Microsoft.AspNetCore.Mvc;
using MXBF4W_HFT_2023242.Logic;
using static MXBF4W_HFT_2023242.Logic.CustomerLogic;
using static MXBF4W_HFT_2023242.Logic.PubLogic;
using System.Collections.Generic;

namespace MXBF4W_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICustomerLogic logic;
        IPubLogic publogic;

        public StatController(ICustomerLogic logic, IPubLogic publogic)
        {
            this.logic = logic;
            this.publogic = publogic;
        }


        [HttpGet("{drinkname}")]
        public IEnumerable<CustomerWithSameFavDrink> GetCustomersWithSameFavDrink(string drinkName)
        {
            return this.logic.GetCustomersWithSameFavDrink(drinkName);
        }

        [HttpGet]
        public IEnumerable<DrinkOrder> GetDrinkStat()
        {
            return this.logic.GetDrinkStat();
        }

        [HttpGet]
        public IEnumerable<Alcoholic> GetFavoriteCustomerWithMostPubs()
        {
            return this.publogic.GetFavoriteCustomerWithMostPubs();
        }

        [HttpGet("{barname}")]
        public IEnumerable<FavCustomerAge> GetPubsFavCustomerAge(string barname)
        {
            return this.publogic.GetPubsFavCustomerAge(barname);
        }

        [HttpGet("{customername}")]
        public IEnumerable<PubsWithSameCustomer> GetPubsWithSameFavCustomer(string customername)

        {
            return this.publogic.GetPubsWithSameFavCustomer(customername);
        }
    }
}
