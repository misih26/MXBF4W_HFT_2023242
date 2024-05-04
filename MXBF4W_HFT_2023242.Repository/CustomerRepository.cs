using MXBF4W_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(PubDbContext db) : base(db)
        {
        }

        public override Customer Read(int id)
        {
            return db.Customers.FirstOrDefault(t => t.CustomerID == id);
        }

        public override void Update(Customer item)
        {
            var old = Read(item.CustomerID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }

            }
            db.SaveChanges();
        }
    }
}
