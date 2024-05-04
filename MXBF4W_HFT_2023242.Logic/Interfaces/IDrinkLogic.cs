using MXBF4W_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Logic
{
    public interface IDrinkLogic
    {
        void Create(Drink item);
        void Delete(int id);
        Drink Read(int id);
        IQueryable<Drink> ReadAll();
        void Update(Drink item);
    }
}
