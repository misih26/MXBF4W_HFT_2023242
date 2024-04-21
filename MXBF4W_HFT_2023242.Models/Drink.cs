using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXBF4W_HFT_2023242.Models
{
    public class Drink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrinkId { get; set; } //primary key

        [StringLength(100)]
        public string Name { get; set; }

        public int AlcLevel { get; set; }

        public int Price { get; set; }
        //public int BiggestBuyer { get; set; }

        //  public virtual Customer Customer { get; set; } // Navigation Property, ide is kell?
        public Drink()
        {
                
        }
        public Drink(string line)
        {
            string[] split = line.Split('#');
            DrinkId = int.Parse(split[0]);
            Name = split[1];
            AlcLevel = int.Parse(split[2]);
            Price = int.Parse(split[3]);
            //BiggestBuyer = int.Parse(split[4]);


        }
    }
}
