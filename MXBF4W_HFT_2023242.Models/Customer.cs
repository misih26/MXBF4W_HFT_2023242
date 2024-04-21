using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; } //primary key

        [StringLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        public int FavDrink { get; set; } //fk

        public virtual Drink Drink { get; set; } // Navigation Property
        public Customer()
        {

        }
        public Customer(string line)
        {
            string[] split = line.Split('#');
            CustomerID = int.Parse(split[0]);
            Name = split[1];
            Age = int.Parse(split[2]);
            Gender = split[3];
            FavDrink = int.Parse(split[4]);
            //FavPub = int.Parse(split[5]);
        }
    }
}
