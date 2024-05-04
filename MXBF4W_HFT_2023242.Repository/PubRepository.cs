using MXBF4W_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Repository
{
    public class PubRepository : Repository<Pub>, IRepository<Pub>
    {
        public PubRepository(PubDbContext db) : base(db)
        {
        }

        public override Pub Read(int id)
        {
            return db.Pubs.FirstOrDefault(t => t.PubId == id);
        }

        public override void Update(Pub item)
        {
            var old = Read(item.PubId);
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
