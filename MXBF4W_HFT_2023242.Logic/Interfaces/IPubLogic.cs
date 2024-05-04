using MXBF4W_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MXBF4W_HFT_2023242.Logic.PubLogic;

namespace MXBF4W_HFT_2023242.Logic
{
    public interface IPubLogic
    {
        void Create(Pub item);
        void Delete(int id);
        Pub Read(int id);
        IQueryable<Pub> ReadAll();
        void Update(Pub item);

        IEnumerable<PubsWithSameCustomer> GetPubsWithSameFavCustomer(string customername);
        IEnumerable<FavCustomerAge> GetPubsFavCustomerAge(string barname);

        IEnumerable<Alcoholic> GetFavoriteCustomerWithMostPubs();
    }
}
