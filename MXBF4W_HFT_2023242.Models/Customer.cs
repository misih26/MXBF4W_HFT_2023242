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
    }
}
