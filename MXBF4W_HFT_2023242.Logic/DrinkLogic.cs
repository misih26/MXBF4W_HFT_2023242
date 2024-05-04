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
    public class DrinkLogic : IDrinkLogic
    {
        IRepository<Drink> repo;

        public DrinkLogic(IRepository<Drink> repo)
        {

            this.repo = repo;
        }

        public void Create(Drink item)
        {
            if (item.AlcLevel > 80)
            {
                throw new ArgumentException("Too much alcohol......");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Drink Read(int id)
        {
            var Drink = this.repo.Read(id);
            if (Drink == null)
            {
                throw new ArgumentException("Drink doesn't exist");
            }
            return Drink;
        }

        public IQueryable<Drink> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Drink item)
        {
            this.repo.Update(item);

        }
    }
}
