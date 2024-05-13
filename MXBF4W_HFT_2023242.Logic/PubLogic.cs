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
    public class PubLogic : IPubLogic
    {
        IRepository<Pub> repo;

        public PubLogic(IRepository<Pub> repo)
        {

            this.repo = repo;
        }

        public void Create(Pub item)
        {
            if (item.Address.Length < 3)
            {
                throw new ArgumentException("Address too short......");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Pub Read(int id)
        {
            var Pub = this.repo.Read(id);
            if (Pub == null)
            {
                throw new ArgumentException("Pub doesn't exist");
            }
            return Pub;
        }

        public IQueryable<Pub> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Pub item)
        {
            this.repo.Update(item);

        }

        public IEnumerable<PubsWithSameCustomer> GetPubsWithSameFavCustomer(string customername)
        {
            return from x in this.repo.ReadAll()
                   where x.Customer.Name == customername
                   select new PubsWithSameCustomer()
                   {
                       PubName = x.Name,
                       CustomerName = x.Customer.Name
                   };

        }
        public class PubsWithSameCustomer
        {
            public PubsWithSameCustomer()
            {
            }

            public string PubName { get; set; }
            public string CustomerName { get; set; }
            public override bool Equals(object obj)
            {
                PubsWithSameCustomer other = obj as PubsWithSameCustomer;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return this.PubName == other.PubName &&
                        this.CustomerName == other.CustomerName;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.PubName, this.CustomerName);
            }
        }


        //visszaadja törzsvásárlóját és annak életkorát
        public IEnumerable<FavCustomerAge> GetPubsFavCustomerAge(string barname)
        {
            return from x in this.repo.ReadAll()
                   where x.Name == barname
                   select new FavCustomerAge()
                   {
                       PubName = x.Name,
                       CustomerName = x.Customer.Name,
                       CustomerAge = x.Customer.Age

                   };

        }

        public class FavCustomerAge
        {
            public FavCustomerAge()
            {
            }

            public string PubName { get; set; }
            public string CustomerName { get; set; }
            public int CustomerAge { get; set; }

            public override bool Equals(object obj)
            {
                FavCustomerAge other = obj as FavCustomerAge;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return this.PubName == other.PubName &&
                        this.CustomerName == other.CustomerName &&
                        this.CustomerAge == other.CustomerAge;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.PubName, this.CustomerName, this.CustomerAge);
            }
        }


        //hány pubban törzsvásárló valaki?

        public IEnumerable<Alcoholic> GetFavoriteCustomerWithMostPubs()
        {

            return from p in this.repo.ReadAll()
                   group p by p.Customer.Name into g
                   orderby g.Count() descending
                   select new Alcoholic
                   {
                       Name = g.Key,
                       PubsCount = g.Count()
                   };



        }

        public class Alcoholic
        {
            public string Name { get; set; }
            public int PubsCount { get; set; }
            public override bool Equals(object obj)
            {
                Alcoholic other = obj as Alcoholic;
                if (other == null)
                {
                    return false;
                }
                else
                {
                    return this.Name == other.Name &&
                        this.PubsCount == other.PubsCount;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.PubsCount);
            }
        }

    }
}
